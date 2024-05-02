/* 本文件由拜语言 IDE 自动生成，网址:http://www.baiyuyan.com/  生成时间:2024-04-30 02:43:05  */
namespace byUser.dress.user
{
    partial class modifyInfo
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
            this.cNameLabel = new System.Windows.Forms.Label();
            this.cNametextBox = new System.Windows.Forms.TextBox();
            this.cSureButton = new System.Windows.Forms.Button();
            this.cCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            //  cNameLabel
            //
            this.cNameLabel.AutoSize = true;
            this.cNameLabel.Location = new System.Drawing.Point(4, 4);
            this.cNameLabel.Name = "cNameLabel";
            this.cNameLabel.Size = new System.Drawing.Size(100,30);
            this.cNameLabel.TabIndex = 0;
            this.cNameLabel.Text = "请输入新名称：";
            //
            //  cNametextBox
            //
            this.cNametextBox.Location = new System.Drawing.Point(112, 4);
            this.cNametextBox.Name = "cNametextBox";
            this.cNametextBox.Size = new System.Drawing.Size(100, 30);
            this.cNametextBox.TabIndex = 0;
            //
            //  cSureButton
            //
            this.cSureButton.Location = new System.Drawing.Point(220, 4);
            this.cSureButton.Name = "cSureButton";
            this.cSureButton.Size = new System.Drawing.Size(100, 30);
            this.cSureButton.TabIndex = 0;
            this.cSureButton.Text = "确定";
            this.cSureButton.UseVisualStyleBackColor = true; 
            //
            //  cCancelButton
            //
            this.cCancelButton.Location = new System.Drawing.Point(328, 4);
            this.cCancelButton.Name = "cCancelButton";
            this.cCancelButton.Size = new System.Drawing.Size(100, 30);
            this.cCancelButton.TabIndex = 0;
            this.cCancelButton.Text = "取消";
            this.cCancelButton.UseVisualStyleBackColor = true; 
            //
            //  modifyInfo
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.cCancelButton);
            this.Controls.Add(this.cSureButton);
            this.Controls.Add(this.cNametextBox);
            this.Controls.Add(this.cNameLabel);
            this.Name = "modifyInfo";
            this.Text = "修改个人信息窗体";
            this.ResumeLayout(false);
            this.PerformLayout();


        }
        
        #endregion

        private System.Windows.Forms.Label cNameLabel;
        private System.Windows.Forms.TextBox cNametextBox;
        private System.Windows.Forms.Button cSureButton;
        private System.Windows.Forms.Button cCancelButton;

        
    }
}