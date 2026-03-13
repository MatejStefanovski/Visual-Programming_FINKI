using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LestBoxExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbStringToAdd.Text.Length > 0)
            {
                bool flag = false;
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    if (tbStringToAdd.Text.Equals(listBox1.Items[i]))
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag==false)
                {
                    listBox1.Items.Add(tbStringToAdd.Text);
                    tbStringToAdd.Clear();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1) 
            {
                String value = listBox1.SelectedItem.ToString();
                checkedListBox1.Items.Add(value);
                listBox1.Items.Remove(value);
            }
        }
    }
}
