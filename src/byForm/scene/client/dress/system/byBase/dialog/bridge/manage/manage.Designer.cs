/* 本文件由拜语言 IDE 自动生成，网址:http://www.baiyuyan.com/  生成时间:2024-04-30 02:43:05  */
namespace byBase.dress.bridge
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
            this.cGridLeft = new System.Windows.Forms.DataGridView();
            this.cGridRight = new System.Windows.Forms.DataGridView();
            this.cBtnModif = new System.Windows.Forms.Button();
            this.cBtnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cGridLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cGridRight)).BeginInit();
            this.SuspendLayout();
            //
            //  cGridLeft
            //
            this.cGridLeft.ColumnHeadersHeight = 29;
            this.cGridLeft.Location = new System.Drawing.Point(4, 42);
            this.cGridLeft.Name =  "cGridLeft";
            this.cGridLeft.RowTemplate.Height = 23;
            this.cGridLeft.Size = new System.Drawing.Size(442, 554);
            this.cGridLeft.TabIndex =  0;
            //
            //  cGridRight
            //
            this.cGridRight.ColumnHeadersHeight = 29;
            this.cGridRight.Location = new System.Drawing.Point(454, 42);
            this.cGridRight.Name =  "cGridRight";
            this.cGridRight.RowTemplate.Height = 23;
            this.cGridRight.Size = new System.Drawing.Size(442, 554);
            this.cGridRight.TabIndex =  0;
            //
            //  cBtnModif
            //
            this.cBtnModif.Location = new System.Drawing.Point(4, 4);
            this.cBtnModif.Name = "cBtnModif";
            this.cBtnModif.Size = new System.Drawing.Size(100, 30);
            this.cBtnModif.TabIndex = 0;
            this.cBtnModif.Text = "修改";
            this.cBtnModif.UseVisualStyleBackColor = true; 
            //
            //  cBtnDelete
            //
            this.cBtnDelete.Location = new System.Drawing.Point(112, 4);
            this.cBtnDelete.Name = "cBtnDelete";
            this.cBtnDelete.Size = new System.Drawing.Size(100, 30);
            this.cBtnDelete.TabIndex = 0;
            this.cBtnDelete.Text = "删除";
            this.cBtnDelete.UseVisualStyleBackColor = true; 
            //
            //  manage
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.cBtnDelete);
            this.Controls.Add(this.cBtnModif);
            this.Controls.Add(this.cGridRight);
            this.Controls.Add(this.cGridLeft);
            this.Name = "manage";
            this.Text = "中间表管理";
            this.ResumeLayout(false);
            this.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cGridLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cGridRight)).EndInit();


        }
        
        #endregion

        private System.Windows.Forms.DataGridView cGridLeft;
        private System.Windows.Forms.DataGridView cGridRight;
        private System.Windows.Forms.Button cBtnModif;
        private System.Windows.Forms.Button cBtnDelete;

        
    }
}