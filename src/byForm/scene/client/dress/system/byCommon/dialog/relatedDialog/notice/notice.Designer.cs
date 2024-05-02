/* 本文件由拜语言 IDE 自动生成，网址:http://www.baiyuyan.com/  生成时间:2024-04-30 02:43:05  */
namespace byCommon.dress.relatedDialog
{
    partial class notice
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
            this.lblTitle = new System.Windows.Forms.Panel();
            this.lblContent = new System.Windows.Forms.Panel();
            this.lblTitle.SuspendLayout();
            this.lblContent.SuspendLayout();
            this.SuspendLayout();
            //
            //  lblTitle
            //
            this.lblTitle.Location = new System.Drawing.Point(4, 4);
            this.lblTitle.Name =  "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(100, 30);
            this.lblTitle.TabIndex =  0;
            //
            //  lblContent
            //
            this.lblContent.Location = new System.Drawing.Point(112, 4);
            this.lblContent.Name =  "lblContent";
            this.lblContent.Size = new System.Drawing.Size(100, 30);
            this.lblContent.TabIndex =  0;
            //
            //  notice
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.lblTitle);
            this.Name = "notice";
            this.Text = "弹窗显示类似一个公告，仅即时展示一条信息";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.lblTitle.ResumeLayout(false);
            this.lblTitle.PerformLayout();
            this.lblContent.ResumeLayout(false);
            this.lblContent.PerformLayout();


        }
        
        #endregion

        private System.Windows.Forms.Panel lblTitle;
        private System.Windows.Forms.Panel lblContent;

        
    }
}