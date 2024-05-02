/* 本文件由拜语言 IDE 自动生成，网址:http://www.baiyuyan.com/  生成时间:2024-04-30 02:43:05  */
namespace byUser.dress.user
{
    partial class dlForgetPwd
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
            this.cRdGroup = new System.Windows.Forms.GroupBox();
            this.cLblValue = new System.Windows.Forms.Label();
            this.cTxtValue = new System.Windows.Forms.TextBox();
            this.cBtnSend = new System.Windows.Forms.Button();
            this.cBtnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            //  cRdGroup
            //
            this.cRdGroup.Location = new System.Drawing.Point(4, 4);
            this.cRdGroup.Name =  "cRdGroup";
            this.cRdGroup.Size = new System.Drawing.Size(100, 30);
            this.cRdGroup.TabIndex =  0;
            this.cRdGroup.TabStop = false; 
            this.cRdGroup.Text = "我记得";
            //
            //  cLblValue
            //
            this.cLblValue.AutoSize = true;
            this.cLblValue.Location = new System.Drawing.Point(112, 4);
            this.cLblValue.Name = "cLblValue";
            this.cLblValue.Size = new System.Drawing.Size(100,30);
            this.cLblValue.TabIndex = 0;
            this.cLblValue.Text = "用户名/手机号/邮箱";
            //
            //  cTxtValue
            //
            this.cTxtValue.Location = new System.Drawing.Point(220, 4);
            this.cTxtValue.Name = "cTxtValue";
            this.cTxtValue.Size = new System.Drawing.Size(100, 30);
            this.cTxtValue.TabIndex = 0;
            //
            //  cBtnSend
            //
            this.cBtnSend.Location = new System.Drawing.Point(328, 4);
            this.cBtnSend.Name = "cBtnSend";
            this.cBtnSend.Size = new System.Drawing.Size(100, 30);
            this.cBtnSend.TabIndex = 0;
            this.cBtnSend.Text = "发送验证码";
            this.cBtnSend.UseVisualStyleBackColor = true; 
            //
            //  cBtnCancel
            //
            this.cBtnCancel.Location = new System.Drawing.Point(436, 4);
            this.cBtnCancel.Name = "cBtnCancel";
            this.cBtnCancel.Size = new System.Drawing.Size(100, 30);
            this.cBtnCancel.TabIndex = 0;
            this.cBtnCancel.Text = "取消";
            this.cBtnCancel.UseVisualStyleBackColor = true; 
            //
            //  dlForgetPwd
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.cBtnCancel);
            this.Controls.Add(this.cBtnSend);
            this.Controls.Add(this.cTxtValue);
            this.Controls.Add(this.cLblValue);
            this.Controls.Add(this.cRdGroup);
            this.Name = "dlForgetPwd";
            this.Text = "密码找回窗体";
            this.ResumeLayout(false);
            this.PerformLayout();


        }
        
        #endregion

        private System.Windows.Forms.GroupBox cRdGroup;
        private System.Windows.Forms.Label cLblValue;
        private System.Windows.Forms.TextBox cTxtValue;
        private System.Windows.Forms.Button cBtnSend;
        private System.Windows.Forms.Button cBtnCancel;

        
    }
}