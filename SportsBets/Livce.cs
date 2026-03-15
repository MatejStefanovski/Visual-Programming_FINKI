using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportsBets
{
    public partial class Livce : Form
    {
        public List<GameForTicket> Games { get; set; }

        public decimal Amount { get; set; }

        public decimal TotalCoef { get; set; }

        public decimal Profit { get; set; }


        public Livce()
        {
            InitializeComponent();
        }

        public Livce(List<GameForTicket> games, decimal amount, decimal totalCoef, decimal profit)
        {
            Games = games;
            Amount = amount;
            TotalCoef = totalCoef;
            Profit = profit;

            textBox4.Text = Profit.ToString();
            textBox3.Text = Amount.ToString();
            textBox1.Text = Profit.ToString();
            decimal tax = profit * 0.1M;
            textBox2.Text = tax.ToString();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
