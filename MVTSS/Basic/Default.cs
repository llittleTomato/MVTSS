using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CameraHandle = System.Int32;
using MvApi = MVSDK.MvApi;
using System.Threading;
using MVSDK;//使用SDK接口
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.CV.CvEnum;

namespace MainProject
{
    public partial class Default : Form
    {
        BasicForm bf = new BasicForm();

        public Default()
        {
            InitializeComponent();
        }

        private void 打开原始图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image<Bgr, Byte> img1 = new Image<Bgr, Byte>(ofd.FileName);
                pnlmain.Controls.Clear();
                PictureProcess pp = new PictureProcess(img1.ToBitmap());
                pp.TopLevel = false;
                pp.Dock = System.Windows.Forms.DockStyle.Fill;
                pp.FormBorderStyle = FormBorderStyle.None;
                pnlmain.Controls.Add(pp);
                pp.Show();
            }
        }

        private void 打开测量文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlmain.Controls.Clear();
            DataManagement dg = new DataManagement();
            dg.TopLevel = false;
            dg.Dock = System.Windows.Forms.DockStyle.Fill;
            dg.FormBorderStyle = FormBorderStyle.None;
            pnlmain.Controls.Add(dg);
            dg.Show();
        }

        private void 采集照片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlmain.Controls.Clear();
            bf.TopLevel = false;
            bf.Dock = System.Windows.Forms.DockStyle.Fill;
            bf.FormBorderStyle = FormBorderStyle.None;
            pnlmain.Controls.Add(bf);
            bf.Show();
        }

        private void 图像处理toolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlmain.Controls.Clear();
            PictureProcess pp = new PictureProcess(null);
            pp.TopLevel = false;
            pp.Dock = System.Windows.Forms.DockStyle.Fill;
            pp.FormBorderStyle = FormBorderStyle.None;
            pnlmain.Controls.Add(pp);
            pp.Show();
        }

        private void 数据测量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlmain.Controls.Clear();
            basicDataInput dm = new basicDataInput(null);
            dm.TopLevel = false;
            dm.Dock = System.Windows.Forms.DockStyle.Fill;
            dm.FormBorderStyle = FormBorderStyle.None;
            pnlmain.Controls.Add(dm);
            dm.Show();
        }

        private void 数据管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlmain.Controls.Clear();
            DataManagement dg = new DataManagement();
            dg.TopLevel = false;
            dg.Dock = System.Windows.Forms.DockStyle.Fill;
            dg.FormBorderStyle = FormBorderStyle.None;
            pnlmain.Controls.Add(dg);
            dg.Show();
        }
    }
}
