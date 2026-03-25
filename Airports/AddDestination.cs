using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airports
{
    public partial class AddDestination : Form
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Distance { get; set; }
        public AddDestination()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Name = textBox1.Text;
            Distance = (int)numericUpDown1.Value;
            Price = (int)numericUpDown2.Value;
            DialogResult = DialogResult.OK;
        }
    }
}
