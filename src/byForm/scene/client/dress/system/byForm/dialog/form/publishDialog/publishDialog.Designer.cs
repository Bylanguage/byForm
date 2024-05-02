/* 本文件由拜语言 IDE 自动生成，网址:http://www.baiyuyan.com/  生成时间:2024-04-30 02:43:05  */
namespace byForm.dress.form
{
    partial class publishDialog
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
            this.saasPanel = new System.Windows.Forms.Panel();
            this.saasSamplePanel = new System.Windows.Forms.Panel();
            this.urlLabel = new System.Windows.Forms.Label();
            this.saasPanel.SuspendLayout();
            this.saasSamplePanel.SuspendLayout();
            this.SuspendLayout();
            //
            //  saasPanel
            //
            this.saasPanel.Location = new System.Drawing.Point(4, 4);
            this.saasPanel.Name =  "saasPanel";
            this.saasPanel.Size = new System.Drawing.Size(100, 30);
            this.saasPanel.TabIndex =  0;
            //
            //  saasSamplePanel
            //
            this.saasSamplePanel.Location = new System.Drawing.Point(112, 4);
            this.saasSamplePanel.Name =  "saasSamplePanel";
            this.saasSamplePanel.Size = new System.Drawing.Size(100, 30);
            this.saasSamplePanel.TabIndex =  0;
            //
            //  urlLabel
            //
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(220, 4);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(100,30);
            this.urlLabel.TabIndex = 0;
            this.urlLabel.Text = "label";
            //
            //  publishDialog
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.urlLabel);
            this.Controls.Add(this.saasSamplePanel);
            this.Controls.Add(this.saasPanel);
            this.Name = "publishDialog";
            this.Text = "发布问卷的弹窗";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.saasPanel.ResumeLayout(false);
            this.saasPanel.PerformLayout();
            this.saasSamplePanel.ResumeLayout(false);
            this.saasSamplePanel.PerformLayout();


        }
        
        #endregion

        private System.Windows.Forms.Panel saasPanel;
        private System.Windows.Forms.Panel saasSamplePanel;
        private System.Windows.Forms.Label urlLabel;

        
    }
}