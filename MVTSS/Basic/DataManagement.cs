using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MainProject
{
    public partial class DataManagement : Form
    {
        DataOperate dataoperate = new DataOperate();
        DataSet ds = new DataSet();

        public DataManagement()
        {
            InitializeComponent();
        }

        private void DataManagement_Load(object sender, EventArgs e)
        {
            updategridview();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string strsql;

            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex > -1)
            {
                //打开按钮动作
                if (dataGridView1.Columns[e.ColumnIndex].Name.ToString() == "open")
                {
                    textBox4.Text = dataGridView1["No", e.RowIndex].Value.ToString().TrimEnd();//序号
                    textBox1.Text = dataGridView1["oper", e.RowIndex].Value.ToString().TrimEnd();//检测人员
                    textBox2.Text = dataGridView1["serial", e.RowIndex].Value.ToString().TrimEnd();//编号
                    textBox3.Text = dataGridView1["opdate", e.RowIndex].Value.ToString().TrimEnd();//测量时间

                    lb_Gama.Text = "[" + dataGridView1["gama", e.RowIndex].Value.ToString().TrimEnd() + "]/°";
                    lb_Beta.Text = "[" + dataGridView1["beta", e.RowIndex].Value.ToString().TrimEnd() + "]/°";
                    lb_Rad.Text = "[" + dataGridView1["radius", e.RowIndex].Value.ToString().TrimEnd() + "]/像素";

                    if (File.Exists(@"..\..\picfile\" + textBox2.Text + ".png"))
                    {
                        pictureBox1.Image = Image.FromFile(@"..\..\picfile\" + textBox2.Text + ".png");
                    }
                    else
                    {
                        MessageBox.Show("原图未保存!","提示");
                    }

                    if (File.Exists(@"..\..\picfile\" + textBox2.Text + "dec.png"))
                    {
                        pictureBox2.Image = Image.FromFile(@"..\..\picfile\" + textBox2.Text + "dec.png");
                    }
                    else
                    {
                        MessageBox.Show("检测图未保存!", "提示");
                    }

                    //加载标绳槽图
                    pictureBox3.Image = Image.FromFile(@"..\..\picfile\standard1.png");
                    pictureBox4.Image = Image.FromFile(@"..\..\picfile\standard2.png");

                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name.ToString() == "delete")//删除按钮动作
                {
                    if (MessageBox.Show("确认删除吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        int count;//显示的数据总条数
                        int current;//删除的数据的编号No值

                        //删除数据表内数据
                        strsql = "delete from tractionwheel where [No]=" + dataGridView1["No", e.RowIndex].Value.ToString().TrimEnd();
                        dataoperate.getCom(strsql);

                        //将序号重新编排,将current后面数据的编号No值均减少一位
                        count = dataGridView1.RowCount;
                        current = (int)dataGridView1["No", e.RowIndex].Value;
                        for (int i = current + 1; i <= count; i++)
                        {
                            strsql = "update tractionwheel set [No]=" + (i - 1).ToString() + " where [No]=" + i.ToString();
                            dataoperate.getCom(strsql);
                        }

                        //删除图片
                        if (File.Exists(@"..\..\picfile\" + textBox2.Text + ".png"))
                        {
                            File.Delete(@"..\..\picfile\" + textBox2.Text + ".png");
                        }
                        if (File.Exists(@"..\..\picfile\" + textBox2.Text + "dec.png"))
                        {
                            File.Delete(@"..\..\picfile\" + textBox2.Text + "dec.png");
                        }
                        
                        //更新表格
                        updategridview();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strsql = "select * from tractionwheel where [No]<>" + textBox4.Text.TrimEnd() + " and [serial]='" + textBox2.Text.TrimEnd() + "'";
            ds = dataoperate.getDs(strsql, "tb");
            if (ds.Tables["tb"].Rows.Count != 0)
            {
                MessageBox.Show("曳引机/轮出厂编号重复，请重新修改！", "提示");
            }
            else
            {
                strsql = "update tractionwheel set [serial]='" + textBox2.Text.TrimEnd() + "',[oper]='" + textBox1.Text.TrimEnd() + "',[opdate]='"
                    + textBox3.Text.TrimEnd() + "' where [No]=" + textBox4.Text.TrimEnd();
                dataoperate.getCom(strsql);

                //更新表格
                updategridview();

                MessageBox.Show("更新成功!", "提示");
            }
        }

        void updategridview()
        {
            //更新表格
            string strsql = "select * from tractionwheel order by [No]";
            ds = dataoperate.getDs(strsql, "tb");
            dataGridView1.DataSource = ds.Tables["tb"];
        }
    }
}
