/* 本文件由拜语言 IDE 自动生成，网址:http://www.baiyuyan.com/  生成时间:2024-04-30 02:43:05  */
namespace byCommon.dress.relatedDialog
{
    partial class loadingDialog
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
            this.pLoadingImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pLoadingImage)).BeginInit();
            this.SuspendLayout();
            //
            //  pLoadingImage
            //
            this.pLoadingImage.Location = new System.Drawing.Point(4, 4);
            this.pLoadingImage.Name =  "pLoadingImage";
            this.pLoadingImage.Size = new System.Drawing.Size(100, 30);
            this.pLoadingImage.TabIndex =  0;
            //
            //  loadingDialog
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.pLoadingImage);
            this.Name = "loadingDialog";
            this.Text = "正在装入数据，请稍后...";
            this.ResumeLayout(false);
            this.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pLoadingImage)).EndInit();


        }
        
        #endregion

        private System.Windows.Forms.PictureBox pLoadingImage;

        
    }
}