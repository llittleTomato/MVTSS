namespace MainProject
{
    partial class DataMeasurement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tB_HTh = new System.Windows.Forms.TextBox();
            this.tB_LTh = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bn_betaRePick = new System.Windows.Forms.Button();
            this.bn_cirRePick = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.bn_betaPick = new System.Windows.Forms.Button();
            this.bn_cirPick = new System.Windows.Forms.Button();
            this.lb_Rad = new System.Windows.Forms.Label();
            this.lb_Ciro = new System.Windows.Forms.Label();
            this.lb_Beta = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lb_Tcir = new System.Windows.Forms.Label();
            this.lb_Scir = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lb_Sbt = new System.Windows.Forms.Label();
            this.lb_Fbt = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lb_Fcir = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bn_RePick = new System.Windows.Forms.Button();
            this.bn_Pick = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lb_Gama = new System.Windows.Forms.Label();
            this.lb_FoPoint = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lb_TPoint = new System.Windows.Forms.Label();
            this.lb_SPoint = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lb_FPoint = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(52, 479);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 30);
            this.button1.TabIndex = 4;
            this.button1.Text = "选择图片";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Location = new System.Drawing.Point(412, 479);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 30);
            this.button2.TabIndex = 4;
            this.button2.Text = "边缘提取";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tB_HTh
            // 
            this.tB_HTh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tB_HTh.Location = new System.Drawing.Point(176, 484);
            this.tB_HTh.Name = "tB_HTh";
            this.tB_HTh.Size = new System.Drawing.Size(77, 21);
            this.tB_HTh.TabIndex = 5;
            this.tB_HTh.Text = "10";
            // 
            // tB_LTh
            // 
            this.tB_LTh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tB_LTh.Location = new System.Drawing.Point(294, 484);
            this.tB_LTh.Name = "tB_LTh";
            this.tB_LTh.Size = new System.Drawing.Size(77, 21);
            this.tB_LTh.TabIndex = 5;
            this.tB_LTh.Text = "100";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.bn_betaRePick);
            this.groupBox2.Controls.Add(this.bn_cirRePick);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.bn_betaPick);
            this.groupBox2.Controls.Add(this.bn_cirPick);
            this.groupBox2.Controls.Add(this.lb_Rad);
            this.groupBox2.Controls.Add(this.lb_Ciro);
            this.groupBox2.Controls.Add(this.lb_Beta);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.lb_Tcir);
            this.groupBox2.Controls.Add(this.lb_Scir);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.lb_Sbt);
            this.groupBox2.Controls.Add(this.lb_Fbt);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.lb_Fcir);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(10, 189);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(255, 251);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "β角计算";
            // 
            // bn_betaRePick
            // 
            this.bn_betaRePick.Location = new System.Drawing.Point(144, 164);
            this.bn_betaRePick.Name = "bn_betaRePick";
            this.bn_betaRePick.Size = new System.Drawing.Size(75, 23);
            this.bn_betaRePick.TabIndex = 10;
            this.bn_betaRePick.Text = "重新选择";
            this.bn_betaRePick.UseVisualStyleBackColor = true;
            this.bn_betaRePick.Click += new System.EventHandler(this.bn_betaRePick_Click);
            // 
            // bn_cirRePick
            // 
            this.bn_cirRePick.Location = new System.Drawing.Point(144, 36);
            this.bn_cirRePick.Name = "bn_cirRePick";
            this.bn_cirRePick.Size = new System.Drawing.Size(75, 23);
            this.bn_cirRePick.TabIndex = 10;
            this.bn_cirRePick.Text = "重新选择";
            this.bn_cirRePick.UseVisualStyleBackColor = true;
            this.bn_cirRePick.Click += new System.EventHandler(this.bn_cirRePick_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(73, 230);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "β角";
            // 
            // bn_betaPick
            // 
            this.bn_betaPick.Location = new System.Drawing.Point(39, 164);
            this.bn_betaPick.Name = "bn_betaPick";
            this.bn_betaPick.Size = new System.Drawing.Size(75, 23);
            this.bn_betaPick.TabIndex = 10;
            this.bn_betaPick.Text = "选择点";
            this.bn_betaPick.UseVisualStyleBackColor = true;
            this.bn_betaPick.Click += new System.EventHandler(this.bn_betaPick_Click);
            // 
            // bn_cirPick
            // 
            this.bn_cirPick.Location = new System.Drawing.Point(36, 36);
            this.bn_cirPick.Name = "bn_cirPick";
            this.bn_cirPick.Size = new System.Drawing.Size(75, 23);
            this.bn_cirPick.TabIndex = 10;
            this.bn_cirPick.Text = "选择点";
            this.bn_cirPick.UseVisualStyleBackColor = true;
            this.bn_cirPick.Click += new System.EventHandler(this.bn_cirPick_Click);
            // 
            // lb_Rad
            // 
            this.lb_Rad.AutoSize = true;
            this.lb_Rad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_Rad.Location = new System.Drawing.Point(195, 115);
            this.lb_Rad.Name = "lb_Rad";
            this.lb_Rad.Size = new System.Drawing.Size(19, 14);
            this.lb_Rad.TabIndex = 9;
            this.lb_Rad.Text = "10";
            // 
            // lb_Ciro
            // 
            this.lb_Ciro.AutoSize = true;
            this.lb_Ciro.Location = new System.Drawing.Point(85, 115);
            this.lb_Ciro.Name = "lb_Ciro";
            this.lb_Ciro.Size = new System.Drawing.Size(23, 12);
            this.lb_Ciro.TabIndex = 9;
            this.lb_Ciro.Text = "[,]";
            // 
            // lb_Beta
            // 
            this.lb_Beta.AutoSize = true;
            this.lb_Beta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_Beta.Location = new System.Drawing.Point(145, 230);
            this.lb_Beta.Name = "lb_Beta";
            this.lb_Beta.Size = new System.Drawing.Size(19, 14);
            this.lb_Beta.TabIndex = 9;
            this.lb_Beta.Text = "30";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(142, 68);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(47, 12);
            this.label22.TabIndex = 9;
            this.label22.Text = "第二点:";
            // 
            // lb_Tcir
            // 
            this.lb_Tcir.AutoSize = true;
            this.lb_Tcir.Location = new System.Drawing.Point(85, 92);
            this.lb_Tcir.Name = "lb_Tcir";
            this.lb_Tcir.Size = new System.Drawing.Size(23, 12);
            this.lb_Tcir.TabIndex = 9;
            this.lb_Tcir.Text = "[,]";
            // 
            // lb_Scir
            // 
            this.lb_Scir.AutoSize = true;
            this.lb_Scir.Location = new System.Drawing.Point(195, 68);
            this.lb_Scir.Name = "lb_Scir";
            this.lb_Scir.Size = new System.Drawing.Size(23, 12);
            this.lb_Scir.TabIndex = 9;
            this.lb_Scir.Text = "[,]";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(148, 115);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 12);
            this.label14.TabIndex = 9;
            this.label14.Text = "半径:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(38, 115);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 12);
            this.label15.TabIndex = 9;
            this.label15.Text = "圆心:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(32, 92);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 12);
            this.label19.TabIndex = 9;
            this.label19.Text = "第三点:";
            // 
            // lb_Sbt
            // 
            this.lb_Sbt.AutoSize = true;
            this.lb_Sbt.Location = new System.Drawing.Point(205, 198);
            this.lb_Sbt.Name = "lb_Sbt";
            this.lb_Sbt.Size = new System.Drawing.Size(23, 12);
            this.lb_Sbt.TabIndex = 9;
            this.lb_Sbt.Text = "[,]";
            // 
            // lb_Fbt
            // 
            this.lb_Fbt.AutoSize = true;
            this.lb_Fbt.Location = new System.Drawing.Point(91, 198);
            this.lb_Fbt.Name = "lb_Fbt";
            this.lb_Fbt.Size = new System.Drawing.Size(23, 12);
            this.lb_Fbt.TabIndex = 9;
            this.lb_Fbt.Text = "[,]";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(152, 198);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 12);
            this.label20.TabIndex = 9;
            this.label20.Text = "第二点:";
            // 
            // lb_Fcir
            // 
            this.lb_Fcir.AutoSize = true;
            this.lb_Fcir.Location = new System.Drawing.Point(85, 68);
            this.lb_Fcir.Name = "lb_Fcir";
            this.lb_Fcir.Size = new System.Drawing.Size(23, 12);
            this.lb_Fcir.TabIndex = 9;
            this.lb_Fcir.Text = "[,]";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(38, 198);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 12);
            this.label16.TabIndex = 9;
            this.label16.Text = "第一点:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(59, 142);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(125, 12);
            this.label24.TabIndex = 9;
            this.label24.Text = "请选择二个点计算β角";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(59, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 12);
            this.label11.TabIndex = 9;
            this.label11.Text = "请选择三个点计算圆心";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(32, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 12);
            this.label13.TabIndex = 9;
            this.label13.Text = "第一点:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.bn_RePick);
            this.groupBox1.Controls.Add(this.bn_Pick);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lb_Gama);
            this.groupBox1.Controls.Add(this.lb_FoPoint);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lb_TPoint);
            this.groupBox1.Controls.Add(this.lb_SPoint);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lb_FPoint);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(10, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 163);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "γ角计算";
            // 
            // bn_RePick
            // 
            this.bn_RePick.Location = new System.Drawing.Point(144, 40);
            this.bn_RePick.Name = "bn_RePick";
            this.bn_RePick.Size = new System.Drawing.Size(75, 23);
            this.bn_RePick.TabIndex = 10;
            this.bn_RePick.Text = "重新选择";
            this.bn_RePick.UseVisualStyleBackColor = true;
            this.bn_RePick.Click += new System.EventHandler(this.bn_RePick_Click);
            // 
            // bn_Pick
            // 
            this.bn_Pick.Location = new System.Drawing.Point(33, 40);
            this.bn_Pick.Name = "bn_Pick";
            this.bn_Pick.Size = new System.Drawing.Size(75, 23);
            this.bn_Pick.TabIndex = 10;
            this.bn_Pick.Text = "选择点";
            this.bn_Pick.UseVisualStyleBackColor = true;
            this.bn_Pick.Click += new System.EventHandler(this.bn_Pick_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(73, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "γ角";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(142, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 12);
            this.label12.TabIndex = 9;
            this.label12.Text = "第四点:";
            // 
            // lb_Gama
            // 
            this.lb_Gama.AutoSize = true;
            this.lb_Gama.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_Gama.Location = new System.Drawing.Point(145, 137);
            this.lb_Gama.Name = "lb_Gama";
            this.lb_Gama.Size = new System.Drawing.Size(19, 14);
            this.lb_Gama.TabIndex = 9;
            this.lb_Gama.Text = "90";
            // 
            // lb_FoPoint
            // 
            this.lb_FoPoint.AutoSize = true;
            this.lb_FoPoint.Location = new System.Drawing.Point(195, 105);
            this.lb_FoPoint.Name = "lb_FoPoint";
            this.lb_FoPoint.Size = new System.Drawing.Size(23, 12);
            this.lb_FoPoint.TabIndex = 9;
            this.lb_FoPoint.Text = "[,]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(142, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "第二点:";
            // 
            // lb_TPoint
            // 
            this.lb_TPoint.AutoSize = true;
            this.lb_TPoint.Location = new System.Drawing.Point(85, 105);
            this.lb_TPoint.Name = "lb_TPoint";
            this.lb_TPoint.Size = new System.Drawing.Size(23, 12);
            this.lb_TPoint.TabIndex = 9;
            this.lb_TPoint.Text = "[,]";
            // 
            // lb_SPoint
            // 
            this.lb_SPoint.AutoSize = true;
            this.lb_SPoint.Location = new System.Drawing.Point(195, 77);
            this.lb_SPoint.Name = "lb_SPoint";
            this.lb_SPoint.Size = new System.Drawing.Size(23, 12);
            this.lb_SPoint.TabIndex = 9;
            this.lb_SPoint.Text = "[,]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "第三点:";
            // 
            // lb_FPoint
            // 
            this.lb_FPoint.AutoSize = true;
            this.lb_FPoint.Location = new System.Drawing.Point(85, 77);
            this.lb_FPoint.Name = "lb_FPoint";
            this.lb_FPoint.Size = new System.Drawing.Size(23, 12);
            this.lb_FPoint.TabIndex = 9;
            this.lb_FPoint.Text = "[,]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(86, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "请选择四个点";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "第一点:";
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.Location = new System.Drawing.Point(536, 479);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 30);
            this.button3.TabIndex = 4;
            this.button3.Text = "重新载入图片";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // imageBox1
            // 
            this.imageBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imageBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox1.Location = new System.Drawing.Point(43, 12);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(600, 450);
            this.imageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            this.imageBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.imageBox1_MouseClick);
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.Location = new System.Drawing.Point(1115, 474);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(89, 35);
            this.button4.TabIndex = 15;
            this.button4.Text = "保存数据";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button5.Location = new System.Drawing.Point(872, 474);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(89, 35);
            this.button5.TabIndex = 15;
            this.button5.Text = "新增测量";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(936, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(306, 434);
            this.dataGridView1.TabIndex = 16;
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button6.Location = new System.Drawing.Point(995, 474);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(89, 35);
            this.button6.TabIndex = 15;
            this.button6.Text = "记录数据";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Location = new System.Drawing.Point(649, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(277, 449);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "第N次测量";
            // 
            // button7
            // 
            this.button7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button7.Location = new System.Drawing.Point(747, 474);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(89, 35);
            this.button7.TabIndex = 15;
            this.button7.Text = "重置测量";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // DataMeasurement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 551);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.imageBox1);
            this.Controls.Add(this.tB_LTh);
            this.Controls.Add(this.tB_HTh);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Name = "DataMeasurement";
            this.Text = "数据测量窗口";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DataMeasurement_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tB_HTh;
        private System.Windows.Forms.TextBox tB_LTh;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bn_betaRePick;
        private System.Windows.Forms.Button bn_cirRePick;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button bn_betaPick;
        private System.Windows.Forms.Button bn_cirPick;
        private System.Windows.Forms.Label lb_Rad;
        private System.Windows.Forms.Label lb_Ciro;
        private System.Windows.Forms.Label lb_Beta;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lb_Tcir;
        private System.Windows.Forms.Label lb_Scir;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lb_Sbt;
        private System.Windows.Forms.Label lb_Fbt;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lb_Fcir;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bn_RePick;
        private System.Windows.Forms.Button bn_Pick;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lb_Gama;
        private System.Windows.Forms.Label lb_FoPoint;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lb_TPoint;
        private System.Windows.Forms.Label lb_SPoint;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lb_FPoint;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gamaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn betaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn radiusDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button7;
    }
}