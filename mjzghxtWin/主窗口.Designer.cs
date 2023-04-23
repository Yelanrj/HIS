namespace mjzghxtWin
{
    partial class 主窗口
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.病人管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.病人建档ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.病人查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.挂号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.门诊挂号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.急诊挂号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.门诊挂号记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.急诊挂号记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.收费ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.费用查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.急诊挂号收费ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.门诊挂号收费查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.急诊挂号收费查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.病人挂号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.病人门诊挂号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.病人急诊挂号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.病人门诊挂号查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.病人急诊挂号查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.病人缴费ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.病人门诊挂号缴费ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.病人急诊挂号缴费ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.病人门诊挂号缴费查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.病人急诊挂号缴费查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.接诊ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.切换用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_time = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.病人管理ToolStripMenuItem,
            this.挂号ToolStripMenuItem,
            this.收费ToolStripMenuItem,
            this.病人挂号ToolStripMenuItem,
            this.病人缴费ToolStripMenuItem,
            this.接诊ToolStripMenuItem,
            this.切换用户ToolStripMenuItem,
            this.测试ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 病人管理ToolStripMenuItem
            // 
            this.病人管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.病人建档ToolStripMenuItem,
            this.病人查询ToolStripMenuItem});
            this.病人管理ToolStripMenuItem.Name = "病人管理ToolStripMenuItem";
            this.病人管理ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.病人管理ToolStripMenuItem.Text = "病人管理";
            // 
            // 病人建档ToolStripMenuItem
            // 
            this.病人建档ToolStripMenuItem.Name = "病人建档ToolStripMenuItem";
            this.病人建档ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.病人建档ToolStripMenuItem.Text = "病人建档";
            this.病人建档ToolStripMenuItem.Click += new System.EventHandler(this.病人建档ToolStripMenuItem_Click);
            // 
            // 病人查询ToolStripMenuItem
            // 
            this.病人查询ToolStripMenuItem.Name = "病人查询ToolStripMenuItem";
            this.病人查询ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.病人查询ToolStripMenuItem.Text = "病人查询";
            this.病人查询ToolStripMenuItem.Click += new System.EventHandler(this.病人查询ToolStripMenuItem_Click);
            // 
            // 挂号ToolStripMenuItem
            // 
            this.挂号ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.门诊挂号ToolStripMenuItem,
            this.急诊挂号ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.门诊挂号记录ToolStripMenuItem,
            this.急诊挂号记录ToolStripMenuItem});
            this.挂号ToolStripMenuItem.Name = "挂号ToolStripMenuItem";
            this.挂号ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.挂号ToolStripMenuItem.Text = "挂号";
            // 
            // 门诊挂号ToolStripMenuItem
            // 
            this.门诊挂号ToolStripMenuItem.Name = "门诊挂号ToolStripMenuItem";
            this.门诊挂号ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.门诊挂号ToolStripMenuItem.Text = "门诊挂号";
            this.门诊挂号ToolStripMenuItem.Click += new System.EventHandler(this.门诊挂号ToolStripMenuItem_Click);
            // 
            // 急诊挂号ToolStripMenuItem
            // 
            this.急诊挂号ToolStripMenuItem.Name = "急诊挂号ToolStripMenuItem";
            this.急诊挂号ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.急诊挂号ToolStripMenuItem.Text = "急诊挂号";
            this.急诊挂号ToolStripMenuItem.Click += new System.EventHandler(this.急诊挂号ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(179, 6);
            // 
            // 门诊挂号记录ToolStripMenuItem
            // 
            this.门诊挂号记录ToolStripMenuItem.Name = "门诊挂号记录ToolStripMenuItem";
            this.门诊挂号记录ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.门诊挂号记录ToolStripMenuItem.Text = "门诊挂号记录";
            this.门诊挂号记录ToolStripMenuItem.Click += new System.EventHandler(this.门诊挂号记录ToolStripMenuItem_Click);
            // 
            // 急诊挂号记录ToolStripMenuItem
            // 
            this.急诊挂号记录ToolStripMenuItem.Name = "急诊挂号记录ToolStripMenuItem";
            this.急诊挂号记录ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.急诊挂号记录ToolStripMenuItem.Text = "急诊挂号记录";
            this.急诊挂号记录ToolStripMenuItem.Click += new System.EventHandler(this.急诊挂号记录ToolStripMenuItem_Click);
            // 
            // 收费ToolStripMenuItem
            // 
            this.收费ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.费用查询ToolStripMenuItem,
            this.急诊挂号收费ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.门诊挂号收费查询ToolStripMenuItem,
            this.急诊挂号收费查询ToolStripMenuItem});
            this.收费ToolStripMenuItem.Name = "收费ToolStripMenuItem";
            this.收费ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.收费ToolStripMenuItem.Text = "收费";
            // 
            // 费用查询ToolStripMenuItem
            // 
            this.费用查询ToolStripMenuItem.Name = "费用查询ToolStripMenuItem";
            this.费用查询ToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.费用查询ToolStripMenuItem.Text = "门诊挂号收费";
            this.费用查询ToolStripMenuItem.Click += new System.EventHandler(this.费用查询ToolStripMenuItem_Click);
            // 
            // 急诊挂号收费ToolStripMenuItem
            // 
            this.急诊挂号收费ToolStripMenuItem.Name = "急诊挂号收费ToolStripMenuItem";
            this.急诊挂号收费ToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.急诊挂号收费ToolStripMenuItem.Text = "急诊挂号收费";
            this.急诊挂号收费ToolStripMenuItem.Click += new System.EventHandler(this.急诊挂号收费ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(209, 6);
            // 
            // 门诊挂号收费查询ToolStripMenuItem
            // 
            this.门诊挂号收费查询ToolStripMenuItem.Name = "门诊挂号收费查询ToolStripMenuItem";
            this.门诊挂号收费查询ToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.门诊挂号收费查询ToolStripMenuItem.Text = "门诊挂号收费查询";
            this.门诊挂号收费查询ToolStripMenuItem.Click += new System.EventHandler(this.门诊挂号收费查询ToolStripMenuItem_Click);
            // 
            // 急诊挂号收费查询ToolStripMenuItem
            // 
            this.急诊挂号收费查询ToolStripMenuItem.Name = "急诊挂号收费查询ToolStripMenuItem";
            this.急诊挂号收费查询ToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.急诊挂号收费查询ToolStripMenuItem.Text = "急诊挂号收费查询";
            this.急诊挂号收费查询ToolStripMenuItem.Click += new System.EventHandler(this.急诊挂号收费查询ToolStripMenuItem_Click);
            // 
            // 病人挂号ToolStripMenuItem
            // 
            this.病人挂号ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.病人门诊挂号ToolStripMenuItem,
            this.病人急诊挂号ToolStripMenuItem,
            this.toolStripMenuItem3,
            this.病人门诊挂号查询ToolStripMenuItem,
            this.病人急诊挂号查询ToolStripMenuItem});
            this.病人挂号ToolStripMenuItem.Name = "病人挂号ToolStripMenuItem";
            this.病人挂号ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.病人挂号ToolStripMenuItem.Text = "病人挂号";
            // 
            // 病人门诊挂号ToolStripMenuItem
            // 
            this.病人门诊挂号ToolStripMenuItem.Name = "病人门诊挂号ToolStripMenuItem";
            this.病人门诊挂号ToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.病人门诊挂号ToolStripMenuItem.Text = "病人门诊挂号";
            this.病人门诊挂号ToolStripMenuItem.Click += new System.EventHandler(this.病人门诊挂号ToolStripMenuItem_Click);
            // 
            // 病人急诊挂号ToolStripMenuItem
            // 
            this.病人急诊挂号ToolStripMenuItem.Name = "病人急诊挂号ToolStripMenuItem";
            this.病人急诊挂号ToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.病人急诊挂号ToolStripMenuItem.Text = "病人急诊挂号";
            this.病人急诊挂号ToolStripMenuItem.Click += new System.EventHandler(this.病人急诊挂号ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(209, 6);
            // 
            // 病人门诊挂号查询ToolStripMenuItem
            // 
            this.病人门诊挂号查询ToolStripMenuItem.Name = "病人门诊挂号查询ToolStripMenuItem";
            this.病人门诊挂号查询ToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.病人门诊挂号查询ToolStripMenuItem.Text = "病人门诊挂号查询";
            this.病人门诊挂号查询ToolStripMenuItem.Click += new System.EventHandler(this.病人门诊挂号查询ToolStripMenuItem_Click);
            // 
            // 病人急诊挂号查询ToolStripMenuItem
            // 
            this.病人急诊挂号查询ToolStripMenuItem.Name = "病人急诊挂号查询ToolStripMenuItem";
            this.病人急诊挂号查询ToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.病人急诊挂号查询ToolStripMenuItem.Text = "病人急诊挂号查询";
            this.病人急诊挂号查询ToolStripMenuItem.Click += new System.EventHandler(this.病人急诊挂号查询ToolStripMenuItem_Click);
            // 
            // 病人缴费ToolStripMenuItem
            // 
            this.病人缴费ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.病人门诊挂号缴费ToolStripMenuItem,
            this.病人急诊挂号缴费ToolStripMenuItem,
            this.toolStripMenuItem4,
            this.病人门诊挂号缴费查询ToolStripMenuItem,
            this.病人急诊挂号缴费查询ToolStripMenuItem});
            this.病人缴费ToolStripMenuItem.Name = "病人缴费ToolStripMenuItem";
            this.病人缴费ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.病人缴费ToolStripMenuItem.Text = "病人缴费";
            // 
            // 病人门诊挂号缴费ToolStripMenuItem
            // 
            this.病人门诊挂号缴费ToolStripMenuItem.Name = "病人门诊挂号缴费ToolStripMenuItem";
            this.病人门诊挂号缴费ToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.病人门诊挂号缴费ToolStripMenuItem.Text = "病人门诊挂号缴费";
            this.病人门诊挂号缴费ToolStripMenuItem.Click += new System.EventHandler(this.病人门诊挂号缴费ToolStripMenuItem_Click);
            // 
            // 病人急诊挂号缴费ToolStripMenuItem
            // 
            this.病人急诊挂号缴费ToolStripMenuItem.Name = "病人急诊挂号缴费ToolStripMenuItem";
            this.病人急诊挂号缴费ToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.病人急诊挂号缴费ToolStripMenuItem.Text = "病人急诊挂号缴费";
            this.病人急诊挂号缴费ToolStripMenuItem.Click += new System.EventHandler(this.病人急诊挂号缴费ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(239, 6);
            // 
            // 病人门诊挂号缴费查询ToolStripMenuItem
            // 
            this.病人门诊挂号缴费查询ToolStripMenuItem.Name = "病人门诊挂号缴费查询ToolStripMenuItem";
            this.病人门诊挂号缴费查询ToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.病人门诊挂号缴费查询ToolStripMenuItem.Text = "病人门诊挂号缴费查询";
            this.病人门诊挂号缴费查询ToolStripMenuItem.Click += new System.EventHandler(this.病人门诊挂号缴费查询ToolStripMenuItem_Click);
            // 
            // 病人急诊挂号缴费查询ToolStripMenuItem
            // 
            this.病人急诊挂号缴费查询ToolStripMenuItem.Name = "病人急诊挂号缴费查询ToolStripMenuItem";
            this.病人急诊挂号缴费查询ToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.病人急诊挂号缴费查询ToolStripMenuItem.Text = "病人急诊挂号缴费查询";
            this.病人急诊挂号缴费查询ToolStripMenuItem.Click += new System.EventHandler(this.病人急诊挂号缴费查询ToolStripMenuItem_Click);
            // 
            // 接诊ToolStripMenuItem
            // 
            this.接诊ToolStripMenuItem.Name = "接诊ToolStripMenuItem";
            this.接诊ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.接诊ToolStripMenuItem.Text = "接诊";
            this.接诊ToolStripMenuItem.Click += new System.EventHandler(this.接诊ToolStripMenuItem_Click);
            // 
            // 切换用户ToolStripMenuItem
            // 
            this.切换用户ToolStripMenuItem.Name = "切换用户ToolStripMenuItem";
            this.切换用户ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.切换用户ToolStripMenuItem.Text = "切换用户";
            this.切换用户ToolStripMenuItem.Click += new System.EventHandler(this.切换用户ToolStripMenuItem_Click);
            // 
            // 测试ToolStripMenuItem
            // 
            this.测试ToolStripMenuItem.Name = "测试ToolStripMenuItem";
            this.测试ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.测试ToolStripMenuItem.Text = "测试";
            this.测试ToolStripMenuItem.Visible = false;
            this.测试ToolStripMenuItem.Click += new System.EventHandler(this.测试ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tssl_time,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 424);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(84, 20);
            this.toolStripStatusLabel1.Text = "系统日期：";
            // 
            // tssl_time
            // 
            this.tssl_time.Name = "tssl_time";
            this.tssl_time.Size = new System.Drawing.Size(0, 20);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(54, 20);
            this.toolStripStatusLabel2.Text = "欢迎！";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // 主窗口
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "主窗口";
            this.Text = "主窗口";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.主窗口_FormClosed);
            this.Load += new System.EventHandler(this.主窗口_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem 挂号ToolStripMenuItem;
        private ToolStripMenuItem 门诊挂号ToolStripMenuItem;
        private ToolStripMenuItem 急诊挂号ToolStripMenuItem;
        private ToolStripMenuItem 病人管理ToolStripMenuItem;
        private ToolStripMenuItem 病人建档ToolStripMenuItem;
        private ToolStripMenuItem 病人查询ToolStripMenuItem;
        private ToolStripMenuItem 收费ToolStripMenuItem;
        private ToolStripMenuItem 费用查询ToolStripMenuItem;
        private ToolStripMenuItem 切换用户ToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel tssl_time;
        private System.Windows.Forms.Timer timer1;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem 门诊挂号记录ToolStripMenuItem;
        private ToolStripMenuItem 急诊挂号记录ToolStripMenuItem;
        private ToolStripMenuItem 急诊挂号收费ToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem 门诊挂号收费查询ToolStripMenuItem;
        private ToolStripMenuItem 急诊挂号收费查询ToolStripMenuItem;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripMenuItem 病人挂号ToolStripMenuItem;
        private ToolStripMenuItem 病人门诊挂号ToolStripMenuItem;
        private ToolStripMenuItem 病人急诊挂号ToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem 病人门诊挂号查询ToolStripMenuItem;
        private ToolStripMenuItem 病人急诊挂号查询ToolStripMenuItem;
        private ToolStripMenuItem 病人缴费ToolStripMenuItem;
        private ToolStripMenuItem 病人门诊挂号缴费ToolStripMenuItem;
        private ToolStripMenuItem 病人急诊挂号缴费ToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripMenuItem 病人门诊挂号缴费查询ToolStripMenuItem;
        private ToolStripMenuItem 病人急诊挂号缴费查询ToolStripMenuItem;
        private ToolStripMenuItem 接诊ToolStripMenuItem;
        private ToolStripMenuItem 测试ToolStripMenuItem;
    }
}