namespace YinRan2020
{
    partial class Deivce_Info
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Deivce_Info));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("串口1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("串口2");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("串口3");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("串口4");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("串口5");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("串口6");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("通讯选择", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("数据设置");
            this.label_title = new System.Windows.Forms.Label();
            this.panel_tool = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel_com_info = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label_zhuangtai = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_jiaoyanwei = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_tingzhiwei = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_shujuwei = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_botelv = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_chuankouhao = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_dataset = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.timer_send1 = new System.Windows.Forms.Timer(this.components);
            this.timer_send2 = new System.Windows.Forms.Timer(this.components);
            this.timer_send3 = new System.Windows.Forms.Timer(this.components);
            this.timer_send4 = new System.Windows.Forms.Timer(this.components);
            this.timer_send5 = new System.Windows.Forms.Timer(this.components);
            this.timer_send6 = new System.Windows.Forms.Timer(this.components);
            this.myDataGridView1 = new YinRan2020.MyDataGridView();
            this.panel_tool.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel_com_info.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel_dataset.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.BackColor = System.Drawing.Color.Green;
            this.label_title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_title.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_title.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label_title.Location = new System.Drawing.Point(-1, -1);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(1207, 33);
            this.label_title.TabIndex = 0;
            this.label_title.Text = "label1";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_tool
            // 
            this.panel_tool.Controls.Add(this.toolStrip1);
            this.panel_tool.Location = new System.Drawing.Point(-1, 35);
            this.panel_tool.Name = "panel_tool";
            this.panel_tool.Size = new System.Drawing.Size(1224, 48);
            this.panel_tool.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1224, 48);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 45);
            this.toolStripButton1.Text = "添加设备";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 45);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "删除";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::YinRan2020.Properties.Resources.xiugai;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 45);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.treeView1.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.Location = new System.Drawing.Point(12, 104);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "com1";
            treeNode1.Text = "串口1";
            treeNode2.Name = "com2";
            treeNode2.Text = "串口2";
            treeNode3.Name = "com3";
            treeNode3.Text = "串口3";
            treeNode4.Name = "com4";
            treeNode4.Text = "串口4";
            treeNode5.Name = "com5";
            treeNode5.Text = "串口5";
            treeNode6.Name = "com6";
            treeNode6.Text = "串口6";
            treeNode7.Name = "tongxun";
            treeNode7.Text = "通讯选择";
            treeNode8.Name = "dataset";
            treeNode8.Text = "数据设置";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            this.treeView1.Size = new System.Drawing.Size(223, 617);
            this.treeView1.TabIndex = 2;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // panel_com_info
            // 
            this.panel_com_info.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel_com_info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_com_info.Controls.Add(this.button3);
            this.panel_com_info.Controls.Add(this.button2);
            this.panel_com_info.Controls.Add(this.button1);
            this.panel_com_info.Controls.Add(this.label_zhuangtai);
            this.panel_com_info.Controls.Add(this.label7);
            this.panel_com_info.Controls.Add(this.comboBox_jiaoyanwei);
            this.panel_com_info.Controls.Add(this.label6);
            this.panel_com_info.Controls.Add(this.comboBox_tingzhiwei);
            this.panel_com_info.Controls.Add(this.label5);
            this.panel_com_info.Controls.Add(this.comboBox_shujuwei);
            this.panel_com_info.Controls.Add(this.label4);
            this.panel_com_info.Controls.Add(this.comboBox_botelv);
            this.panel_com_info.Controls.Add(this.label3);
            this.panel_com_info.Controls.Add(this.comboBox_chuankouhao);
            this.panel_com_info.Controls.Add(this.label2);
            this.panel_com_info.Controls.Add(this.label1);
            this.panel_com_info.Location = new System.Drawing.Point(241, 104);
            this.panel_com_info.Name = "panel_com_info";
            this.panel_com_info.Size = new System.Drawing.Size(906, 145);
            this.panel_com_info.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.SandyBrown;
            this.button3.Location = new System.Drawing.Point(714, 97);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 31);
            this.button3.TabIndex = 15;
            this.button3.Text = "保存";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(714, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 37);
            this.button2.TabIndex = 14;
            this.button2.Text = "关闭";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.GreenYellow;
            this.button1.Location = new System.Drawing.Point(714, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 37);
            this.button1.TabIndex = 13;
            this.button1.Text = "打开";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label_zhuangtai
            // 
            this.label_zhuangtai.AutoSize = true;
            this.label_zhuangtai.Location = new System.Drawing.Point(496, 88);
            this.label_zhuangtai.Name = "label_zhuangtai";
            this.label_zhuangtai.Size = new System.Drawing.Size(41, 12);
            this.label_zhuangtai.TabIndex = 12;
            this.label_zhuangtai.Text = "状  态";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(449, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "状  态";
            // 
            // comboBox_jiaoyanwei
            // 
            this.comboBox_jiaoyanwei.FormattingEnabled = true;
            this.comboBox_jiaoyanwei.Location = new System.Drawing.Point(496, 51);
            this.comboBox_jiaoyanwei.Name = "comboBox_jiaoyanwei";
            this.comboBox_jiaoyanwei.Size = new System.Drawing.Size(121, 20);
            this.comboBox_jiaoyanwei.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(449, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "校验位";
            // 
            // comboBox_tingzhiwei
            // 
            this.comboBox_tingzhiwei.FormattingEnabled = true;
            this.comboBox_tingzhiwei.Location = new System.Drawing.Point(496, 16);
            this.comboBox_tingzhiwei.Name = "comboBox_tingzhiwei";
            this.comboBox_tingzhiwei.Size = new System.Drawing.Size(121, 20);
            this.comboBox_tingzhiwei.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(449, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "停止位";
            // 
            // comboBox_shujuwei
            // 
            this.comboBox_shujuwei.FormattingEnabled = true;
            this.comboBox_shujuwei.Location = new System.Drawing.Point(226, 85);
            this.comboBox_shujuwei.Name = "comboBox_shujuwei";
            this.comboBox_shujuwei.Size = new System.Drawing.Size(121, 20);
            this.comboBox_shujuwei.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "数据位";
            // 
            // comboBox_botelv
            // 
            this.comboBox_botelv.FormattingEnabled = true;
            this.comboBox_botelv.Location = new System.Drawing.Point(226, 51);
            this.comboBox_botelv.Name = "comboBox_botelv";
            this.comboBox_botelv.Size = new System.Drawing.Size(121, 20);
            this.comboBox_botelv.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "波特率";
            // 
            // comboBox_chuankouhao
            // 
            this.comboBox_chuankouhao.FormattingEnabled = true;
            this.comboBox_chuankouhao.Location = new System.Drawing.Point(226, 16);
            this.comboBox_chuankouhao.Name = "comboBox_chuankouhao";
            this.comboBox_chuankouhao.Size = new System.Drawing.Size(121, 20);
            this.comboBox_chuankouhao.TabIndex = 2;
            this.comboBox_chuankouhao.DropDown += new System.EventHandler(this.comboBox_chuankouhao_DropDown);
            this.comboBox_chuankouhao.Click += new System.EventHandler(this.comboBox_chuankouhao_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "串口号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(16, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口信息";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel_dataset);
            this.panel1.Controls.Add(this.myDataGridView1);
            this.panel1.Location = new System.Drawing.Point(242, 256);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(905, 446);
            this.panel1.TabIndex = 4;
            // 
            // panel_dataset
            // 
            this.panel_dataset.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel_dataset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_dataset.Controls.Add(this.label15);
            this.panel_dataset.Location = new System.Drawing.Point(20, 66);
            this.panel_dataset.Name = "panel_dataset";
            this.panel_dataset.Size = new System.Drawing.Size(906, 145);
            this.panel_dataset.TabIndex = 16;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(16, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 26);
            this.label15.TabIndex = 0;
            this.label15.Text = "数据设置";
            // 
            // timer_send1
            // 
            this.timer_send1.Enabled = true;
            this.timer_send1.Interval = 20;
            this.timer_send1.Tick += new System.EventHandler(this.timer_send1_Tick);
            // 
            // timer_send2
            // 
            this.timer_send2.Enabled = true;
            this.timer_send2.Interval = 20;
            this.timer_send2.Tick += new System.EventHandler(this.timer_send2_Tick);
            // 
            // timer_send3
            // 
            this.timer_send3.Enabled = true;
            this.timer_send3.Interval = 20;
            this.timer_send3.Tick += new System.EventHandler(this.timer_send3_Tick);
            // 
            // timer_send4
            // 
            this.timer_send4.Enabled = true;
            this.timer_send4.Interval = 20;
            // 
            // timer_send5
            // 
            this.timer_send5.Enabled = true;
            this.timer_send5.Interval = 20;
            // 
            // timer_send6
            // 
            this.timer_send6.Enabled = true;
            // 
            // myDataGridView1
            // 
            this.myDataGridView1.Location = new System.Drawing.Point(3, 3);
            this.myDataGridView1.Name = "myDataGridView1";
            this.myDataGridView1.Size = new System.Drawing.Size(897, 712);
            this.myDataGridView1.TabIndex = 0;
            // 
            // Deivce_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 742);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_com_info);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.panel_tool);
            this.Controls.Add(this.label_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Deivce_Info";
            this.Text = "Deivce_Info";
            this.Resize += new System.EventHandler(this.Deivce_Info_Resize);
            this.panel_tool.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel_com_info.ResumeLayout(false);
            this.panel_com_info.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel_dataset.ResumeLayout(false);
            this.panel_dataset.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Panel panel_tool;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel_com_info;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_chuankouhao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_botelv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_shujuwei;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_tingzhiwei;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_jiaoyanwei;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_zhuangtai;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private MyDataGridView myDataGridView1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Panel panel_dataset;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.Timer timer_send1;
        private System.Windows.Forms.Timer timer_send2;
        private System.Windows.Forms.Timer timer_send3;
        private System.Windows.Forms.Timer timer_send4;
        private System.Windows.Forms.Timer timer_send5;
        private System.Windows.Forms.Timer timer_send6;
    }
}