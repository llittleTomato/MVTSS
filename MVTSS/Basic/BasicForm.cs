//#define USE_CALLBACK  //ͼ��ץȡ��ʽ�궨�壬������ûص�������ʽ���رգ���ʹ�ö��߳�����ץȡ��ʽ��
//BIG5 TRANS ALLOWED


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using MVSDK;//ʹ��SDK�ӿ�
using Snapshot; 
using CameraHandle = System.Int32;
using MvApi = MVSDK.MvApi;
using System.IO;

namespace MainProject
{
    public partial class BasicForm : Form
    {
        #region variable
        protected CameraHandle m_hCamera = 0;             // ���
        protected IntPtr       m_ImageBuffer;             // Ԥ��ͨ��RGBͼ�񻺴�
        protected IntPtr       m_ImageBufferSnapshot;     // ץ��ͨ��RGBͼ�񻺴�
        protected tSdkCameraCapbility tCameraCapability;  // �����������
        protected int          m_iDisplayedFrames = 0;    //�Ѿ���ʾ����֡��
        protected CAMERA_SNAP_PROC m_CaptureCallback;
        protected IntPtr       m_iCaptureCallbackCtx;     //ͼ��ص������������Ĳ���
        protected Thread       m_tCaptureThread;          //ͼ��ץȡ�߳�
        protected bool         m_bExitCaptureThread = false;//�����̲߳ɼ�ʱ�����߳��˳��ı�־
        protected IntPtr       m_iSettingPageMsgCallbackCtx; //������ý�����Ϣ�ص������������Ĳ���   
        protected tSdkFrameHead m_tFrameHead;
        protected SnapshotDlg  m_DlgSnapshot = new SnapshotDlg();               //��ʾץ��ͼ��Ĵ���
        protected bool          m_bEraseBk = false;
        protected bool          m_bSaveImage = false;
        protected string imagePath="c:\\test.bmp";
        #endregion

        public BasicForm()
        {
            InitializeComponent();

            //if (InitCamera() == true)
            //{
            //    MvApi.CameraPlay(m_hCamera);
            //    BtnPlay.Text = "Pause";
            //}

            //this.FormClosing += new FormClosingEventHandler(this.BasicForm_FormClosing);
        }

        public void CaptureThreadProc()
        {
            CameraSdkStatus eStatus;
            tSdkFrameHead FrameHead;
            IntPtr uRawBuffer;//rawbuffer��SDK�ڲ����롣Ӧ�ò㲻Ҫ����delete֮����ͷź���
  
            while(m_bExitCaptureThread == false)
            {
                //500���볬ʱ,ͼ��û����ǰ���̻߳ᱻ����,�ͷ�CPU�����Ը��߳����������sleep
                eStatus = MvApi.CameraGetImageBuffer(m_hCamera, out FrameHead, out uRawBuffer, 500);
                
                if (eStatus == CameraSdkStatus.CAMERA_STATUS_SUCCESS)//����Ǵ���ģʽ�����п��ܳ�ʱ
                {
                    //ͼ������ԭʼ���ת��ΪRGB��ʽ��λͼ���ݣ�ͬʱ���Ӱ�ƽ�⡢���Ͷȡ�LUT��ISP����
                    MvApi.CameraImageProcess(m_hCamera, uRawBuffer, m_ImageBuffer, ref FrameHead);
                    //����ʮ���ߡ��Զ��عⴰ�ڡ���ƽ�ⴰ����Ϣ(����������Ϊ�ɼ�״̬��)��    
                    MvApi.CameraImageOverlay(m_hCamera, m_ImageBuffer, ref FrameHead);
                    //����SDK��װ�õĽӿڣ���ʾԤ��ͼ��
                    MvApi.CameraDisplayRGB24(m_hCamera, m_ImageBuffer, ref FrameHead);
                    //�ɹ�����CameraGetImageBuffer������ͷţ��´β��ܼ�������CameraGetImageBuffer����ͼ��
                    MvApi.CameraReleaseImageBuffer(m_hCamera,uRawBuffer);

                    if (FrameHead.iWidth != m_tFrameHead.iWidth || FrameHead.iHeight != m_tFrameHead.iHeight)
                    {
                        m_bEraseBk = true;
                        m_tFrameHead = FrameHead;  
                    }

                    m_iDisplayedFrames++;

                    if (m_bSaveImage)
                    {
                        string file_path;
                        file_path = imagePath;
                        byte[] file_path_bytes = Encoding.Default.GetBytes(file_path);
                        MvApi.CameraSaveImage(m_hCamera, file_path_bytes, m_ImageBuffer, ref FrameHead, emSdkFileType.FILE_PNG, 100);
                        m_bSaveImage = false;
                    }
                } 
            }        
        }

        private bool InitCamera()
        {
            CameraSdkStatus status;
            tSdkCameraDevInfo[] tCameraDevInfoList;

            if (m_hCamera > 0)
            {
                //�Ѿ���ʼ������ֱ�ӷ��� true
                return true;
            }

            status = MvApi.CameraEnumerateDevice(out tCameraDevInfoList);
            if (status == CameraSdkStatus.CAMERA_STATUS_NO_DEVICE_FOUND)
            {
                MessageBox.Show("δ�ҵ��������������Ƿ�����ȷ��", "����", MessageBoxButtons.OK);
                return false;
            }

            if (status == CameraSdkStatus.CAMERA_STATUS_SUCCESS)
            {
                if (tCameraDevInfoList != null)//��ʱiCameraCounts������ʵ�����ӵ�����������������1�����ʼ����һ�����
                {
                    status = MvApi.CameraInit(ref tCameraDevInfoList[0], -1, -1, ref m_hCamera);
                    if (status == CameraSdkStatus.CAMERA_STATUS_SUCCESS)
                    {
                        //��������������
                        MvApi.CameraGetCapability(m_hCamera, out tCameraCapability);

                        m_ImageBuffer = Marshal.AllocHGlobal(tCameraCapability.sResolutionRange.iWidthMax *
                            tCameraCapability.sResolutionRange.iHeightMax * 3 + 1024);
                        m_ImageBufferSnapshot = Marshal.AllocHGlobal(tCameraCapability.sResolutionRange.iWidthMax *
                            tCameraCapability.sResolutionRange.iHeightMax * 3 + 1024);

                        //��ʼ����ʾģ�飬ʹ��SDK�ڲ���װ�õ���ʾ�ӿ�
                        MvApi.CameraDisplayInit(m_hCamera, PreviewBox.Handle);
                        MvApi.CameraSetDisplaySize(m_hCamera, PreviewBox.Width, PreviewBox.Height);

                        //����ץ��ͨ���ķֱ��ʡ�
                        tSdkImageResolution tResolution;
                        tResolution.uSkipMode = 0;
                        tResolution.uBinAverageMode = 0;
                        tResolution.uBinSumMode = 0;
                        tResolution.uResampleMask = 0;
                        tResolution.iVOffsetFOV = 0;
                        tResolution.iHOffsetFOV = 0;
                        tResolution.iWidthFOV = tCameraCapability.sResolutionRange.iWidthMax;
                        tResolution.iHeightFOV = tCameraCapability.sResolutionRange.iHeightMax;
                        tResolution.iWidth = tResolution.iWidthFOV;
                        tResolution.iHeight = tResolution.iHeightFOV;
                        //tResolution.iIndex = 0xff;��ʾ�Զ���ֱ���,���tResolution.iWidth��tResolution.iHeight
                        //����Ϊ0�����ʾ����Ԥ��ͨ���ķֱ��ʽ���ץ�ġ�ץ��ͨ���ķֱ��ʿ��Զ�̬���ġ�
                        //�����н�ץ�ķֱ��ʹ̶�Ϊ���ֱ��ʡ�
                        tResolution.iIndex = 0xff;
                        tResolution.acDescription = new byte[32];//������Ϣ���Բ�����
                        tResolution.iWidthZoomHd = 0;
                        tResolution.iHeightZoomHd = 0;
                        tResolution.iWidthZoomSw = 0;
                        tResolution.iHeightZoomSw = 0;

                        MvApi.CameraSetResolutionForSnap(m_hCamera, ref tResolution);

                        //��SDK������������ͺŶ�̬��������������ô��ڡ�
                        MvApi.CameraCreateSettingPage(m_hCamera, this.Handle, tCameraDevInfoList[0].acFriendlyName,/*SettingPageMsgCalBack*/null,/*m_iSettingPageMsgCallbackCtx*/(IntPtr)null, 0);

                        //���ַ�ʽ�����Ԥ��ͼ�����ûص���������ʹ�ö�ʱ�����߶����̵߳ķ�ʽ��
                        //��������CameraGetImageBuffer�ӿ���ץͼ��
                        //�����н���ʾ�����ֵķ�ʽ,ע�⣬���ַ�ʽҲ����ͬʱʹ�ã������ڻص������У�
                        //��Ҫʹ��CameraGetImageBuffer������������������
                        //�����Ҫ���ö��̣߳�ʹ������ķ�ʽ
                        m_bExitCaptureThread = false;
                        m_tCaptureThread = new Thread(new ThreadStart(CaptureThreadProc));
                        m_tCaptureThread.Start();


                        //MvApi.CameraReadSN �� MvApi.CameraWriteSN ���ڴ�����ж�д�û��Զ�������кŻ����������ݣ�32���ֽ�
                        //MvApi.CameraSaveUserData �� MvApi.CameraLoadUserData���ڴ�����ж�ȡ�Զ������ݣ�512���ֽ�
                        return true;
                    }
                    else
                    {
                        m_hCamera = 0;
                        StateLabel.Text = "Camera init error";
                        return false;
                    }
                }
            }
            return false;
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            if (m_hCamera < 1)//��δ��ʼ�����
            {
                if (InitCamera() == true)
                {
                    MvApi.CameraPlay(m_hCamera);
                    BtnPlay.Text = "��ͣ";
                }
            }
            else//�Ѿ���ʼ��
            {
                if (BtnPlay.Text == "����")
                {
                    MvApi.CameraPlay(m_hCamera);
                    BtnPlay.Text = "��ͣ";
                }
                else
                {
                    MvApi.CameraPause(m_hCamera);
                    BtnPlay.Text = "����";
                }
            }
        }

        private void BasicForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_hCamera > 0)
            {
                m_bExitCaptureThread = true;
                //while (m_tCaptureThread.IsAlive)
                //{
                //    Thread.Sleep(10);
                //}

                MvApi.CameraUnInit(m_hCamera);
                Marshal.FreeHGlobal(m_ImageBuffer);
                Marshal.FreeHGlobal(m_ImageBufferSnapshot);
                m_hCamera = 0;
            }
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            if (m_hCamera > 0)
            {
                MvApi.CameraShowSettingPage(m_hCamera, 1);//1 show ; 0 hide
            }
        }

        //1�����һ����Ƶ��Ϣ
        private void timer1_Tick(object sender, EventArgs e)
        {
            tSdkFrameStatistic tFrameStatistic;
            if (m_hCamera > 0)
            {
                //���SDK��ͼ��֡ͳ����Ϣ������֡������֡�ȡ�
                MvApi.CameraGetFrameStatistic(m_hCamera, out tFrameStatistic);
                //��ʾ֡����Ӧ�ó����Լ���¼��
                string sFrameInfomation = String.Format("| Resolution:{0}*{1} | Display frames{2} | Capture frames{3} |", m_tFrameHead.iWidth,
                    m_tFrameHead.iHeight, m_iDisplayedFrames, tFrameStatistic.iCapture);
                StateLabel.Text = sFrameInfomation;   
            }
            else
            {
                StateLabel.Text = "";
            }
        }

        //���ڷֱ����л�ʱ��ˢ�±�����ͼ
        private void timer2_Tick(object sender, EventArgs e)
        {
            //�л��ֱ��ʺ󣬲���һ�α���
            if (m_bEraseBk == true)
            {
                m_bEraseBk = false;
                PreviewBox.Refresh();
            }

            
        }

        private void BtnSnapshot_Click(object sender, EventArgs e)
        {
            tSdkFrameHead tFrameHead;
            IntPtr uRawBuffer;//��SDK�и�RAW���ݷ����ڴ棬���ͷ�          
                          
            if (m_hCamera <= 0)
            {
                return;//�����δ��ʼ���������Ч
            }
            
            if (MvApi.CameraSnapToBuffer(m_hCamera, out tFrameHead, out uRawBuffer,500) == CameraSdkStatus.CAMERA_STATUS_SUCCESS)
            {
                //��ʱ��uRawBufferָ�������ԭʼ���ݵĻ�������ַ��Ĭ�������Ϊ8bitλ���Bayer��ʽ�����
                //����Ҫ����bayer���ݣ���ʱ�Ϳ���ֱ�Ӵ����ˣ������Ĳ�����ʾ����ν�ԭʼ����ת��ΪRGB��ʽ
                //����ʾ�ڴ����ϡ�
                //����������ԭʼ����ת��ΪRGB��ʽ���ڴ�m_ImageBufferSnapshot��
                MvApi.CameraImageProcess(m_hCamera, uRawBuffer, m_ImageBufferSnapshot, ref tFrameHead);
                //CameraSnapToBuffer�ɹ����ú������CameraReleaseImageBuffer�ͷ�SDK�з����RAW���ݻ�����
                //���򣬽������������Ԥ��ͨ����ץ��ͨ���ᱻһֱ������ֱ������CameraReleaseImageBuffer�ͷź������
                MvApi.CameraReleaseImageBuffer(m_hCamera, uRawBuffer);
                //����ץ����ʾ���ڡ�
                m_DlgSnapshot.UpdateImage(ref tFrameHead, m_ImageBufferSnapshot);
                m_DlgSnapshot.Show(); 
            }
        }

        private void BasicForm_Load(object sender, EventArgs e)
        {
            
        }

        private void SaveImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = "c:\\";
            sfd.Filter = "jpg�ļ�(*.jpg)|*.jpg|png�ļ�(*.png)|*.png";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                imagePath = sfd.FileName;
            }
            m_bSaveImage = true;//֪ͨԤ���̣߳�����һ��ͼƬ����Ҳ���Բο�BtnSnapshot_Click��ץͼ��ʽ������ץһ��ͼƬ��Ȼ����� MvApi.CameraSaveImage ����ͼƬ���档      
        }
    }
}