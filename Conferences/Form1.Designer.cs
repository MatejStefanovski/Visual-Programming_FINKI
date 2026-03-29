namespace Conferences
{
    partial class Form1
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
            this.Конференции = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label = new System.Windows.Forms.Label();
            this.Конференции.SuspendLayout();
            this.SuspendLayout();
            // 
            // Конференции
            // 
            this.Конференции.Controls.Add(this.label);
            this.Конференции.Controls.Add(this.comboBox1);
            this.Конференции.Controls.Add(this.button2);
            this.Конференции.Controls.Add(this.button1);
            this.Конференции.Controls.Add(this.listBox1);
            this.Конференции.Location = new System.Drawing.Point(13, 13);
            this.Конференции.Name = "Конференции";
            this.Конференции.Size = new System.Drawing.Size(416, 553);
            this.Конференции.TabIndex = 0;
            this.Конференции.TabStop = false;
            this.Конференции.Text = "groupBox1";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(7, 35);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(403, 388);
            this.listBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 481);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(403, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Додади Конференција";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(7, 517);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(403, 30);
            this.button2.TabIndex = 2;
            this.button2.Text = "Избриши Конференција";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "2025",
            "2024",
            "2023"});
            this.comboBox1.Location = new System.Drawing.Point(7, 451);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(403, 24);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(7, 430);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(54, 16);
            this.label.TabIndex = 4;
            this.label.Text = "Година";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 578);
            this.Controls.Add(this.Конференции);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Конференции.ResumeLayout(false);
            this.Конференции.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Конференции;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
    }
}

