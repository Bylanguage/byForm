/* 本文件由拜语言 IDE 自动生成，网址:http://www.baiyuyan.com/  生成时间:2024-04-30 02:43:05  */
namespace byUser.dress.user
{
    partial class RetrievePassword
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
            this.cLblSafetyCode = new System.Windows.Forms.Label();
            this.cTxtSafetyCode = new System.Windows.Forms.TextBox();
            this.cLblPassword = new System.Windows.Forms.Label();
            this.cTxtPassword = new System.Windows.Forms.TextBox();
            this.cLblConfirmPassword = new System.Windows.Forms.Label();
            this.cTxtConfirmPassword = new System.Windows.Forms.TextBox();
            this.cBtnSure = new System.Windows.Forms.Button();
            this.cBtnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            //  cLblSafetyCode
            //
            this.cLblSafetyCode.AutoSize = true;
            this.cLblSafetyCode.Location = new System.Drawing.Point(4, 4);
            this.cLblSafetyCode.Name = "cLblSafetyCode";
            this.cLblSafetyCode.Size = new System.Drawing.Size(100,30);
            this.cLblSafetyCode.TabIndex = 0;
            this.cLblSafetyCode.Text = "安全码";
            //
            //  cTxtSafetyCode
            //
            this.cTxtSafetyCode.Location = new System.Drawing.Point(112, 4);
            this.cTxtSafetyCode.Name = "cTxtSafetyCode";
            this.cTxtSafetyCode.Size = new System.Drawing.Size(100, 30);
            this.cTxtSafetyCode.TabIndex = 0;
            //
            //  cLblPassword
            //
            this.cLblPassword.AutoSize = true;
            this.cLblPassword.Location = new System.Drawing.Point(220, 4);
            this.cLblPassword.Name = "cLblPassword";
            this.cLblPassword.Size = new System.Drawing.Size(100,30);
            this.cLblPassword.TabIndex = 0;
            this.cLblPassword.Text = "新密码";
            //
            //  cTxtPassword
            //
            this.cTxtPassword.Location = new System.Drawing.Point(328, 4);
            this.cTxtPassword.Name = "cTxtPassword";
            this.cTxtPassword.Size = new System.Drawing.Size(100, 30);
            this.cTxtPassword.TabIndex = 0;
            //
            //  cLblConfirmPassword
            //
            this.cLblConfirmPassword.AutoSize = true;
            this.cLblConfirmPassword.Location = new System.Drawing.Point(436, 4);
            this.cLblConfirmPassword.Name = "cLblConfirmPassword";
            this.cLblConfirmPassword.Size = new System.Drawing.Size(100,30);
            this.cLblConfirmPassword.TabIndex = 0;
            this.cLblConfirmPassword.Text = "再次确认";
            //
            //  cTxtConfirmPassword
            //
            this.cTxtConfirmPassword.Location = new System.Drawing.Point(544, 4);
            this.cTxtConfirmPassword.Name = "cTxtConfirmPassword";
            this.cTxtConfirmPassword.Size = new System.Drawing.Size(100, 30);
            this.cTxtConfirmPassword.TabIndex = 0;
            //
            //  cBtnSure
            //
            this.cBtnSure.Location = new System.Drawing.Point(652, 4);
            this.cBtnSure.Name = "cBtnSure";
            this.cBtnSure.Size = new System.Drawing.Size(100, 30);
            this.cBtnSure.TabIndex = 0;
            this.cBtnSure.Text = "确认修改";
            this.cBtnSure.UseVisualStyleBackColor = true; 
            //
            //  cBtnCancel
            //
            this.cBtnCancel.Location = new System.Drawing.Point(760, 4);
            this.cBtnCancel.Name = "cBtnCancel";
            this.cBtnCancel.Size = new System.Drawing.Size(100, 30);
            this.cBtnCancel.TabIndex = 0;
            this.cBtnCancel.Text = "取消";
            this.cBtnCancel.UseVisualStyleBackColor = true; 
            //
            //  RetrievePassword
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.cBtnCancel);
            this.Controls.Add(this.cBtnSure);
            this.Controls.Add(this.cTxtConfirmPassword);
            this.Controls.Add(this.cLblConfirmPassword);
            this.Controls.Add(this.cTxtPassword);
            this.Controls.Add(this.cLblPassword);
            this.Controls.Add(this.cTxtSafetyCode);
            this.Controls.Add(this.cLblSafetyCode);
            this.Name = "RetrievePassword";
            this.Text = "重设密码找回窗体";
            this.ResumeLayout(false);
            this.PerformLayout();


        }
        
        #endregion

        private System.Windows.Forms.Label cLblSafetyCode;
        private System.Windows.Forms.TextBox cTxtSafetyCode;
        private System.Windows.Forms.Label cLblPassword;
        private System.Windows.Forms.TextBox cTxtPassword;
        private System.Windows.Forms.Label cLblConfirmPassword;
        private System.Windows.Forms.TextBox cTxtConfirmPassword;
        private System.Windows.Forms.Button cBtnSure;
        private System.Windows.Forms.Button cBtnCancel;

        
    }
}