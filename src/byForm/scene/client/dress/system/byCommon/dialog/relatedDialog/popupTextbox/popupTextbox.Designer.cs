/* 本文件由拜语言 IDE 自动生成，网址:http://www.baiyuyan.com/  生成时间:2024-04-30 02:43:05  */
namespace byCommon.dress.relatedDialog
{
    partial class popupTextbox
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
            this.cLblTitle = new System.Windows.Forms.Label();
            this.cContent = new System.Windows.Forms.TextBox();
            this.cBtnOk = new System.Windows.Forms.Button();
            this.cBtnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            //  cLblTitle
            //
            this.cLblTitle.AutoSize = true;
            this.cLblTitle.Location = new System.Drawing.Point(4, 4);
            this.cLblTitle.Name = "cLblTitle";
            this.cLblTitle.Size = new System.Drawing.Size(100,30);
            this.cLblTitle.TabIndex = 0;
            this.cLblTitle.Text = "标题";
            //
            //  cContent
            //
            this.cContent.Location = new System.Drawing.Point(112, 4);
            this.cContent.Name = "cContent";
            this.cContent.Size = new System.Drawing.Size(100, 30);
            this.cContent.TabIndex = 0;
            //
            //  cBtnOk
            //
            this.cBtnOk.Location = new System.Drawing.Point(220, 4);
            this.cBtnOk.Name = "cBtnOk";
            this.cBtnOk.Size = new System.Drawing.Size(100, 30);
            this.cBtnOk.TabIndex = 0;
            this.cBtnOk.Text = "确认";
            this.cBtnOk.UseVisualStyleBackColor = true; 
            //
            //  cBtnCancel
            //
            this.cBtnCancel.Location = new System.Drawing.Point(328, 4);
            this.cBtnCancel.Name = "cBtnCancel";
            this.cBtnCancel.Size = new System.Drawing.Size(100, 30);
            this.cBtnCancel.TabIndex = 0;
            this.cBtnCancel.Text = "取消";
            this.cBtnCancel.UseVisualStyleBackColor = true; 
            //
            //  popupTextbox
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.cBtnCancel);
            this.Controls.Add(this.cBtnOk);
            this.Controls.Add(this.cContent);
            this.Controls.Add(this.cLblTitle);
            this.Name = "popupTextbox";
            this.Text = "请选择,展示一个文本框";
            this.ResumeLayout(false);
            this.PerformLayout();


        }
        
        #endregion

        private System.Windows.Forms.Label cLblTitle;
        private System.Windows.Forms.TextBox cContent;
        private System.Windows.Forms.Button cBtnOk;
        private System.Windows.Forms.Button cBtnCancel;

        
    }
}