using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ShoppingCart
{
    public partial class AddProductForm : Form
    {
        public string name { get; set; }
        public string category { get; set; }
        public int  price { get; set; }
        public AddProductForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
            category=textBox2.Text;
            price = int.Parse(textBox3.Text);
            DialogResult=DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Внесете име!");
            }
            else
            {
                errorProvider1.SetError(textBox1, null);
            }
        }
    }
}
