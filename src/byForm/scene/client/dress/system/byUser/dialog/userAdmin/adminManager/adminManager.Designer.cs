/* 本文件由拜语言 IDE 自动生成，网址:http://www.baiyuyan.com/  生成时间:2024-04-30 02:43:05  */
namespace byUser.dress.userAdmin
{
    partial class adminManager
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
            this.cBtnAdd = new System.Windows.Forms.Button();
            this.cBtnDelete = new System.Windows.Forms.Button();
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
            //  cBtnAdd
            //
            this.cBtnAdd.Location = new System.Drawing.Point(4, 4);
            this.cBtnAdd.Name = "cBtnAdd";
            this.cBtnAdd.Size = new System.Drawing.Size(100, 30);
            this.cBtnAdd.TabIndex = 0;
            this.cBtnAdd.Text = "确认加入";
            this.cBtnAdd.UseVisualStyleBackColor = true; 
            //
            //  cBtnDelete
            //
            this.cBtnDelete.Location = new System.Drawing.Point(112, 4);
            this.cBtnDelete.Name = "cBtnDelete";
            this.cBtnDelete.Size = new System.Drawing.Size(100, 30);
            this.cBtnDelete.TabIndex = 0;
            this.cBtnDelete.Text = "确认删除";
            this.cBtnDelete.UseVisualStyleBackColor = true; 
            //
            //  adminManager
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.cBtnDelete);
            this.Controls.Add(this.cBtnAdd);
            this.Controls.Add(this.cGrid);
            this.Name = "adminManager";
            this.Text = "管理员管理窗体";
            this.ResumeLayout(false);
            this.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cGrid)).EndInit();


        }
        
        #endregion

        private System.Windows.Forms.DataGridView cGrid;
        private System.Windows.Forms.Button cBtnAdd;
        private System.Windows.Forms.Button cBtnDelete;

        
    }
}