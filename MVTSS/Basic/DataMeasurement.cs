using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.CV.CvEnum;

namespace MainProject
{
    public partial class DataMeasurement : Form
    {
        DataOperate dataoperate = new DataOperate();
        DataSet ds = new DataSet();

        double coe = 0.4;//缩放系数
        string cout;//测量次数
        string oper;
        string serial;
        string datetime;

        Image<Bgr, Byte> p1;//读入图片
        Image<Gray, Byte> cannyGray;//边缘检测得到图片

        //计算γ角变量
        int mDcount_gama;//点选择次数
        int fx_gm, fy_gm, sx_gm, sy_gm;//（fx，fy）第一条直线向量值，fx_gm=x1_gm-x2_gm,fy_gm=y1_gm-y2_gm;
        int x1_gm, x2_gm, x3_gm, x4_gm;//（sx，sy）第二条直线向量值，sx_gm=x3_gm-x4_gm,sy_gm=y3_gm-y4_gm;
        int y1_gm, y2_gm, y3_gm, y4_gm;
        double gama;//γ角
        bool pick_gama = false;//γ角计算允许选择点标识

        //计算β角，首先得计算出圆心坐标
        //计算圆心变量
        int mDcount_cir;//点选择次数
        int x0_cir, x1_cir, x2_cir, x3_cir;//(x0,y0)圆心点，（x1，y1）（x2，y2）（x3，y3）为选取的三点
        int y0_cir, y1_cir, y2_cir, y3_cir;
        double m1, m2, m3;
        double rad;//半径
        bool pick_cir = false;//圆心计算允许选择点标识
        //计算β角变量
        int mDcount_beta;//点选择次数
        int fx_bt, fy_bt, sx_bt, sy_bt;
        int x1_bt, x2_bt;//选择的两个点分别为左右两个切槽最上方的点，即直角点
        int y1_bt, y2_bt;
        bool pick_beta = false;//β角计算允许选择点标识
        double beta;//β角

        public DataMeasurement(Bitmap bt,string op,string se,string dt)
        {
            InitializeComponent();

            if (bt != null)
            {
                Image<Bgr, Byte> img1 = new Image<Bgr, byte>(bt);
                imageBox1.Image = img1;
                p1 = img1;
            }

            oper = op;
            serial = se;
            datetime = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strFileName = string.Empty;
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image<Bgr, Byte> img1 = new Image<Bgr, Byte>(ofd.FileName);
                p1 = img1;
                imageBox1.Image = p1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Convert the img1 to grayscale and then filter out the noise    
            Image<Gray, Byte> gray1 = p1.Convert<Gray, Byte>().PyrDown().PyrUp();

            //Canny Edge Detector  
            cannyGray = gray1.Canny(Convert.ToInt16(tB_HTh.Text), Convert.ToInt16(tB_LTh.Text));
            imageBox1.Image = cannyGray;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            imageBox1.Image = p1;
        }

        private void bn_Pick_Click(object sender, EventArgs e)
        {
            pick_gama = true;//γ角计算允许选择四个点
            pick_cir = false;
            pick_beta = false;
            mDcount_gama = 0;//第一个点开始选择
        }

        private void bn_RePick_Click(object sender, EventArgs e)
        {
            pick_gama = true;//γ角计算重新选择四个点
            pick_cir = false;
            pick_beta = false;
            mDcount_gama = 0;//第一个点开始选择
        }

        private void bn_cirPick_Click(object sender, EventArgs e)
        {
            pick_cir = true;//圆心计算允许选择三个点
            pick_gama = false;
            pick_beta = false;
            mDcount_cir = 0;//第一个点开始选择
        }

        private void bn_cirRePick_Click(object sender, EventArgs e)
        {
            pick_cir = true;//圆心计算重新选择三个点
            pick_gama = false;
            pick_beta = false;
            mDcount_cir = 0;//第一个点开始选择
        }

        private void bn_betaPick_Click(object sender, EventArgs e)
        {
            pick_beta = true;//β角计算允许选择三个点
            pick_cir = false;
            pick_gama = false;
            mDcount_beta = 0;//第一个点开始选择
        }

        private void bn_betaRePick_Click(object sender, EventArgs e)
        {
            pick_beta = true;//β角计算重新选择三个点
            pick_cir = false;
            pick_gama = false;
            mDcount_beta = 0;//第一个点开始选择
        }

        private void imageBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int ex, ey;
            ex = (int)(e.X * coe);
            ey = (int)(e.Y * coe);

            if (imageBox1.Image != null)
            {
                //γ角计算点选择
                if (pick_gama == true)
                {
                    int deltn_gm = 0;//因图像原因，无法一次性选中所需点，因此左右寻找最近的目标点，deltn_gm为偏移量

                    if (mDcount_gama == 0)//选择第一点
                    {
                        //while循环，直到找到选择附近的目标点
                        while ((cannyGray[ey, ex + deltn_gm].Intensity != 255) && (cannyGray[ey, ex - deltn_gm].Intensity != 255))
                        {
                            deltn_gm++;
                        }
                        if (cannyGray[ey, ex + deltn_gm].Intensity == 255)
                        {
                            lb_FPoint.Text = "[" + ey.ToString() + "," + (ex + deltn_gm).ToString() + "]";
                            mDcount_gama++;
                            x1_gm = ex + deltn_gm;
                            y1_gm = ey;
                        }
                        else if (cannyGray[ey, ex - deltn_gm].Intensity == 255)
                        {
                            lb_FPoint.Text = "[" + ey.ToString() + "," + (ex - deltn_gm).ToString() + "]";
                            mDcount_gama++;
                            x1_gm = ex - deltn_gm;
                            y1_gm = ey;
                        }
                    }
                    else if (mDcount_gama == 1)//选择第二点
                    {
                        //while循环，直到找到选择附近的目标点
                        while ((cannyGray[ey, ex + deltn_gm].Intensity != 255) && (cannyGray[ey, ex - deltn_gm].Intensity != 255))
                        {
                            deltn_gm++;
                        }
                        if (cannyGray[ey, ex + deltn_gm].Intensity == 255)
                        {
                            lb_SPoint.Text = "[" + ey.ToString() + "," + (ex + deltn_gm).ToString() + "]";
                            mDcount_gama++;
                            x2_gm = ex + deltn_gm;
                            y2_gm = ey;
                        }
                        else if (cannyGray[ey, ex - deltn_gm].Intensity == 255)
                        {
                            lb_SPoint.Text = "[" + ey.ToString() + "," + (ex - deltn_gm).ToString() + "]";
                            mDcount_gama++;
                            x2_gm = ex - deltn_gm;
                            y2_gm = ey;
                        }
                    }
                    else if (mDcount_gama == 2)//选择第三点
                    {
                        //while循环，直到找到选择附近的目标点
                        while ((cannyGray[ey, ex + deltn_gm].Intensity != 255) && (cannyGray[ey, ex - deltn_gm].Intensity != 255))
                        {
                            deltn_gm++;
                        }
                        if (cannyGray[ey, ex + deltn_gm].Intensity == 255)
                        {
                            lb_TPoint.Text = "[" + ey.ToString() + "," + (ex + deltn_gm).ToString() + "]";
                            mDcount_gama++;
                            x3_gm = ex + deltn_gm;
                            y3_gm = ey;
                        }
                        else if (cannyGray[ey, ex - deltn_gm].Intensity == 255)
                        {
                            lb_TPoint.Text = "[" + ey.ToString() + "," + (ex - deltn_gm).ToString() + "]";
                            mDcount_gama++;
                            x3_gm = ex - deltn_gm;
                            y3_gm = ey;
                        }
                    }
                    else if (mDcount_gama == 3)//选择第四点
                    {
                        //while循环，直到找到选择附近的目标点
                        while ((cannyGray[ey, ex + deltn_gm].Intensity != 255) && (cannyGray[ey, ex - deltn_gm].Intensity != 255))
                        {
                            deltn_gm++;
                        }
                        if (cannyGray[ey, ex + deltn_gm].Intensity == 255)
                        {
                            lb_FoPoint.Text = "[" + ey.ToString() + "," + (ex + deltn_gm).ToString() + "]";
                            mDcount_gama++;
                            x4_gm = ex + deltn_gm;
                            y4_gm = ey;
                        }
                        else if (cannyGray[ey, ex - deltn_gm].Intensity == 255)
                        {
                            lb_FoPoint.Text = "[" + ey.ToString() + "," + (ex - deltn_gm).ToString() + "]";
                            mDcount_gama++;
                            x4_gm = ex - deltn_gm;
                            y4_gm = ey;
                        }
                    }
                    if (mDcount_gama == 4)
                    {
                        fx_gm = x1_gm - x2_gm; fy_gm = y1_gm - y2_gm;
                        sx_gm = x3_gm - x4_gm; sy_gm = y3_gm - y4_gm;
                        gama = Math.Acos((fx_gm * sx_gm + fy_gm * sy_gm) / Math.Sqrt(fx_gm * fx_gm + fy_gm * fy_gm) / Math.Sqrt(sx_gm * sx_gm + sy_gm * sy_gm)) * 180 / Math.PI;
                        //if ((90 - gama) < gama) gama = 90 - gama;
                        lb_Gama.Text = gama.ToString("F3");
                        pick_gama = false;//已经选择完四个点，不能再选择
                    }
                }

                //圆心计算点选择
                //计算圆心坐标原理，选取三点，三点到圆心的距离均为半径，三个方程联立可求得圆心坐标及半径
                if (pick_cir == true)
                {
                    int deltn_cir = 0;//因图像原因，无法一次性选中所需点，因此左右寻找最近的目标点，deltn_cir为偏移量

                    if (mDcount_cir == 0)//选择第一点
                    {
                        //while循环，直到找到选择附近的目标点
                        while ((cannyGray[ey, ex + deltn_cir].Intensity != 255) && (cannyGray[ey, ex - deltn_cir].Intensity != 255))
                        {
                            deltn_cir++;
                        }
                        if (cannyGray[ey, ex + deltn_cir].Intensity == 255)
                        {
                            lb_Fcir.Text = "[" + ey.ToString() + "," + (ex + deltn_cir).ToString() + "]";
                            mDcount_cir++;
                            x1_cir = ex + deltn_cir;
                            y1_cir = ey;
                        }
                        else if (cannyGray[ey, ex - deltn_cir].Intensity == 255)
                        {
                            lb_Fcir.Text = "[" + ey.ToString() + "," + (ex - deltn_cir).ToString() + "]";
                            mDcount_cir++;
                            x1_cir = ex - deltn_cir;
                            y1_cir = ey;
                        }
                    }
                    else if (mDcount_cir == 1)//选择第二点
                    {
                        //while循环，直到找到选择附近的目标点
                        while ((cannyGray[ey, ex + deltn_cir].Intensity != 255) && (cannyGray[ey, ex - deltn_cir].Intensity != 255))
                        {
                            deltn_cir++;
                        }
                        if (cannyGray[ey, ex + deltn_cir].Intensity == 255)
                        {
                            lb_Scir.Text = "[" + ey.ToString() + "," + (ex + deltn_cir).ToString() + "]";
                            mDcount_cir++;
                            x2_cir = ex + deltn_cir;
                            y2_cir = ey;
                        }
                        else if (cannyGray[ey, ex - deltn_cir].Intensity == 255)
                        {
                            lb_Scir.Text = "[" + ey.ToString() + "," + (ex - deltn_cir).ToString() + "]";
                            mDcount_cir++;
                            x2_cir = ex - deltn_cir;
                            y2_cir = ey;
                        }
                    }
                    else if (mDcount_cir == 2)//选择第三点
                    {
                        //while循环，直到找到选择附近的目标点
                        while ((cannyGray[ey, ex + deltn_cir].Intensity != 255) && (cannyGray[ey, ex - deltn_cir].Intensity != 255))
                        {
                            deltn_cir++;
                        }
                        if (cannyGray[ey, ex + deltn_cir].Intensity == 255)
                        {
                            lb_Tcir.Text = "[" + ey.ToString() + "," + (ex + deltn_cir).ToString() + "]";
                            mDcount_cir++;
                            x3_cir = ex + deltn_cir;
                            y3_cir = ey;
                        }
                        else if (cannyGray[ey, ex - deltn_cir].Intensity == 255)
                        {
                            lb_Tcir.Text = "[" + ey.ToString() + "," + (ex - deltn_cir).ToString() + "]";
                            mDcount_cir++;
                            x3_cir = ex - deltn_cir;
                            y3_cir = ey;
                        }
                    }

                    if (mDcount_cir == 3)
                    {
                        m1 = (x1_cir * x1_cir + y1_cir * y1_cir - x3_cir * x3_cir - y3_cir * y3_cir) * (y2_cir - y1_cir) - (x1_cir * x1_cir + y1_cir * y1_cir - x2_cir * x2_cir - y2_cir * y2_cir) * (y3_cir - y1_cir);
                        m2 = (x1_cir * x1_cir + y1_cir * y1_cir - x2_cir * x2_cir - y2_cir * y2_cir) * (x3_cir - x1_cir) - (x1_cir * x1_cir + y1_cir * y1_cir - x3_cir * x3_cir - y3_cir * y3_cir) * (x2_cir - x1_cir);
                        m3 = 2 * (x2_cir - x1_cir) * (y3_cir - y1_cir) - 2 * (x3_cir - x1_cir) * (y2_cir - y1_cir);
                        x0_cir = Convert.ToInt16(m1 / m3);
                        y0_cir = Convert.ToInt16(m2 / m3);
                        rad = Math.Sqrt((x0_cir - x1_cir) * (x0_cir - x1_cir) + (y0_cir - y1_cir) * (y0_cir - y1_cir));
                        lb_Ciro.Text = "[" + x0_cir.ToString() + "," + y0_cir.ToString() + "]";//圆心坐标，该坐标为ImageBox控件中的坐标
                        lb_Rad.Text = rad.ToString("F3");
                        pick_cir = false;//已经选择完三个点，不能再选择

                        //画出圆心
                        CircleF cf = new CircleF(new PointF(x0_cir, y0_cir), 2);
                        //Gray gy=new Gray(255);
                        cannyGray.Draw(cf, new Gray(255), 1, LineType.EightConnected, 0);
                        imageBox1.Image = cannyGray;
                    }
                }

                //β角计算点选择
                if ((pick_beta == true) && (mDcount_cir == 3))//必须在计算圆心之后才能选择
                {
                    int deltn_beta = 0;//因图像原因，无法一次性选中所需点，因此左右寻找最近的目标点，deltn_cir为偏移量

                    if (mDcount_beta == 0)//选择第一点
                    {
                        //while循环，直到找到选择附近的目标点
                        while ((cannyGray[ey, ex + deltn_beta].Intensity != 255) && (cannyGray[ey, ex - deltn_beta].Intensity != 255))
                        {
                            deltn_beta++;
                        }
                        if (cannyGray[ey, ex + deltn_beta].Intensity == 255)
                        {
                            lb_Fbt.Text = "[" + ey.ToString() + "," + (ex + deltn_beta).ToString() + "]";
                            mDcount_beta++;
                            x1_bt = ex + deltn_beta;
                            y1_bt = ey;
                        }
                        else if (cannyGray[ey, ex - deltn_beta].Intensity == 255)
                        {
                            lb_Fbt.Text = "[" + ey.ToString() + "," + (ex - deltn_beta).ToString() + "]";
                            mDcount_beta++;
                            x1_bt = ex - deltn_beta;
                            y1_bt = ey;
                        }
                    }
                    else if (mDcount_beta == 1)//选择第二点
                    {
                        //while循环，直到找到选择附近的目标点
                        while ((cannyGray[ey, ex + deltn_beta].Intensity != 255) && (cannyGray[ey, ex - deltn_beta].Intensity != 255))
                        {
                            deltn_beta++;
                        }
                        if (cannyGray[ey, ex + deltn_beta].Intensity == 255)
                        {
                            lb_Sbt.Text = "[" + ey.ToString() + "," + (ex + deltn_beta).ToString() + "]";
                            mDcount_beta++;
                            x2_bt = ex + deltn_beta;
                            y2_bt = ey;
                        }
                        else if (cannyGray[ey, ex - deltn_beta].Intensity == 255)
                        {
                            lb_Sbt.Text = "[" + ey.ToString() + "," + (ex - deltn_beta).ToString() + "]";
                            mDcount_beta++;
                            x2_bt = ex - deltn_beta;
                            y2_bt = ey;
                        }
                    }

                    if (mDcount_beta == 2)
                    {
                        //第一条直线向量（fx_bt，fy_bt）
                        fx_bt = x1_bt - x0_cir;
                        fy_bt = y1_bt - y0_cir;
                        //第二条直线向量（sx_bt，sy_bt）
                        sx_bt = x2_bt - x0_cir;
                        sy_bt = y2_bt - y0_cir;
                        beta = Math.Acos((fx_bt * sx_bt + fy_bt * sy_bt) / Math.Sqrt(fx_bt * fx_bt + fy_bt * fy_bt) / Math.Sqrt(sx_bt * sx_bt + sy_bt * sy_bt)) * 180 / Math.PI;
                        //if ((90 - beta) < beta) beta = 90 - beta;
                        lb_Beta.Text = beta.ToString("F3");
                        pick_beta = false;//已经选择完四个点，不能再选择
                    }
                }
            }
            else
            {
                MessageBox.Show("请先选择图片!", "提示");
            }
        }

        //保存数据
        private void button4_Click(object sender, EventArgs e)
        {
            //获得数据库中数据数量，并修改为新增数据编号
            int count;
            string strsql = "select count(*) from tractionwheel";
            ds = dataoperate.getComDs(strsql,"tractionwheel","tb");
            
            count = (int)ds.Tables["tb"].Rows.Count + 1;

            //从数据表datatemp中获得测量数据的平均值
            strsql = "select * from datatemp where [No]='average'";
            ds = dataoperate.getComDs(strsql, "datatemp", "tb");
            string gm = ds.Tables["tb"].Rows[0]["gama"].ToString();
            string bet = ds.Tables["tb"].Rows[0]["beta"].ToString();
            string rad = ds.Tables["tb"].Rows[0]["radius"].ToString();

            //设置保存图片的名称，原图，边缘检测后图片
            string pico = serial;
            string picde = serial + "dec";

            //将数据插入数据表中
            strsql = "insert into tractionwheel ([No],[serial],[gama],[beta],[radius],[strpicOrign],[strpicdetected],[oper],[opdate])"
            + "values (" + count.ToString() + ",'" + serial + "','" + gm + "','" + bet + "','" + rad + "','"
            + serial + "','" + picde + "','" + oper + "','" + datetime + "')";
            dataoperate.getCom(strsql);

            //保存图片，原图和边缘检测后图片分别保存，图片名称为曳引机或轮的出厂编号
            if ((p1 != null) && (cannyGray != null))
            {
                if (File.Exists(@"..\..\picfile\" + pico + ".png") || File.Exists(@"..\..\picfile\" + picde + ".png"))
                {
                    if (MessageBox.Show("图片已存在，确认覆盖吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        p1.Save(@"..\..\picfile\" + pico + ".png");
                        cannyGray.Save(@"..\..\picfile\" + picde + ".png");
                    }
                }
                MessageBox.Show("保存成功！", "提示");
            }
            else
            {
                MessageBox.Show("数据已保存，无图片保存！", "提示");
            }   
        }

        private void DataMeasurement_Load(object sender, EventArgs e)
        {
            string strsql = "select * from datatemp ";
            ds = dataoperate.getDs(strsql, "tb");
            dataGridView1.DataSource = ds.Tables["tb"];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (groupBox3.Text != "第N次测量")
            {
                string strsql = "update datatemp set [gama]=" + lb_Gama.Text + ",[beta]=" + lb_Beta.Text + ",[radius]=" + lb_Rad.Text + " where [No]='" + cout + "'";
                dataoperate.getCom(strsql);
                strsql = "update datatemp set [gama]=(select avg(gama) from datatemp where [No]<>'average'),[beta]=(select avg(beta) from datatemp where [No]<>'average'),[radius]=(select avg(radius) from datatemp where [No]<>'average') where [No]='average'";
                ds = dataoperate.getComDs(strsql, "datatemp", "tb");
                dataGridView1.DataSource = ds.Tables["tb"];
            }
            else
            {
                MessageBox.Show("请先新增测量!", "提示");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string strsql = "select count(*) from datatemp";
            ds = dataoperate.getDs(strsql, "temp");
            cout = ds.Tables["temp"].Rows[0][0].ToString();
            groupBox3.Text = "第" + cout + "次测量";
            strsql = "insert into datatemp ([No],[gama],[beta],[radius]) values (" + cout + "," + "' ',' ',' ')";
            ds = dataoperate.getComDs(strsql, "datatemp", "tb");
            dataGridView1.DataSource = ds.Tables["tb"];

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string strsql = "delete from datatemp where [No]<>'average'";
            dataoperate.getCom(strsql);
            strsql = "update datatemp set [gama]='',[beta]='',[radius]='' where [No]='average'";
            dataoperate.getCom(strsql);
            strsql = "select * from datatemp ";
            ds = dataoperate.getDs(strsql, "tb");
            dataGridView1.DataSource = ds.Tables["tb"];
        }
    }
}
