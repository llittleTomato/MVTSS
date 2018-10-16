namespace MainProject
{
    partial class Default
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开图片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开测量文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.采集照片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图像处理toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据测量ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlmain = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.pnlmain.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.采集照片ToolStripMenuItem,
            this.图像处理toolStripMenuItem,
            this.数据测量ToolStripMenuItem,
            this.数据管理ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(783, 25);
            this.menuStrip1.TabIndex = 0;
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开图片ToolStripMenuItem,
            this.打开测量文件ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开图片ToolStripMenuItem
            // 
            this.打开图片ToolStripMenuItem.Name = "打开图片ToolStripMenuItem";
            this.打开图片ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.打开图片ToolStripMenuItem.Text = "打开原始图片";
            this.打开图片ToolStripMenuItem.Click += new System.EventHandler(this.打开原始图片ToolStripMenuItem_Click);
            // 
            // 打开测量文件ToolStripMenuItem
            // 
            this.打开测量文件ToolStripMenuItem.Name = "打开测量文件ToolStripMenuItem";
            this.打开测量文件ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.打开测量文件ToolStripMenuItem.Text = "打开测量文件";
            this.打开测量文件ToolStripMenuItem.Click += new System.EventHandler(this.打开测量文件ToolStripMenuItem_Click);
            // 
            // 采集照片ToolStripMenuItem
            // 
            this.采集照片ToolStripMenuItem.Name = "采集照片ToolStripMenuItem";
            this.采集照片ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.采集照片ToolStripMenuItem.Text = "采集照片";
            this.采集照片ToolStripMenuItem.Click += new System.EventHandler(this.采集照片ToolStripMenuItem_Click);
            // 
            // 图像处理toolStripMenuItem
            // 
            this.图像处理toolStripMenuItem.Name = "图像处理toolStripMenuItem";
            this.图像处理toolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.图像处理toolStripMenuItem.Text = "图像处理";
            this.图像处理toolStripMenuItem.Click += new System.EventHandler(this.图像处理toolStripMenuItem_Click);
            // 
            // 数据测量ToolStripMenuItem
            // 
            this.数据测量ToolStripMenuItem.Name = "数据测量ToolStripMenuItem";
            this.数据测量ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.数据测量ToolStripMenuItem.Text = "数据测量";
            this.数据测量ToolStripMenuItem.Click += new System.EventHandler(this.数据测量ToolStripMenuItem_Click);
            // 
            // 数据管理ToolStripMenuItem
            // 
            this.数据管理ToolStripMenuItem.Name = "数据管理ToolStripMenuItem";
            this.数据管理ToolStripMenuItem.Size = new System.Drawing.Size(72, 21);
            this.数据管理ToolStripMenuItem.Text = " 数据管理";
            this.数据管理ToolStripMenuItem.Click += new System.EventHandler(this.数据管理ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // pnlmain
            // 
            this.pnlmain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlmain.Controls.Add(this.label2);
            this.pnlmain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlmain.Location = new System.Drawing.Point(0, 25);
            this.pnlmain.Name = "pnlmain";
            this.pnlmain.Size = new System.Drawing.Size(783, 370);
            this.pnlmain.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(124, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(540, 35);
            this.label2.TabIndex = 0;
            this.label2.Text = "欢迎使用曳引轮绳槽参数测量系统";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 395);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(783, 33);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(365, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "版权所有：宁波市特种设备检验研究院              开发：施科益";
            // 
            // Default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 428);
            this.Controls.Add(this.pnlmain);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel2);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Default";
            this.Text = "曳引轮绳槽参数测量系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlmain.ResumeLayout(false);
            this.pnlmain.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 采集照片ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据测量ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据管理ToolStripMenuItem;
        private System.Windows.Forms.Panel pnlmain;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 打开图片ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开测量文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图像处理toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
    }
}