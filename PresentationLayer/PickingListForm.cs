using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderSystem.BusinessLayer;

namespace OrderSystem.PresentationLayer
{
    public partial class PickingListForm : Form
    {
        #region Attributes
        public bool listFormClosed = false;
        private OrderItemsController orderItemsController;
        private CustomerController customerController;
        private ProductController productController;
        private OrderController orderController;
        private EmployeeController employeeController;
        private Order order;
        private Employee employee;

        private Collection<OrderItems> orderItems;

        #endregion

        #region Constructor
        public PickingListForm(ProductController aProductController, CustomerController aCustomerController, EmployeeController anEmployeeController)
        {
            InitializeComponent();
            productController = aProductController;
            customerController = aCustomerController;
            employeeController = anEmployeeController;
            orderItemsController = new OrderItemsController();
            orderController = new OrderController();
            FillCombo();
            ItemsListView();
            HideAll(false);
        }      
        #endregion

        #region Form events
        private void PickingListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            listFormClosed = true;
        }

        #endregion

        #region Button Clicked Events
        private void doneButton_Click(object sender, EventArgs e)
        {
            printpreviewButton.Visible = true;
            if (order != null)
            {   
                if (MessageBox.Show("Are you sure you want to confirm order as picked?", "Confirming Order", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    printpreviewButton.Visible = true;
                    order.OrderValue = Order.OrderStatus.picked;
                    orderController.DataMaintenance(order, DatabaseLayer.DB.DBOperation.Edit);
                    orderController.FinalizeChanges(order);
                    ItemsListView();
                    ordersComboBox.SelectedIndex = -1;
                    ordersComboBox.Text = "";
                    order = null;
                }
                else
                {
                    this.Activate();
                }
            }

            else
            {
                MessageBox.Show("Cannot finilaze a order without generating a order list");
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close form?", "Closing form", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            order = default(Order);
            employee = default(Employee);
            order = (Order)ordersComboBox.SelectedItem;
            backButton.Visible = true;
            doneButton.Visible = true;
            if (order == null)
            {
                MessageBox.Show("First select an order to generate a picking list");
            }

            else
            {
                orderDateLabel.Text = Convert.ToString(order.OrderDate);
                Customer customer = customerController.Find(order.CustomerID);
                CustomerIDLabel.Text = customer.CustomerID ;
                CustomerNameLabel.Text = customer.Name + " " + customer.Surname;
                CustomerAddressLabel.Text = customer.CustomerAddress;
                orderIdLabel.Text = order.OrderID;
                employeeIDlabel.Text = "EMP001";
                HideAll(true);
                ItemsListView();
            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            PoppelprintPreviewDialog.Document = PoppelprintDocument;
            PoppelprintPreviewDialog.ShowDialog();
            orgprintButton.Visible = true;        
        }

        private void orgprintButton_Click(object sender, EventArgs e)
        {
            PoppelprintDialog.Document = PoppelprintDocument;
            if (PoppelprintDialog.ShowDialog() == DialogResult.OK)
            {
                PoppelprintDocument.Print();
            }
        }
        #endregion

        #region Methods
        public void HideAll(bool value)
        {
            orderDateLabel.Visible = value;
            CustomerIDLabel.Visible = value;
            CustomerNameLabel.Visible = value;
            CustomerAddressLabel.Visible = value;
            orderIdLabel.Visible = value;
            employeeIDlabel.Visible = value;
     
        }
        public void FillCombo()
        {
             Collection<Order> orders = new Collection<Order>();
             orderController = new OrderController();
             orders = orderController.FindByStatus(Order.OrderStatus.unpicked); 
             foreach (Order eachOrder in orders)
             {
                 ordersComboBox.Items.Add(eachOrder);
             }
            ordersComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            ordersComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            ordersComboBox.SelectedIndex = -1;
            ordersComboBox.Text = "";
        }
        
        public void ItemsListView()
        {
            ListViewItem itemDetails;
            order = (Order)ordersComboBox.SelectedItem;
            orderItemsListView.Clear();

            if (order == null)
            {
                orderItemsListView.View = View.Details;
                orderItemsListView.Columns.Insert(0, "Product ID", 133, HorizontalAlignment.Left);
                orderItemsListView.Columns.Insert(1, "Product Name", 140, HorizontalAlignment.Left);
                orderItemsListView.Columns.Insert(2, "Quantity", 133, HorizontalAlignment.Left);
            }
            else
            {
                orderItemsListView.View = View.Details;
                orderItemsListView.Columns.Insert(0, "Product ID", 133, HorizontalAlignment.Left);
                orderItemsListView.Columns.Insert(1, "Product Name", 140, HorizontalAlignment.Left);
                orderItemsListView.Columns.Insert(2, "Quantity", 133, HorizontalAlignment.Left);

                orderItems = null;
                orderItems = orderItemsController.FindByOrderID(order.OrderID);
                foreach (OrderItems item in orderItems)
                {
                    Product product = productController.Find(item.ProductID);
                    itemDetails = new ListViewItem();
                    itemDetails.Text = item.ProductID.ToString();
                    itemDetails.SubItems.Add(product.ProductName);
                    itemDetails.SubItems.Add(item.Quantity.ToString());
                    orderItemsListView.Items.Add(itemDetails);
                }
            }
            orderItemsListView.Refresh();
            orderItemsListView.GridLines = true;
        }

        #endregion

       
        #region Form states
        private void PickingListForm_Load(object sender, EventArgs e)
        {
            printpreviewButton.Visible = false;
            orgprintButton.Visible = false;
            doneButton.Visible = false;
            backButton.Visible = false;
        }
        #endregion

        #region Print Preview
        private void PoppelprintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("=================================================" + 
                                  "\n" +
                                  "               CUSTOMER DETAILS"+
                                  "\n" +
                                  "================================================="+
                                  "\n" + "\n"+ "Order Number :  " + orderIdLabel.Text +
                                  "\n" + "\n" + "Order Date   :  " + orderDateLabel.Text +
                                  "\n" + "\n" +  "Employee ID     :  " + employeeIDlabel.Text +
                                  "\n" + "\n" + "Customer ID   :  " + CustomerIDLabel.Text +
                                  "\n" + "\n" +  "Customer Name:  " + CustomerNameLabel.Text +
                                  "\n" + "\n" + "Delivary Address :  " + CustomerAddressLabel.Text +
                                  "\n" + "\n" +
                                  "====================================================" +   "\n" + "           PRODUCT DETAILS" +
                                  "\n" +
                                  "===================================================="
                                 , new Font("Courier New", 12, FontStyle.Regular), Brushes.Black, new Point(25, 150));         
            int y = 500;            
            int offset = 40;
            
            foreach (ListViewItem Itm in orderItemsListView.Items)
            {
                e.Graphics.DrawString("       POPPEL PICKING LIST", new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, 25, 120 );
                e.Graphics.DrawString("ProductID"  +"             Product Name" + "         Quantity", new Font("Courier New", 12, FontStyle.Regular), Brushes.Black, 25, 500);
                e.Graphics.DrawString(Itm.Text, new Font("Courier New", 12, FontStyle.Regular), Brushes.Black, 25, y + offset); 
                e.Graphics.DrawString(Itm.SubItems[1].Text, new Font("Courier New", 12, FontStyle.Regular), Brushes.Black, 250, y + offset); 
                e.Graphics.DrawString(Itm.SubItems[2].Text, new Font("Courier New", 12, FontStyle.Regular), Brushes.Black, 500, y + offset); 
                offset = offset + (int)FontHeight + 10;
               
            }
            offset = offset + 20;
        
        }
        #endregion        
    }
}
