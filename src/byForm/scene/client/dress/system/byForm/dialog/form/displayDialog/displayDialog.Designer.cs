/* 本文件由拜语言 IDE 自动生成，网址:http://www.baiyuyan.com/  生成时间:2024-04-30 02:43:05  */
namespace byForm.dress.form
{
    partial class displayDialog
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
            this.displayPanel = new System.Windows.Forms.Panel();
            this.displayPanel.SuspendLayout();
            this.SuspendLayout();
            //
            //  displayPanel
            //
            this.displayPanel.Location = new System.Drawing.Point(4, 4);
            this.displayPanel.Name =  "displayPanel";
            this.displayPanel.Size = new System.Drawing.Size(100, 30);
            this.displayPanel.TabIndex =  0;
            //
            //  displayDialog
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.displayPanel);
            this.Name = "displayDialog";
            this.Text = "展示表单的容器";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.displayPanel.ResumeLayout(false);
            this.displayPanel.PerformLayout();


        }
        
        #endregion

        private System.Windows.Forms.Panel displayPanel;

        
    }
}