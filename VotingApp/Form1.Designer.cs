namespace VotingApp
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
            this.rbr = new System.Windows.Forms.TextBox();
            this.shortname = new System.Windows.Forms.TextBox();
            this.longname = new System.Windows.Forms.TextBox();
            this.rbglas = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.brglas = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.rezultati = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbr
            // 
            this.rbr.Location = new System.Drawing.Point(33, 50);
            this.rbr.Name = "rbr";
            this.rbr.Size = new System.Drawing.Size(276, 22);
            this.rbr.TabIndex = 0;
            // 
            // shortname
            // 
            this.shortname.Location = new System.Drawing.Point(33, 105);
            this.shortname.Name = "shortname";
            this.shortname.Size = new System.Drawing.Size(276, 22);
            this.shortname.TabIndex = 1;
            // 
            // longname
            // 
            this.longname.Location = new System.Drawing.Point(33, 158);
            this.longname.Name = "longname";
            this.longname.Size = new System.Drawing.Size(276, 22);
            this.longname.TabIndex = 2;
            // 
            // rbglas
            // 
            this.rbglas.Location = new System.Drawing.Point(36, 310);
            this.rbglas.Name = "rbglas";
            this.rbglas.Size = new System.Drawing.Size(158, 22);
            this.rbglas.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "р.бр.";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(33, 86);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(174, 16);
            this.label.TabIndex = 5;
            this.label.Text = "Скратено име на учесник";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Целосно име на учесник";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 204);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(276, 35);
            this.button1.TabIndex = 7;
            this.button1.Text = "Додај учесник на избори";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(36, 362);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(130, 22);
            this.numericUpDown1.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(36, 409);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 41);
            this.button2.TabIndex = 9;
            this.button2.Text = "Додај Гласови";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "р.бр.";
            // 
            // brglas
            // 
            this.brglas.AutoSize = true;
            this.brglas.Location = new System.Drawing.Point(33, 343);
            this.brglas.Name = "brglas";
            this.brglas.Size = new System.Drawing.Size(110, 16);
            this.brglas.TabIndex = 11;
            this.brglas.Text = "Број на гласови";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(445, 31);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(355, 244);
            this.listBox1.TabIndex = 12;
            // 
            // rezultati
            // 
            this.rezultati.AutoSize = true;
            this.rezultati.Location = new System.Drawing.Point(442, 310);
            this.rezultati.Name = "rezultati";
            this.rezultati.Size = new System.Drawing.Size(81, 16);
            this.rezultati.TabIndex = 13;
            this.rezultati.Text = "Резултати:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 482);
            this.Controls.Add(this.rezultati);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.brglas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbglas);
            this.Controls.Add(this.longname);
            this.Controls.Add(this.shortname);
            this.Controls.Add(this.rbr);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox rbr;
        private System.Windows.Forms.TextBox shortname;
        private System.Windows.Forms.TextBox longname;
        private System.Windows.Forms.TextBox rbglas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label brglas;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label rezultati;
    }
}

