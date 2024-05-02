/* 本文件由拜语言 IDE 自动生成，网址:http://www.baiyuyan.com/  生成时间:2024-04-30 02:43:05  */
namespace byForm.dress.form
{
    partial class manage
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
            this.formManage = new System.Windows.Forms.Panel();
            this.cFieldTemplatePanel = new System.Windows.Forms.Panel();
            this.cFormPanel = new System.Windows.Forms.Panel();
            this.cFormNamePanel = new System.Windows.Forms.Panel();
            this.cFormNameValueLabel = new System.Windows.Forms.Label();
            this.cFieldPanel = new System.Windows.Forms.Panel();
            this.cDetailPanel = new System.Windows.Forms.Panel();
            this.buttonContainer = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.previewButton = new System.Windows.Forms.Button();
            this.publishButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.formManage.SuspendLayout();
            this.cFieldTemplatePanel.SuspendLayout();
            this.cFormPanel.SuspendLayout();
            this.cFormNamePanel.SuspendLayout();
            this.cFieldPanel.SuspendLayout();
            this.cDetailPanel.SuspendLayout();
            this.buttonContainer.SuspendLayout();
            this.SuspendLayout();
            //
            //  mainPanel
            //
            this.mainPanel.Location = new System.Drawing.Point(4, 4);
            this.mainPanel.Name =  "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(100, 30);
            this.mainPanel.TabIndex =  0;
            //
            //  formManage
            //
            this.formManage.Location = new System.Drawing.Point(112, 4);
            this.formManage.Name =  "formManage";
            this.formManage.Size = new System.Drawing.Size(100, 30);
            this.formManage.TabIndex =  0;
            //
            //  cFieldTemplatePanel
            //
            this.cFieldTemplatePanel.Location = new System.Drawing.Point(220, 4);
            this.cFieldTemplatePanel.Name =  "cFieldTemplatePanel";
            this.cFieldTemplatePanel.Size = new System.Drawing.Size(100, 30);
            this.cFieldTemplatePanel.TabIndex =  0;
            //
            //  cFormPanel
            //
            this.cFormPanel.Location = new System.Drawing.Point(328, 4);
            this.cFormPanel.Name =  "cFormPanel";
            this.cFormPanel.Size = new System.Drawing.Size(100, 30);
            this.cFormPanel.TabIndex =  0;
            //
            //  cFormNamePanel
            //
            this.cFormNamePanel.Location = new System.Drawing.Point(436, 4);
            this.cFormNamePanel.Name =  "cFormNamePanel";
            this.cFormNamePanel.Size = new System.Drawing.Size(100, 30);
            this.cFormNamePanel.TabIndex =  0;
            //
            //  cFormNameValueLabel
            //
            this.cFormNameValueLabel.AutoSize = true;
            this.cFormNameValueLabel.Location = new System.Drawing.Point(544, 4);
            this.cFormNameValueLabel.Name = "cFormNameValueLabel";
            this.cFormNameValueLabel.Size = new System.Drawing.Size(100,30);
            this.cFormNameValueLabel.TabIndex = 0;
            this.cFormNameValueLabel.Text = "当前编辑表单的名称";
            //
            //  cFieldPanel
            //
            this.cFieldPanel.Location = new System.Drawing.Point(652, 4);
            this.cFieldPanel.Name =  "cFieldPanel";
            this.cFieldPanel.Size = new System.Drawing.Size(100, 30);
            this.cFieldPanel.TabIndex =  0;
            //
            //  cDetailPanel
            //
            this.cDetailPanel.Location = new System.Drawing.Point(760, 4);
            this.cDetailPanel.Name =  "cDetailPanel";
            this.cDetailPanel.Size = new System.Drawing.Size(100, 30);
            this.cDetailPanel.TabIndex =  0;
            //
            //  buttonContainer
            //
            this.buttonContainer.Location = new System.Drawing.Point(4, 42);
            this.buttonContainer.Name =  "buttonContainer";
            this.buttonContainer.Size = new System.Drawing.Size(100, 30);
            this.buttonContainer.TabIndex =  0;
            //
            //  saveButton
            //
            this.saveButton.Location = new System.Drawing.Point(112, 42);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 30);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "表单保存键";
            this.saveButton.UseVisualStyleBackColor = true; 
            //
            //  previewButton
            //
            this.previewButton.Location = new System.Drawing.Point(220, 42);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(100, 30);
            this.previewButton.TabIndex = 0;
            this.previewButton.Text = "表单预览键";
            this.previewButton.UseVisualStyleBackColor = true; 
            //
            //  publishButton
            //
            this.publishButton.Location = new System.Drawing.Point(328, 42);
            this.publishButton.Name = "publishButton";
            this.publishButton.Size = new System.Drawing.Size(100, 30);
            this.publishButton.TabIndex = 0;
            this.publishButton.Text = "表单发布键";
            this.publishButton.UseVisualStyleBackColor = true; 
            //
            //  manage
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.publishButton);
            this.Controls.Add(this.previewButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.buttonContainer);
            this.Controls.Add(this.cDetailPanel);
            this.Controls.Add(this.cFieldPanel);
            this.Controls.Add(this.cFormNameValueLabel);
            this.Controls.Add(this.cFormNamePanel);
            this.Controls.Add(this.cFormPanel);
            this.Controls.Add(this.cFieldTemplatePanel);
            this.Controls.Add(this.formManage);
            this.Controls.Add(this.mainPanel);
            this.Name = "manage";
            this.Text = "表单编辑,可从左边拖动元素到中间区域  --基于拜语言技术构建";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.formManage.ResumeLayout(false);
            this.formManage.PerformLayout();
            this.cFieldTemplatePanel.ResumeLayout(false);
            this.cFieldTemplatePanel.PerformLayout();
            this.cFormPanel.ResumeLayout(false);
            this.cFormPanel.PerformLayout();
            this.cFormNamePanel.ResumeLayout(false);
            this.cFormNamePanel.PerformLayout();
            this.cFieldPanel.ResumeLayout(false);
            this.cFieldPanel.PerformLayout();
            this.cDetailPanel.ResumeLayout(false);
            this.cDetailPanel.PerformLayout();
            this.buttonContainer.ResumeLayout(false);
            this.buttonContainer.PerformLayout();


        }
        
        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel formManage;
        private System.Windows.Forms.Panel cFieldTemplatePanel;
        private System.Windows.Forms.Panel cFormPanel;
        private System.Windows.Forms.Panel cFormNamePanel;
        private System.Windows.Forms.Label cFormNameValueLabel;
        private System.Windows.Forms.Panel cFieldPanel;
        private System.Windows.Forms.Panel cDetailPanel;
        private System.Windows.Forms.Panel buttonContainer;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button previewButton;
        private System.Windows.Forms.Button publishButton;

        
    }
}