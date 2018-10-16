using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainProject
{
    public partial class basicDataInput : Form
    {
        Bitmap picbt;
        public basicDataInput(Bitmap bt)
        {
            InitializeComponent();
            picbt = bt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //跳转到测量界面
            DataMeasurement dm = new DataMeasurement(picbt, textBox1.Text, textBox2.Text, dateTimePicker1.Text);
            dm.TopLevel = false;
            dm.Dock = System.Windows.Forms.DockStyle.Fill;
            dm.FormBorderStyle = FormBorderStyle.None;
            this.Parent.Controls.Add(dm);
            dm.Show();
        }
    }
}
