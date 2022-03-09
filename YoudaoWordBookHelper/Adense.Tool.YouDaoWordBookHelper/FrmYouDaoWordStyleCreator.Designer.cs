namespace Adense.Tool.YouDaoWordBookHelper
{
    partial class FrmYouDaoWordStyleCreator
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
            this.lblResponse = new System.Windows.Forms.Label();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lblWordBookFilePath = new System.Windows.Forms.Label();
            this.openFileDialogWordBook = new System.Windows.Forms.OpenFileDialog();
            this.lblContent = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.saveFileDialogCreator = new System.Windows.Forms.SaveFileDialog();
            this.lblBookName = new System.Windows.Forms.Label();
            this.txtBookName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblResponse
            // 
            this.lblResponse.AutoSize = true;
            this.lblResponse.Location = new System.Drawing.Point(67, 289);
            this.lblResponse.Name = "lblResponse";
            this.lblResponse.Size = new System.Drawing.Size(65, 12);
            this.lblResponse.TabIndex = 16;
            this.lblResponse.Text = "操作结果：";
            // 
            // txtResponse
            // 
            this.txtResponse.Location = new System.Drawing.Point(136, 289);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.Size = new System.Drawing.Size(625, 139);
            this.txtResponse.TabIndex = 15;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(136, 445);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 11;
            this.btnCreate.Text = "生  成";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lblWordBookFilePath
            // 
            this.lblWordBookFilePath.AutoSize = true;
            this.lblWordBookFilePath.Location = new System.Drawing.Point(79, 23);
            this.lblWordBookFilePath.Name = "lblWordBookFilePath";
            this.lblWordBookFilePath.Size = new System.Drawing.Size(53, 12);
            this.lblWordBookFilePath.TabIndex = 9;
            this.lblWordBookFilePath.Text = "单词本：";
            // 
            // openFileDialogWordBook
            // 
            this.openFileDialogWordBook.FileName = "openFileDialogYouDao";
            this.openFileDialogWordBook.Title = "打开文件";
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Location = new System.Drawing.Point(67, 68);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(65, 12);
            this.lblContent.TabIndex = 16;
            this.lblContent.Text = "文本内容：";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(136, 68);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContent.Size = new System.Drawing.Size(625, 158);
            this.txtContent.TabIndex = 15;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(325, 18);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 11;
            this.btnOpen.Text = "打开文件";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(136, 20);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(183, 21);
            this.txtFilePath.TabIndex = 17;
            // 
            // saveFileDialogCreator
            // 
            this.saveFileDialogCreator.DefaultExt = "\"*.txt\"";
            // 
            // lblBookName
            // 
            this.lblBookName.AutoSize = true;
            this.lblBookName.Location = new System.Drawing.Point(55, 241);
            this.lblBookName.Name = "lblBookName";
            this.lblBookName.Size = new System.Drawing.Size(77, 12);
            this.lblBookName.TabIndex = 18;
            this.lblBookName.Text = "单词本名称：";
            // 
            // txtBookName
            // 
            this.txtBookName.Location = new System.Drawing.Point(138, 238);
            this.txtBookName.Name = "txtBookName";
            this.txtBookName.Size = new System.Drawing.Size(183, 21);
            this.txtBookName.TabIndex = 19;
            // 
            // FrmYouDaoWordStyleCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 501);
            this.Controls.Add(this.txtBookName);
            this.Controls.Add(this.lblBookName);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.lblResponse);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.txtResponse);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lblWordBookFilePath);
            this.MaximizeBox = false;
            this.Name = "FrmYouDaoWordStyleCreator";
            this.Text = "FrmYouDaoWordStyleCreator";
            this.Load += new System.EventHandler(this.FrmYouDaoWordStyleCreator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblResponse;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblWordBookFilePath;
        private System.Windows.Forms.OpenFileDialog openFileDialogWordBook;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.SaveFileDialog saveFileDialogCreator;
        private System.Windows.Forms.Label lblBookName;
        private System.Windows.Forms.TextBox txtBookName;
    }
}