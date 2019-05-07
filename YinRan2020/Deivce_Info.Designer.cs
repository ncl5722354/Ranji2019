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
            this.label_title = new System.Windows.Forms.Label();
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
            // Deivce_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 654);
            this.Controls.Add(this.label_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Deivce_Info";
            this.Text = "Deivce_Info";
            this.Resize += new System.EventHandler(this.Deivce_Info_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_title;
    }
}