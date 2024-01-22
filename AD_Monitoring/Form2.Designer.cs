namespace AD_Monitoring
{
    partial class Form2
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
            SendMessageButton = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            textBox2 = new TextBox();
            CancelButton = new Button();
            label2 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // SendMessageButton
            // 
            SendMessageButton.BackColor = Color.White;
            SendMessageButton.FlatStyle = FlatStyle.Flat;
            SendMessageButton.Location = new Point(6, 168);
            SendMessageButton.Name = "SendMessageButton";
            SendMessageButton.Size = new Size(75, 23);
            SendMessageButton.TabIndex = 0;
            SendMessageButton.Text = "Send";
            SendMessageButton.UseVisualStyleBackColor = false;
            SendMessageButton.Click += SendMessageButton_Click;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(6, 37);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(241, 23);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 2;
            label1.Text = "Computer name:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(CancelFormButton);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(SendMessageButton);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Location = new Point(12, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(571, 200);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Location = new Point(267, 37);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(298, 154);
            textBox2.TabIndex = 6;
            // 
            // CancelButton
            // 
            CancelFormButton.BackColor = Color.White;
            CancelFormButton.FlatStyle = FlatStyle.Flat;
            CancelFormButton.Location = new Point(87, 168);
            CancelFormButton.Name = "CancelButton";
            CancelFormButton.Size = new Size(75, 23);
            CancelFormButton.TabIndex = 5;
            CancelFormButton.Text = "Cancel";
            CancelFormButton.UseVisualStyleBackColor = false;
            CancelFormButton.Click += CancelButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(267, 19);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 4;
            label2.Text = "Message text:";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(595, 216);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Messanger";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button SendMessageButton;
        private Label label1;
        private GroupBox groupBox1;
        private TextBox textBox2;
        private Button CancelFormButton;
        private Label label2;
        public TextBox textBox1;
    }
}