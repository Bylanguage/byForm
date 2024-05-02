/* 本文件由拜语言 IDE 自动生成，网址:http://www.baiyuyan.com/  生成时间:2024-04-30 02:43:05  */
namespace byForm.dress.form
{
    partial class formsManager
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.operateArea = new System.Windows.Forms.Panel();
            this.displayArea = new System.Windows.Forms.Panel();
            this.formsHeader = new System.Windows.Forms.Panel();
            this.formListLabel = new System.Windows.Forms.Label();
            this.formListPanel = new System.Windows.Forms.Panel();
            this.createFormButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.operateArea.SuspendLayout();
            this.displayArea.SuspendLayout();
            this.formsHeader.SuspendLayout();
            this.formListPanel.SuspendLayout();
            this.SuspendLayout();
            //
            //  mainPanel
            //
            this.mainPanel.Location = new System.Drawing.Point(4, 4);
            this.mainPanel.Name =  "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(100, 30);
            this.mainPanel.TabIndex =  0;
            //
            //  operateArea
            //
            this.operateArea.Location = new System.Drawing.Point(112, 4);
            this.operateArea.Name =  "operateArea";
            this.operateArea.Size = new System.Drawing.Size(100, 30);
            this.operateArea.TabIndex =  0;
            //
            //  displayArea
            //
            this.displayArea.Location = new System.Drawing.Point(220, 4);
            this.displayArea.Name =  "displayArea";
            this.displayArea.Size = new System.Drawing.Size(100, 30);
            this.displayArea.TabIndex =  0;
            //
            //  formsHeader
            //
            this.formsHeader.Location = new System.Drawing.Point(328, 4);
            this.formsHeader.Name =  "formsHeader";
            this.formsHeader.Size = new System.Drawing.Size(100, 30);
            this.formsHeader.TabIndex =  0;
            //
            //  formListLabel
            //
            this.formListLabel.AutoSize = true;
            this.formListLabel.Location = new System.Drawing.Point(436, 4);
            this.formListLabel.Name = "formListLabel";
            this.formListLabel.Size = new System.Drawing.Size(100,30);
            this.formListLabel.TabIndex = 0;
            this.formListLabel.Text = "表单列表标签";
            //
            //  formListPanel
            //
            this.formListPanel.Location = new System.Drawing.Point(544, 4);
            this.formListPanel.Name =  "formListPanel";
            this.formListPanel.Size = new System.Drawing.Size(100, 30);
            this.formListPanel.TabIndex =  0;
            //
            //  createFormButton
            //
            this.createFormButton.Location = new System.Drawing.Point(652, 4);
            this.createFormButton.Name = "createFormButton";
            this.createFormButton.Size = new System.Drawing.Size(100, 30);
            this.createFormButton.TabIndex = 0;
            this.createFormButton.Text = "创建表单键";
            this.createFormButton.UseVisualStyleBackColor = true; 
            //
            //  formsManager
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.createFormButton);
            this.Controls.Add(this.formListPanel);
            this.Controls.Add(this.formListLabel);
            this.Controls.Add(this.formsHeader);
            this.Controls.Add(this.displayArea);
            this.Controls.Add(this.operateArea);
            this.Controls.Add(this.mainPanel);
            this.Name = "formsManager";
            this.Text = "管理用户的所有表单";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.operateArea.ResumeLayout(false);
            this.operateArea.PerformLayout();
            this.displayArea.ResumeLayout(false);
            this.displayArea.PerformLayout();
            this.formsHeader.ResumeLayout(false);
            this.formsHeader.PerformLayout();
            this.formListPanel.ResumeLayout(false);
            this.formListPanel.PerformLayout();


        }
        
        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel operateArea;
        private System.Windows.Forms.Panel displayArea;
        private System.Windows.Forms.Panel formsHeader;
        private System.Windows.Forms.Label formListLabel;
        private System.Windows.Forms.Panel formListPanel;
        private System.Windows.Forms.Button createFormButton;

        
    }
}