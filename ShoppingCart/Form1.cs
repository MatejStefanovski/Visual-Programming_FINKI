using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingCart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            productlist.Items.Clear();
        }

        private void addToCart_Click(object sender, EventArgs e)
        {
            if (productlist.SelectedItem == null) return;
            Product p = productlist.SelectedItem as Product;
            cart.Items.Add(p);
            productlist.Items.Remove(p);
            int sum = 0;
            for (int i = 0; i < cart.Items.Count; i++)
            {
                Product tmp = cart.Items[i] as Product;
                sum += tmp.Price;
            }
            total.Text= sum.ToString();
        }

        private void addProduct_Click(object sender, EventArgs e)
        {
            AddProductForm form = new AddProductForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                string name = form.name;
                string category = form.category;
                int price = form.price;
                Product p = new Product(name, category, price);
                productlist.Items.Add(p);
            }
        }

        private void deleteProduct_Click(object sender, EventArgs e)
        {
            productlist.Items.Remove(productlist.SelectedItem);
        }

        private void productlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productlist.SelectedItem == null) return;
            Product p = productlist.SelectedItem as Product;
            name.Text = p.Name;
            category.Text = p.Category;
            price.Text = p.Price.ToString();
        }

        private void deleteFromCart_Click(object sender, EventArgs e)
        {
            productlist.Items.Add(cart.SelectedItem);
            cart.Items.Remove(cart.SelectedItem);
            int sum = 0;
            for (int i = 0; i < cart.Items.Count; i++)
            {
                Product tmp = cart.Items[i] as Product;
                sum += tmp.Price;
            }
            total.Text = sum.ToString();
        }

        private void DeleteCartProducts_Click(object sender, EventArgs e)
        {
            cart.Items.Clear();
            total.Text = "";
        }
    }
}
