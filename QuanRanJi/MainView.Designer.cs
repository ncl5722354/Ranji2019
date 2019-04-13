namespace QuanRanJi
{
    partial class MainView
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("总貌1（1-6）");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("总貌2（7-12）");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("总貌3（13-18）");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("总貌4（19-24）");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("总貌5（25-30）");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("总貌6（31-36）");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("总貌7（37-42）");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("总貌8（43-48）");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("总貌9（49-54）");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("总貌", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9});
            this.treeView_main = new System.Windows.Forms.TreeView();
            this.panel_subview = new System.Windows.Forms.Panel();
            this.button_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView_main
            // 
            this.treeView_main.BackColor = System.Drawing.Color.LightGreen;
            this.treeView_main.Location = new System.Drawing.Point(12, 12);
            this.treeView_main.Name = "treeView_main";
            treeNode1.Name = "节点1";
            treeNode1.Text = "总貌1（1-6）";
            treeNode2.Name = "节点3";
            treeNode2.Text = "总貌2（7-12）";
            treeNode3.Name = "节点4";
            treeNode3.Text = "总貌3（13-18）";
            treeNode4.Name = "节点5";
            treeNode4.Text = "总貌4（19-24）";
            treeNode5.Name = "节点6";
            treeNode5.Text = "总貌5（25-30）";
            treeNode6.Name = "节点7";
            treeNode6.Text = "总貌6（31-36）";
            treeNode7.Name = "节点8";
            treeNode7.Text = "总貌7（37-42）";
            treeNode8.Name = "节点9";
            treeNode8.Text = "总貌8（43-48）";
            treeNode9.Name = "节点10";
            treeNode9.Text = "总貌9（49-54）";
            treeNode10.Name = "节点0";
            treeNode10.Text = "总貌";
            this.treeView_main.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode10});
            this.treeView_main.Size = new System.Drawing.Size(121, 551);
            this.treeView_main.TabIndex = 0;
            this.treeView_main.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_main_AfterSelect);
            // 
            // panel_subview
            // 
            this.panel_subview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_subview.Location = new System.Drawing.Point(140, 12);
            this.panel_subview.Name = "panel_subview";
            this.panel_subview.Size = new System.Drawing.Size(637, 551);
            this.panel_subview.TabIndex = 1;
            // 
            // button_close
            // 
            this.button_close.BackColor = System.Drawing.Color.Red;
            this.button_close.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_close.Location = new System.Drawing.Point(792, 12);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(75, 23);
            this.button_close.TabIndex = 0;
            this.button_close.Text = "关闭系统";
            this.button_close.UseVisualStyleBackColor = false;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 592);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.panel_subview);
            this.Controls.Add(this.treeView_main);
            this.Name = "MainView";
            this.Text = "卷染机集控系统";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView_main;
        private System.Windows.Forms.Panel panel_subview;
        private System.Windows.Forms.Button button_close;
    }
}

