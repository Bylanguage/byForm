/* 本文件由拜语言 IDE 自动生成，网址:http://www.baiyuyan.com/  生成时间:2024-04-30 02:43:05  */
namespace byBase.dress.detail
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
            ((System.ComponentModel.ISupportInitialize)(this.cGrid)).BeginInit();
            this.SuspendLayout();
            //
            //  cGrid
            //
            this.cGrid.ColumnHeadersHeight = 29;
            this.cGrid.Location = new System.Drawing.Point(4, 4);
            this.cGrid.Name =  "cGrid";
            this.cGrid.RowTemplate.Height = 23;
            this.cGrid.Size = new System.Drawing.Size(892, 592);
            this.cGrid.TabIndex =  0;
            //
            //  manage
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.cGrid);
            this.Name = "manage";
            this.Text = "manage";
            this.ResumeLayout(false);
            this.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cGrid)).EndInit();


        }
        
        #endregion

        private System.Windows.Forms.DataGridView cGrid;

        
    }
}