﻿/* 本文件由拜语言 IDE 自动生成，网址:http://www.baiyuyan.com/  生成时间:2024-04-30 02:43:05  */
namespace byCommon.dress.relatedDialog
{
    partial class popupList
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
            this.cGrid = new System.Windows.Forms.DataGridView();
            this.cBtnOk = new System.Windows.Forms.Button();
            this.cBtnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cGrid)).BeginInit();
            this.SuspendLayout();
            //
            //  cGrid
            //
            this.cGrid.ColumnHeadersHeight = 29;
            this.cGrid.Location = new System.Drawing.Point(4, 42);
            this.cGrid.Name =  "cGrid";
            this.cGrid.RowTemplate.Height = 23;
            this.cGrid.Size = new System.Drawing.Size(892, 554);
            this.cGrid.TabIndex =  0;
            //
            //  cBtnOk
            //
            this.cBtnOk.Location = new System.Drawing.Point(4, 4);
            this.cBtnOk.Name = "cBtnOk";
            this.cBtnOk.Size = new System.Drawing.Size(100, 30);
            this.cBtnOk.TabIndex = 0;
            this.cBtnOk.Text = "确认";
            this.cBtnOk.UseVisualStyleBackColor = true; 
            //
            //  cBtnCancel
            //
            this.cBtnCancel.Location = new System.Drawing.Point(112, 4);
            this.cBtnCancel.Name = "cBtnCancel";
            this.cBtnCancel.Size = new System.Drawing.Size(100, 30);
            this.cBtnCancel.TabIndex = 0;
            this.cBtnCancel.Text = "取消";
            this.cBtnCancel.UseVisualStyleBackColor = true; 
            //
            //  popupList
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.cBtnCancel);
            this.Controls.Add(this.cBtnOk);
            this.Controls.Add(this.cGrid);
            this.Name = "popupList";
            this.Text = "请选择列表,展示一个选择列表";
            this.ResumeLayout(false);
            this.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cGrid)).EndInit();


        }
        
        #endregion

        private System.Windows.Forms.DataGridView cGrid;
        private System.Windows.Forms.Button cBtnOk;
        private System.Windows.Forms.Button cBtnCancel;

        
    }
}