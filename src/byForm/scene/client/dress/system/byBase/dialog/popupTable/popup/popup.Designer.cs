/* 本文件由拜语言 IDE 自动生成，网址:http://www.baiyuyan.com/  生成时间:2024-04-30 02:43:05  */
namespace byBase.dress.popupTable
{
    partial class popup
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
            this.components = new System.ComponentModel.Container();
            this.cContextMenu = new System.Windows.Forms.ContextMenuStrip((this.components));
            this.cBtnQuery = new System.Windows.Forms.Button();
            this.cBtnComplete = new System.Windows.Forms.Button();
            this.cMQueryArea = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.cGrid)).BeginInit();
            this.SuspendLayout();
            //
            //  cGrid
            //
            this.cGrid.ColumnHeadersHeight = 29;
            this.cGrid.Location = new System.Drawing.Point(4, 229);
            this.cGrid.Name =  "cGrid";
            this.cGrid.RowTemplate.Height = 23;
            this.cGrid.Size = new System.Drawing.Size(892, 366);
            this.cGrid.TabIndex =  0;
            //
            //  cContextMenu
            //
            //
            //  cBtnQuery
            //
            this.cBtnQuery.Location = new System.Drawing.Point(4, 4);
            this.cBtnQuery.Name = "cBtnQuery";
            this.cBtnQuery.Size = new System.Drawing.Size(100, 30);
            this.cBtnQuery.TabIndex = 0;
            this.cBtnQuery.Text = "检索";
            this.cBtnQuery.UseVisualStyleBackColor = true; 
            //
            //  cBtnComplete
            //
            this.cBtnComplete.Location = new System.Drawing.Point(112, 4);
            this.cBtnComplete.Name = "cBtnComplete";
            this.cBtnComplete.Size = new System.Drawing.Size(100, 30);
            this.cBtnComplete.TabIndex = 0;
            this.cBtnComplete.Text = "完成";
            this.cBtnComplete.UseVisualStyleBackColor = true; 
            //
            //  cMQueryArea
            //
            this.cMQueryArea.Location = new System.Drawing.Point(4, 42);
            this.cMQueryArea.Name =  "cMQueryArea";
            this.cMQueryArea.Size = new System.Drawing.Size(892, 179);
            this.cMQueryArea.TabIndex =  0;
            //
            //  popup
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.cMQueryArea);
            this.Controls.Add(this.cBtnComplete);
            this.Controls.Add(this.cBtnQuery);
            this.Controls.Add(this.cGrid);
            this.Name = "popup";
            this.Text = "弹窗选择多行或一行";
            this.ResumeLayout(false);
            this.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cGrid)).EndInit();


        }
        
        #endregion

        private System.Windows.Forms.DataGridView cGrid;
        private System.Windows.Forms.ContextMenuStrip cContextMenu;
        private System.Windows.Forms.Button cBtnQuery;
        private System.Windows.Forms.Button cBtnComplete;
        private System.Windows.Forms.FlowLayoutPanel cMQueryArea;

        
    }
}