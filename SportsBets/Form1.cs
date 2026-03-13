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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Form1_Load);
            listBox1.SelectionMode = SelectionMode.MultiExtended;
            comboBox1.Items.Add("1");
            comboBox1.Items.Add("X");
            comboBox1.Items.Add("2");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add(new Team("Barcelona", "Spain"));
            listBox1.Items.Add(new Team("Real Madrid", "Spain"));
            listBox1.Items.Add(new Team("Vardar", "Macedonia"));
        }
        private void btnAddNewTeam_Click(object sender, EventArgs e)
        {
            TeamForm teamForm = new TeamForm();
            DialogResult result = teamForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                listBox1.Items.Add(teamForm.CreatedTeam);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 2)
            {
                Team team1 = listBox1.SelectedItems[0] as Team;
                Team team2 = listBox1.SelectedItems[1] as Team;
                if (team1.Country != team2.Country)
                {
                    MessageBox.Show("Избраните тимови мора да се од иста држава");
                }
                else
                {
                    Game game = new Game(mtbCode.Text, team1, team2, numericUpDown1.Value, numericUpDown2.Value, numericUpDown3.Value);
                    listBox2.Items.Add(game);
                    listBox1.ClearSelected();
                    numericUpDown1.Value = 1.0M;
                    numericUpDown2.Value = 1.0M;
                    numericUpDown3.Value = 1.0M;
                    mtbCode.Clear();
                }
            }
            else
            {
                MessageBox.Show("Мора да имате изберено 2 тима");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            listBox2.SelectedItems.Clear();
            string codeToSearch = textBox2.Text;
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                Game game = listBox2.Items[i] as Game;
                if (game.Name == codeToSearch)
                {
                    listBox2.SelectedIndex = i;
                    break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1 && comboBox1.SelectedIndex != -1)
            {
                Game game = listBox2.SelectedItem as Game;
                int tip;
                if (comboBox1.Text == "1")
                {
                    tip = 0;
                }
                else if (comboBox1.Text == "X")
                {
                    tip = 1;
                }
                else
                {
                    tip = 2;
                }
                GameForTicket gameForTicket = new GameForTicket(game, tip);
                listBox3.Items.Add(gameForTicket);
                listBox2.ClearSelected();
                textBox2.Clear();
            }
        }
    }
}

