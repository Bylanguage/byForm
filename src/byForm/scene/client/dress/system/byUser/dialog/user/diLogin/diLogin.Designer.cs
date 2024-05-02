/* 本文件由拜语言 IDE 自动生成，网址:http://www.baiyuyan.com/  生成时间:2024-04-30 02:43:05  */
namespace byUser.dress.user
{
    partial class diLogin
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
            this.cLblName = new System.Windows.Forms.Label();
            this.cTxtName = new System.Windows.Forms.TextBox();
            this.cLblPwd = new System.Windows.Forms.Label();
            this.cTxtPwd = new System.Windows.Forms.TextBox();
            this.cBtnLogin = new System.Windows.Forms.Button();
            this.cBtnReg = new System.Windows.Forms.Button();
            this.cLblFindPwd = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            //  cLblName
            //
            this.cLblName.AutoSize = true;
            this.cLblName.Location = new System.Drawing.Point(4, 4);
            this.cLblName.Name = "cLblName";
            this.cLblName.Size = new System.Drawing.Size(100,30);
            this.cLblName.TabIndex = 0;
            this.cLblName.Text = "用户名";
            //
            //  cTxtName
            //
            this.cTxtName.Location = new System.Drawing.Point(112, 4);
            this.cTxtName.Name = "cTxtName";
            this.cTxtName.Size = new System.Drawing.Size(100, 30);
            this.cTxtName.TabIndex = 0;
            //
            //  cLblPwd
            //
            this.cLblPwd.AutoSize = true;
            this.cLblPwd.Location = new System.Drawing.Point(220, 4);
            this.cLblPwd.Name = "cLblPwd";
            this.cLblPwd.Size = new System.Drawing.Size(100,30);
            this.cLblPwd.TabIndex = 0;
            this.cLblPwd.Text = "密码：";
            //
            //  cTxtPwd
            //
            this.cTxtPwd.Location = new System.Drawing.Point(328, 4);
            this.cTxtPwd.Name = "cTxtPwd";
            this.cTxtPwd.Size = new System.Drawing.Size(100, 30);
            this.cTxtPwd.TabIndex = 0;
            //
            //  cBtnLogin
            //
            this.cBtnLogin.Location = new System.Drawing.Point(436, 4);
            this.cBtnLogin.Name = "cBtnLogin";
            this.cBtnLogin.Size = new System.Drawing.Size(100, 30);
            this.cBtnLogin.TabIndex = 0;
            this.cBtnLogin.Text = "登录";
            this.cBtnLogin.UseVisualStyleBackColor = true; 
            //
            //  cBtnReg
            //
            this.cBtnReg.Location = new System.Drawing.Point(544, 4);
            this.cBtnReg.Name = "cBtnReg";
            this.cBtnReg.Size = new System.Drawing.Size(100, 30);
            this.cBtnReg.TabIndex = 0;
            this.cBtnReg.Text = "注册";
            this.cBtnReg.UseVisualStyleBackColor = true; 
            //
            //  cLblFindPwd
            //
            this.cLblFindPwd.AutoSize = true;
            this.cLblFindPwd.Location = new System.Drawing.Point(652, 4);
            this.cLblFindPwd.Name = "cLblFindPwd";
            this.cLblFindPwd.Size = new System.Drawing.Size(100,30);
            this.cLblFindPwd.TabIndex = 0;
            this.cLblFindPwd.Text = "找回密码";
            //
            //  diLogin
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.cLblFindPwd);
            this.Controls.Add(this.cBtnReg);
            this.Controls.Add(this.cBtnLogin);
            this.Controls.Add(this.cTxtPwd);
            this.Controls.Add(this.cLblPwd);
            this.Controls.Add(this.cTxtName);
            this.Controls.Add(this.cLblName);
            this.Name = "diLogin";
            this.Text = "登录窗体";
            this.ResumeLayout(false);
            this.PerformLayout();


        }
        
        #endregion

        private System.Windows.Forms.Label cLblName;
        private System.Windows.Forms.TextBox cTxtName;
        private System.Windows.Forms.Label cLblPwd;
        private System.Windows.Forms.TextBox cTxtPwd;
        private System.Windows.Forms.Button cBtnLogin;
        private System.Windows.Forms.Button cBtnReg;
        private System.Windows.Forms.Label cLblFindPwd;

        
    }
}