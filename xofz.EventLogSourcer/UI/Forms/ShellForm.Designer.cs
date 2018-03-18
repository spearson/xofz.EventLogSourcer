namespace xofz.EventLogSourcer.UI.Forms
{
    partial class ShellForm
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.createSourceKey = new System.Windows.Forms.Button();
            this.logNameTextBox = new System.Windows.Forms.TextBox();
            this.sourceNameTextBox = new System.Windows.Forms.TextBox();
            this.deleteSourceKey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Log Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Source Name:";
            // 
            // createSourceKey
            // 
            this.createSourceKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.createSourceKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.createSourceKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createSourceKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createSourceKey.Location = new System.Drawing.Point(112, 76);
            this.createSourceKey.Name = "createSourceKey";
            this.createSourceKey.Size = new System.Drawing.Size(160, 54);
            this.createSourceKey.TabIndex = 2;
            this.createSourceKey.Text = "Create";
            this.createSourceKey.UseVisualStyleBackColor = true;
            this.createSourceKey.Click += new System.EventHandler(this.createSourceKey_Click);
            // 
            // logNameTextBox
            // 
            this.logNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logNameTextBox.Location = new System.Drawing.Point(112, 12);
            this.logNameTextBox.Name = "logNameTextBox";
            this.logNameTextBox.Size = new System.Drawing.Size(160, 26);
            this.logNameTextBox.TabIndex = 0;
            this.logNameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.logNameTextBox_KeyPress);
            // 
            // sourceNameTextBox
            // 
            this.sourceNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceNameTextBox.Location = new System.Drawing.Point(112, 44);
            this.sourceNameTextBox.Name = "sourceNameTextBox";
            this.sourceNameTextBox.Size = new System.Drawing.Size(160, 26);
            this.sourceNameTextBox.TabIndex = 1;
            this.sourceNameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sourceNameTextBox_KeyPress);
            // 
            // deleteSourceKey
            // 
            this.deleteSourceKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.deleteSourceKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.deleteSourceKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteSourceKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteSourceKey.Location = new System.Drawing.Point(112, 136);
            this.deleteSourceKey.Name = "deleteSourceKey";
            this.deleteSourceKey.Size = new System.Drawing.Size(160, 54);
            this.deleteSourceKey.TabIndex = 3;
            this.deleteSourceKey.Text = "Delete";
            this.deleteSourceKey.UseVisualStyleBackColor = true;
            this.deleteSourceKey.Click += new System.EventHandler(this.deleteSourceKey_Click);
            // 
            // ShellForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(284, 202);
            this.Controls.Add(this.deleteSourceKey);
            this.Controls.Add(this.sourceNameTextBox);
            this.Controls.Add(this.logNameTextBox);
            this.Controls.Add(this.createSourceKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ShellForm";
            this.Text = "Event Log Sourcer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button createSourceKey;
        private System.Windows.Forms.TextBox logNameTextBox;
        private System.Windows.Forms.TextBox sourceNameTextBox;
        private System.Windows.Forms.Button deleteSourceKey;
    }
}

