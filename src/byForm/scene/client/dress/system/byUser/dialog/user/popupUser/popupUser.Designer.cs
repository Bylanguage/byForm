/* 本文件由拜语言 IDE 自动生成，网址:http://www.baiyuyan.com/  生成时间:2024-04-30 02:43:05  */
namespace byUser.dress.user
{
    partial class popupUser
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
            this.cLblKeyword = new System.Windows.Forms.Label();
            this.cTxtKeyword = new System.Windows.Forms.TextBox();
            this.cBtnSearch = new System.Windows.Forms.Button();
            this.cGrid = new System.Windows.Forms.DataGridView();
            this.cBtnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cGrid)).BeginInit();
            this.SuspendLayout();
            //
            //  cLblKeyword
            //
            this.cLblKeyword.AutoSize = true;
            this.cLblKeyword.Location = new System.Drawing.Point(4, 4);
            this.cLblKeyword.Name = "cLblKeyword";
            this.cLblKeyword.Size = new System.Drawing.Size(100,30);
            this.cLblKeyword.TabIndex = 0;
            this.cLblKeyword.Text = "搜索";
            //
            //  cTxtKeyword
            //
            this.cTxtKeyword.Location = new System.Drawing.Point(112, 4);
            this.cTxtKeyword.Name = "cTxtKeyword";
            this.cTxtKeyword.Size = new System.Drawing.Size(100, 30);
            this.cTxtKeyword.TabIndex = 0;
            //
            //  cBtnSearch
            //
            this.cBtnSearch.Location = new System.Drawing.Point(220, 4);
            this.cBtnSearch.Name = "cBtnSearch";
            this.cBtnSearch.Size = new System.Drawing.Size(100, 30);
            this.cBtnSearch.TabIndex = 0;
            this.cBtnSearch.Text = "查询";
            this.cBtnSearch.UseVisualStyleBackColor = true; 
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
            this.cBtnOk.Location = new System.Drawing.Point(328, 4);
            this.cBtnOk.Name = "cBtnOk";
            this.cBtnOk.Size = new System.Drawing.Size(100, 30);
            this.cBtnOk.TabIndex = 0;
            this.cBtnOk.Text = "确认加入";
            this.cBtnOk.UseVisualStyleBackColor = true; 
            //
            //  popupUser
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.cBtnOk);
            this.Controls.Add(this.cGrid);
            this.Controls.Add(this.cBtnSearch);
            this.Controls.Add(this.cTxtKeyword);
            this.Controls.Add(this.cLblKeyword);
            this.Name = "popupUser";
            this.Text = "弹窗选择用户窗体";
            this.ResumeLayout(false);
            this.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cGrid)).EndInit();


        }
        
        #endregion

        private System.Windows.Forms.Label cLblKeyword;
        private System.Windows.Forms.TextBox cTxtKeyword;
        private System.Windows.Forms.Button cBtnSearch;
        private System.Windows.Forms.DataGridView cGrid;
        private System.Windows.Forms.Button cBtnOk;

        
    }
}