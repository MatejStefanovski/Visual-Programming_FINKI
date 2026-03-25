namespace ShoppingCart
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
            this.productlist = new System.Windows.Forms.ListBox();
            this.cart = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.TextBox();
            this.category = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.TextBox();
            this.addToCart = new System.Windows.Forms.Button();
            this.deleteFromCart = new System.Windows.Forms.Button();
            this.deleteProduct = new System.Windows.Forms.Button();
            this.addProduct = new System.Windows.Forms.Button();
            this.deleteProducts = new System.Windows.Forms.Button();
            this.DeleteCartProducts = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // productlist
            // 
            this.productlist.FormattingEnabled = true;
            this.productlist.ItemHeight = 16;
            this.productlist.Location = new System.Drawing.Point(12, 34);
            this.productlist.Name = "productlist";
            this.productlist.Size = new System.Drawing.Size(337, 388);
            this.productlist.TabIndex = 0;
            this.productlist.SelectedIndexChanged += new System.EventHandler(this.productlist_SelectedIndexChanged);
            // 
            // cart
            // 
            this.cart.FormattingEnabled = true;
            this.cart.ItemHeight = 16;
            this.cart.Location = new System.Drawing.Point(668, 34);
            this.cart.Name = "cart";
            this.cart.Size = new System.Drawing.Size(358, 356);
            this.cart.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.price);
            this.groupBox1.Controls.Add(this.category);
            this.groupBox1.Controls.Add(this.name);
            this.groupBox1.Location = new System.Drawing.Point(355, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 213);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Детали за продктот";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Цена";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Категорија";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Име";
            // 
            // price
            // 
            this.price.Enabled = false;
            this.price.Location = new System.Drawing.Point(20, 173);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(100, 22);
            this.price.TabIndex = 2;
            // 
            // category
            // 
            this.category.Enabled = false;
            this.category.Location = new System.Drawing.Point(20, 112);
            this.category.Name = "category";
            this.category.Size = new System.Drawing.Size(250, 22);
            this.category.TabIndex = 1;
            // 
            // name
            // 
            this.name.Enabled = false;
            this.name.Location = new System.Drawing.Point(20, 57);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(250, 22);
            this.name.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Листа на продукти:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(665, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Кошничка:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(665, 405);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Вкупно: ";
            // 
            // total
            // 
            this.total.Enabled = false;
            this.total.Location = new System.Drawing.Point(895, 405);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(131, 22);
            this.total.TabIndex = 6;
            // 
            // addToCart
            // 
            this.addToCart.Location = new System.Drawing.Point(375, 264);
            this.addToCart.Name = "addToCart";
            this.addToCart.Size = new System.Drawing.Size(273, 40);
            this.addToCart.TabIndex = 6;
            this.addToCart.Text = "Додади во кошничка";
            this.addToCart.UseVisualStyleBackColor = true;
            this.addToCart.Click += new System.EventHandler(this.addToCart_Click);
            // 
            // deleteFromCart
            // 
            this.deleteFromCart.Location = new System.Drawing.Point(375, 310);
            this.deleteFromCart.Name = "deleteFromCart";
            this.deleteFromCart.Size = new System.Drawing.Size(273, 37);
            this.deleteFromCart.TabIndex = 7;
            this.deleteFromCart.Text = "Избриши од кошничка";
            this.deleteFromCart.UseVisualStyleBackColor = true;
            this.deleteFromCart.Click += new System.EventHandler(this.deleteFromCart_Click);
            // 
            // deleteProduct
            // 
            this.deleteProduct.Location = new System.Drawing.Point(375, 394);
            this.deleteProduct.Name = "deleteProduct";
            this.deleteProduct.Size = new System.Drawing.Size(273, 38);
            this.deleteProduct.TabIndex = 9;
            this.deleteProduct.Text = "Избриши продукт";
            this.deleteProduct.UseVisualStyleBackColor = true;
            this.deleteProduct.Click += new System.EventHandler(this.deleteProduct_Click);
            // 
            // addProduct
            // 
            this.addProduct.Location = new System.Drawing.Point(375, 353);
            this.addProduct.Name = "addProduct";
            this.addProduct.Size = new System.Drawing.Size(273, 35);
            this.addProduct.TabIndex = 8;
            this.addProduct.Text = "Додади нов продукт";
            this.addProduct.UseVisualStyleBackColor = true;
            this.addProduct.Click += new System.EventHandler(this.addProduct_Click);
            // 
            // deleteProducts
            // 
            this.deleteProducts.Location = new System.Drawing.Point(12, 439);
            this.deleteProducts.Name = "deleteProducts";
            this.deleteProducts.Size = new System.Drawing.Size(337, 41);
            this.deleteProducts.TabIndex = 7;
            this.deleteProducts.Text = "Испразни ја листата со продукти";
            this.deleteProducts.UseVisualStyleBackColor = true;
            this.deleteProducts.Click += new System.EventHandler(this.button5_Click);
            // 
            // DeleteCartProducts
            // 
            this.DeleteCartProducts.Location = new System.Drawing.Point(668, 439);
            this.DeleteCartProducts.Name = "DeleteCartProducts";
            this.DeleteCartProducts.Size = new System.Drawing.Size(358, 41);
            this.DeleteCartProducts.TabIndex = 8;
            this.DeleteCartProducts.Text = "Испразни ја кошничката";
            this.DeleteCartProducts.UseVisualStyleBackColor = true;
            this.DeleteCartProducts.Click += new System.EventHandler(this.DeleteCartProducts_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 492);
            this.Controls.Add(this.deleteProduct);
            this.Controls.Add(this.DeleteCartProducts);
            this.Controls.Add(this.deleteProducts);
            this.Controls.Add(this.total);
            this.Controls.Add(this.addProduct);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.deleteFromCart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cart);
            this.Controls.Add(this.productlist);
            this.Controls.Add(this.addToCart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox productlist;
        private System.Windows.Forms.ListBox cart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.TextBox category;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox total;
        private System.Windows.Forms.Button addToCart;
        private System.Windows.Forms.Button deleteFromCart;
        private System.Windows.Forms.Button deleteProduct;
        private System.Windows.Forms.Button addProduct;
        private System.Windows.Forms.Button deleteProducts;
        private System.Windows.Forms.Button DeleteCartProducts;
    }
}

