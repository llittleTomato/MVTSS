using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.CV.CvEnum;

namespace MainProject
{
    public partial class PictureProcess : Form
    {
        Boolean flagdraw;
        Point startpoint;
        Point wh;
        Graphics gg;
        Rectangle currRect, toRect;
        int width;
        double coe;
        Bitmap bt;
        string picAdd;

        public PictureProcess(Bitmap bbt)
        {
            InitializeComponent();

            //所需要的图像大小
            wh.X = 240;
            wh.Y = 180;

            flagdraw = false;//图像裁剪选择框显示默认关闭，即不显示

            gg = pictureBox1.CreateGraphics();//为picturebox1创建graphic

            

            if (bbt != null)
            {
                pictureBox1.Image = bbt;
                width = bbt.Width;
                coe = pictureBox1.Width * 1.0 / width;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image<Bgr, Byte> img1 = new Image<Bgr, Byte>(ofd.FileName);
                pictureBox1.Image = img1.ToBitmap();
                width = img1.Width;
                //height = img1.Height;
                coe = pictureBox1.Width * 1.0 / width;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            flagdraw = true;
            button4.Text = "重新选择区域";
        }
       
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            flagdraw = false;
            gg.DrawRectangle(System.Drawing.Pens.Red, currRect);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (flagdraw == true)
            {
                pictureBox1.Refresh();

                startpoint.X = MousePosition.X - pictureBox1.Location.X - wh.X / 2;
                startpoint.Y = MousePosition.Y - 50 - pictureBox1.Location.Y - wh.Y / 2;

                currRect = new Rectangle(startpoint.X, startpoint.Y, wh.X, wh.Y);//选择框的坐标
                toRect = new Rectangle((int)(startpoint.X/coe),(int)(startpoint.Y/coe),(int)(wh.X/coe),(int)(wh.Y/coe));
                gg.DrawRectangle(System.Drawing.Pens.Red, currRect);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bt = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            Graphics cutgp = Graphics.FromImage(bt);
            cutgp.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            cutgp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cutgp.DrawImage(pictureBox1.Image, new System.Drawing.Rectangle(0, 0, pictureBox2.Width, pictureBox2.Height), toRect, System.Drawing.GraphicsUnit.Pixel);
            pictureBox2.Image = bt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != "") && (dateTimePicker1.Text != ""))
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "png图片(*.png)|*.png";
                if (pictureBox2.Image != null)
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox2.Image.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        picAdd = sfd.FileName;
                    }
                }
            }
            else
            {
                MessageBox.Show("请输入完整基础信息后保存图片");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != "") && (dateTimePicker1.Text != ""))
            {
                //跳转到测量界面
                DataMeasurement dm = new DataMeasurement(bt, textBox1.Text, textBox2.Text, dateTimePicker1.Text);
                dm.TopLevel = false;
                dm.Dock = System.Windows.Forms.DockStyle.Fill;
                dm.FormBorderStyle = FormBorderStyle.None;
                this.Parent.Controls.Add(dm);
                dm.Show();
            }
            else
            {
                //跳转到基础数据录入界面
                basicDataInput dmm = new basicDataInput(bt);
                dmm.TopLevel = false;
                dmm.Dock = System.Windows.Forms.DockStyle.Fill;
                dmm.FormBorderStyle = FormBorderStyle.None;
                this.Parent.Controls.Add(dmm);
                this.Dispose();
                dmm.Show();
            }
            
        }
    }
}
