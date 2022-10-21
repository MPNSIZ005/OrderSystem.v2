using System;
using System.Windows.Forms;
using OrderSystem.BusinessLayer;
using System.Collections.ObjectModel;

namespace OrderSystem.PresentationLayer
{
    public partial class CustomerForm : Form
    {
        public bool customersClosed = false;
        private CustomerController customerController;
        public CustomerForm(CustomerController customerController)
        {
            this.customerController = customerController;
            InitializeComponent();
            SetUp();
        }

        public void SetUp()
        {
            ListViewItem itemDetails;
            itemslistViewCustomers.Clear();
            itemslistViewCustomers.View = View.Details;
            itemslistViewCustomers.Columns.Insert(0, "Customer ID", 125, HorizontalAlignment.Left);
            itemslistViewCustomers.Columns.Insert(1, "Name", 125, HorizontalAlignment.Left);
            itemslistViewCustomers.Columns.Insert(2, "Surname", 125, HorizontalAlignment.Left);
            itemslistViewCustomers.Columns.Insert(3, "Phone", 125, HorizontalAlignment.Left);
            itemslistViewCustomers.Columns.Insert(3, "Address", 125, HorizontalAlignment.Left);
            Collection<Customer> allCustomers = customerController.AllCustomers;
            foreach (Customer eachCustomer in allCustomers)
            {
                itemDetails = new ListViewItem();
                itemDetails.Text = eachCustomer.CustomerID;
                itemDetails.SubItems.Add(eachCustomer.Name);
                itemDetails.SubItems.Add(eachCustomer.Surname);
                itemDetails.SubItems.Add(eachCustomer.Phone);
                itemDetails.SubItems.Add(eachCustomer.CustomerAddress);
                itemslistViewCustomers.Items.Add(itemDetails);
            }
            itemslistViewCustomers.Refresh();
            itemslistViewCustomers.GridLines = true;
        }

        private void CustomerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            customersClosed = true;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            customersClosed = true;
            this.Close();
        }
    }
}
