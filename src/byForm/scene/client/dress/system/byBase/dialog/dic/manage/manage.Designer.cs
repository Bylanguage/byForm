/* 本文件由拜语言 IDE 自动生成，网址:http://www.baiyuyan.com/  生成时间:2024-04-30 02:43:05  */
namespace byBase.dress.dic
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
            this.cGrid = new System.Windows.Forms.DataGridView();
            this.cBtnQuery = new System.Windows.Forms.Button();
            this.cBtnAdd = new System.Windows.Forms.Button();
            this.cBtnDelete = new System.Windows.Forms.Button();
            this.cBtnModify = new System.Windows.Forms.Button();
            this.cBtnSave = new System.Windows.Forms.Button();
            this.cBtnCancel = new System.Windows.Forms.Button();
            this.cQueryArea = new System.Windows.Forms.FlowLayoutPanel();
            this.cEditArea = new System.Windows.Forms.FlowLayoutPanel();
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
            //  cBtnQuery
            //
            this.cBtnQuery.Location = new System.Drawing.Point(4, 4);
            this.cBtnQuery.Name = "cBtnQuery";
            this.cBtnQuery.Size = new System.Drawing.Size(100, 30);
            this.cBtnQuery.TabIndex = 0;
            this.cBtnQuery.Text = "检索";
            this.cBtnQuery.UseVisualStyleBackColor = true; 
            //
            //  cBtnAdd
            //
            this.cBtnAdd.Location = new System.Drawing.Point(112, 4);
            this.cBtnAdd.Name = "cBtnAdd";
            this.cBtnAdd.Size = new System.Drawing.Size(100, 30);
            this.cBtnAdd.TabIndex = 0;
            this.cBtnAdd.Text = "增加";
            this.cBtnAdd.UseVisualStyleBackColor = true; 
            //
            //  cBtnDelete
            //
            this.cBtnDelete.Location = new System.Drawing.Point(220, 4);
            this.cBtnDelete.Name = "cBtnDelete";
            this.cBtnDelete.Size = new System.Drawing.Size(100, 30);
            this.cBtnDelete.TabIndex = 0;
            this.cBtnDelete.Text = "删除";
            this.cBtnDelete.UseVisualStyleBackColor = true; 
            //
            //  cBtnModify
            //
            this.cBtnModify.Location = new System.Drawing.Point(328, 4);
            this.cBtnModify.Name = "cBtnModify";
            this.cBtnModify.Size = new System.Drawing.Size(100, 30);
            this.cBtnModify.TabIndex = 0;
            this.cBtnModify.Text = "修改";
            this.cBtnModify.UseVisualStyleBackColor = true; 
            //
            //  cBtnSave
            //
            this.cBtnSave.Location = new System.Drawing.Point(436, 4);
            this.cBtnSave.Name = "cBtnSave";
            this.cBtnSave.Size = new System.Drawing.Size(100, 30);
            this.cBtnSave.TabIndex = 0;
            this.cBtnSave.Text = "保存";
            this.cBtnSave.UseVisualStyleBackColor = true; 
            //
            //  cBtnCancel
            //
            this.cBtnCancel.Location = new System.Drawing.Point(544, 4);
            this.cBtnCancel.Name = "cBtnCancel";
            this.cBtnCancel.Size = new System.Drawing.Size(100, 30);
            this.cBtnCancel.TabIndex = 0;
            this.cBtnCancel.Text = "取消";
            this.cBtnCancel.UseVisualStyleBackColor = true; 
            //
            //  cQueryArea
            //
            this.cQueryArea.Location = new System.Drawing.Point(4, 42);
            this.cQueryArea.Name =  "cQueryArea";
            this.cQueryArea.Size = new System.Drawing.Size(442, 179);
            this.cQueryArea.TabIndex =  0;
            //
            //  cEditArea
            //
            this.cEditArea.Location = new System.Drawing.Point(454, 42);
            this.cEditArea.Name =  "cEditArea";
            this.cEditArea.Size = new System.Drawing.Size(442, 179);
            this.cEditArea.TabIndex =  0;
            //
            //  manage
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.cEditArea);
            this.Controls.Add(this.cQueryArea);
            this.Controls.Add(this.cBtnCancel);
            this.Controls.Add(this.cBtnSave);
            this.Controls.Add(this.cBtnModify);
            this.Controls.Add(this.cBtnDelete);
            this.Controls.Add(this.cBtnAdd);
            this.Controls.Add(this.cBtnQuery);
            this.Controls.Add(this.cGrid);
            this.Name = "manage";
            this.Text = "字典表";
            this.ResumeLayout(false);
            this.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cGrid)).EndInit();


        }
        
        #endregion

        private System.Windows.Forms.DataGridView cGrid;
        private System.Windows.Forms.Button cBtnQuery;
        private System.Windows.Forms.Button cBtnAdd;
        private System.Windows.Forms.Button cBtnDelete;
        private System.Windows.Forms.Button cBtnModify;
        private System.Windows.Forms.Button cBtnSave;
        private System.Windows.Forms.Button cBtnCancel;
        private System.Windows.Forms.FlowLayoutPanel cQueryArea;
        private System.Windows.Forms.FlowLayoutPanel cEditArea;

        
    }
}