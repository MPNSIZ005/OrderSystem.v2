using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using OrderSystem.BusinessLayer;

namespace OrderSystem.PresentationLayer
{
    public partial class CatalogueForm : Form
    {
        public bool catalogueClosed = false;
        private ProductController productController;
        public CatalogueForm(ProductController aProductController)
        {
            productController = aProductController;
            InitializeComponent();
            SetUp();
        }

        public void SetUp()
        {
            ListViewItem itemDetails;
            itemsListView.Clear();

            itemsListView.View = View.Details;
            itemsListView.Columns.Insert(0, "Product ID", 125, HorizontalAlignment.Left);
            itemsListView.Columns.Insert(1, "Product Name", 125, HorizontalAlignment.Left);
            itemsListView.Columns.Insert(2, "Price", 125, HorizontalAlignment.Left);
            itemsListView.Columns.Insert(3, "Quantity In Stock", 125, HorizontalAlignment.Left);
            Collection<Product> allProducts = productController.AllProducts;

            foreach (Product eachProduct in allProducts)
            {
                itemDetails = new ListViewItem();
                itemDetails.Text = eachProduct.ProductID;
                itemDetails.SubItems.Add(eachProduct.ProductName);
                itemDetails.SubItems.Add("R " + eachProduct.Price.ToString());
                itemDetails.SubItems.Add(eachProduct.QuantityInStock.ToString());
                itemsListView.Items.Add(itemDetails);
            }

            itemsListView.Refresh();
            itemsListView.GridLines = true;
        }
        
        private void closeButton_Click(object sender, EventArgs e)
        {
            catalogueClosed = true;
            this.Close();
        }

    }
}
