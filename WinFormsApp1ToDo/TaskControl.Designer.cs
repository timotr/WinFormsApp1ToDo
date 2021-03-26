
namespace WinFormsApp1ToDo
{
    partial class TaskControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.editBtn = new System.Windows.Forms.Button();
            this.titleTBox = new System.Windows.Forms.TextBox();
            this.descTBox = new System.Windows.Forms.RichTextBox();
            this.messageLbl = new System.Windows.Forms.Label();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pealkiri";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kirjeldus";
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(256, 171);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(75, 23);
            this.editBtn.TabIndex = 4;
            this.editBtn.Text = "Salvesta";
            this.editBtn.UseVisualStyleBackColor = true;
            // 
            // titleTBox
            // 
            this.titleTBox.Location = new System.Drawing.Point(8, 45);
            this.titleTBox.Name = "titleTBox";
            this.titleTBox.Size = new System.Drawing.Size(224, 23);
            this.titleTBox.TabIndex = 5;
            // 
            // descTBox
            // 
            this.descTBox.Location = new System.Drawing.Point(8, 98);
            this.descTBox.Name = "descTBox";
            this.descTBox.Size = new System.Drawing.Size(224, 96);
            this.descTBox.TabIndex = 6;
            this.descTBox.Text = "";
            // 
            // messageLbl
            // 
            this.messageLbl.AutoSize = true;
            this.messageLbl.ForeColor = System.Drawing.Color.OrangeRed;
            this.messageLbl.Location = new System.Drawing.Point(17, 8);
            this.messageLbl.Name = "messageLbl";
            this.messageLbl.Size = new System.Drawing.Size(0, 15);
            this.messageLbl.TabIndex = 7;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(256, 142);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 8;
            this.deleteBtn.Text = "Kustuta";
            this.deleteBtn.UseVisualStyleBackColor = true;
            // 
            // TaskControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.messageLbl);
            this.Controls.Add(this.descTBox);
            this.Controls.Add(this.titleTBox);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "TaskControl";
            this.Size = new System.Drawing.Size(359, 210);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button editBtn;
        public System.Windows.Forms.TextBox titleTBox;
        public System.Windows.Forms.RichTextBox descTBox;
        public System.Windows.Forms.Label messageLbl;
        public System.Windows.Forms.Button deleteBtn;
    }
}
