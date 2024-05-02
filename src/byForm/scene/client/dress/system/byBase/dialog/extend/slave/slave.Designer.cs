/* 本文件由拜语言 IDE 自动生成，网址:http://www.baiyuyan.com/  生成时间:2024-04-30 02:43:05  */
namespace byBase.dress.extend
{
    partial class slave
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
            this.cEditArea = new System.Windows.Forms.FlowLayoutPanel();
            this.components = new System.ComponentModel.Container();
            this.cContextMenu = new System.Windows.Forms.ContextMenuStrip((this.components));
            this.SuspendLayout();
            //
            //  cEditArea
            //
            this.cEditArea.Location = new System.Drawing.Point(4, 4);
            this.cEditArea.Name =  "cEditArea";
            this.cEditArea.Size = new System.Drawing.Size(892, 592);
            this.cEditArea.TabIndex =  0;
            //
            //  cContextMenu
            //
            //
            //  slave
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.cEditArea);
            this.Name = "slave";
            this.Text = "本项只能拼入其他dialog中，仅支持一个单行的增删改";
            this.ResumeLayout(false);
            this.PerformLayout();


        }
        
        #endregion

        private System.Windows.Forms.FlowLayoutPanel cEditArea;
        private System.Windows.Forms.ContextMenuStrip cContextMenu;

        
    }
}