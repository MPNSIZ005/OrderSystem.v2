using System.Collections.ObjectModel;
using System.Windows.Forms;

using OrderSystem.BusinessLayer;

namespace OrderSystem.PresentationLayer
{
    public partial class OrderForm : Form
    {
        #region Data Members
        private OrderItemsController orderItemsController;
        private CustomerController customerController;
        private ProductController productController;
        private OrderController orderController;
        private EmployeeController employeeController;

        private Collection<Product> products;
        private PickingListForm pickingListForm;
        private OrderItems changingItem;
        private Customer customer;
        private Product product;
        private Order order;

        private int customerCurrentCredit;
        private bool orderInProgress = false;
        public bool orderFormClosed = false;
        private bool close = false;

        #endregion

        #region Constructor
        public OrderForm(CustomerController aCustomerController, Customer aCustomer)
        {
            InitializeComponent();
            customer = aCustomer;
            customerController = aCustomerController;
            orderItemsController = new OrderItemsController();
            productController = new ProductController();
            orderController = new OrderController();
            SetUp();
            FillCombo();
            ShowButtons(false);
            ItemsListView();

        }
        #endregion

        #region Form events
        private void OrderForm_FormClosing(object sender, FormClosingEventArgs e)
        {   
            

            if (MessageBox.Show("Are you sure you want cancel the order?", "Canceling Order", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (close == true)
                {
                    CreateOrderForm createOrderForm = new CreateOrderForm(customerController);
                    createOrderForm.Show();
                }

                if (orderInProgress == true) { 
                    Collection<OrderItems> deletingItems = orderItemsController.FindByOrderID(order.OrderID);

                    foreach (OrderItems eachItem in deletingItems)                               
                    {
                        Product eachProduct = productController.Find(eachItem.ProductID);        
                        eachProduct.QuantityInStock += eachItem.Quantity;

                        orderItemsController.DataMaintenance(eachItem, DatabaseLayer.DB.DBOperation.Delete); 
                        orderItemsController.FinalizeChanges(changingItem);

                        productController.DataMaintenance(eachProduct, DatabaseLayer.DB.DBOperation.Edit); 
                        productController.FinalizeChanges(product);
                    }

                    orderController.DataMaintenance(order, DatabaseLayer.DB.DBOperation.Delete);
                    orderItemsController.FinalizeChanges(changingItem);
                }
            }

            else
            {
                e.Cancel = true;
                this.Activate();
            }
        }

        #endregion

        #region Button Clicked Events
        private void checkOutButton_Click(object sender, System.EventArgs e)
        {
            if (orderInProgress == false)  
            {
                MessageBox.Show("Please Select an order");
            }

            else
            {
                if (MessageBox.Show("Are you sure you want to check out order?", "Checking out Order", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (customer.CurrentCredit <= 0)
                    {
                        customer.CreditStatus = "0";
                    }

                    {
                        if(CreateNewPickingListForm() == true)
                        {
                            pickingListForm.Show();                            
                            orderFormClosed = true;                          
                        }
                        else
                        {
                            MessageBox.Show("Cannot create an order for a customer with bad credit status");
                        }
                    }

                    customerController.DataMaintenance(customer, DatabaseLayer.DB.DBOperation.Edit);
                    customerController.FinalizeChanges(customer);

                    orderController.DataMaintenance(order, DatabaseLayer.DB.DBOperation.Edit);
                    orderController.FinalizeChanges(order);
                    this.Dispose();
                }

                else
                {
                    this.Activate();
                }
            }
                
        }

        private void itemsListView_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            changingItem = orderItemsController.Find(itemsListView.SelectedItems[0].Text);
            ButtonsEnabled(false); 
            ShowButtons(true);
        }

        private void deleteButton_Click(object sender, System.EventArgs e)
        {
            Product changingProduct = productController.Find(changingItem.ProductID);

            changingProduct.QuantityInStock += changingItem.Quantity; 
            customer.CurrentCredit += (int)(changingItem.Quantity* changingProduct.Price);
            order.TotalCost -= (int)(changingItem.Quantity * changingProduct.Price);


            currentTotalLabel.Text = "R " + (double)order.TotalCost;
            remainingCreditLabel.Text = "R " + customer.CurrentCredit;
            qtyNumericUpDown.Value = 0;

            changingItem.OrderID = "Poppel";
            orderItemsController.DataMaintenance(changingItem, DatabaseLayer.DB.DBOperation.Edit);
            orderItemsController.FinalizeChanges(changingItem);

            productController.DataMaintenance(changingProduct, DatabaseLayer.DB.DBOperation.Edit);
            productController.FinalizeChanges(product);
            ItemsListView();
            productsComboBox.SelectedIndex = -1;
            productsComboBox.Text = "";
            qtyNumericUpDown.Value = 0;
            ShowButtons(false);
            ButtonsEnabled(true);
        }

        private void editButton_Click(object sender, System.EventArgs e)
        {   
            ShowButtons(false);
            doneButton.Visible = true;
            cancelButton.Visible = true;
        }

        private void cancelButton_Click(object sender, System.EventArgs e)
        {
            ShowButtons(false);
            ButtonsEnabled(true);
        }

        private void doneButton_Click(object sender, System.EventArgs e)
        {
            Product changingProduct = productController.Find(changingItem.ProductID);

            int qtyBeforeEdit = changingItem.Quantity;
            int diffirence = (int)(qtyNumericUpDown.Value - qtyBeforeEdit);

            if ((diffirence * changingProduct.Price) > customer.CurrentCredit)
            {
                MessageBox.Show("Cannot make these changes as the total now exceeds the current credit");
            }
            else
            {
                changingItem.Quantity += diffirence;                         
                changingProduct.QuantityInStock += diffirence;


                customer.CurrentCredit -= (int)(diffirence * changingProduct.Price);  
                order.TotalCost += (int)(diffirence * changingProduct.Price);


                currentTotalLabel.Text = "R " + (double)order.TotalCost;              
                remainingCreditLabel.Text = "R " + customer.CurrentCredit;
                qtyNumericUpDown.Value = 0;
                orderItemsController.DataMaintenance(changingItem, DatabaseLayer.DB.DBOperation.Edit);  
                orderItemsController.FinalizeChanges(changingItem);

                productController.DataMaintenance(changingProduct, DatabaseLayer.DB.DBOperation.Edit); 
                productController.FinalizeChanges(product);
            }

            ItemsListView();
            productsComboBox.SelectedIndex = -1;
            productsComboBox.Text = "";
            qtyNumericUpDown.Value = 0;
            ShowButtons(false);
            ButtonsEnabled(true);
        }

        private void addToCartButton_Click(object sender, System.EventArgs e)
        {
            if (productsComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Nothing was selected to add to cart, please select a product from the products box");
            }
            else
            {
                if (qtyNumericUpDown.Value == 0)
                {
                    MessageBox.Show("0 products were selected, please select product quantity greater than 0");
                }

                else
                {
                    if (CheckAvailability() == true)
                    {
                        if ((customer.CurrentCredit - ((int)product.Price * qtyNumericUpDown.Value)) < -10)
                        {
                            MessageBox.Show("Order total now exceeds current credit, remove some items to continue");
                        }

                        else
                        {           
                            CreateOrderItem();
                            ItemsListView();
                            productsComboBox.SelectedIndex = -1;
                            productsComboBox.Text = "";
                            qtyNumericUpDown.Value = 0;
                        }
                        
                    }

                }
            }

        }
        #endregion

        #region  Set Up Methods
        public void ShowButtons(bool value)
        {
            cancelButton.Visible = false;
            doneButton.Visible = false;

            if (value == true)
            {
                backButton.Visible = false;
            }

            else
            {
                backButton.Visible = true;
            }
        }

        public void ButtonsEnabled(bool value)
        {
            productsComboBox.Enabled = value;
            addToCartButton.Enabled = value;
            checkOutButton.Enabled = value;
            itemsListView.Enabled = value;
        }


        public void SetUp()
        {
            orderIDLabel.Text = generateOrderID();
            customerNumberLabel.Text = customer.CustomerID + "       " + customer.Name.Substring(0, 1) + "." + customer.Surname;
            customerCurrentCredit = customer.CurrentCredit;
            remainingCreditLabel.Text = "R " + customer.CurrentCredit;
            qtyNumericUpDown.Maximum = 5000;
        }

        public void FillCombo()
        {
            products = new Collection<Product>();
            products = productController.AllProducts;
            foreach (Product eachProduct in products)
            {
                if (eachProduct.QuantityInStock != 0)
                {
                    productsComboBox.Items.Add(eachProduct);
                }

            }
            productsComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            productsComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            productsComboBox.SelectedIndex = -1;
            productsComboBox.Text = "";
        }


        public void ItemsListView()
        {
            ListViewItem itemDetails;
            Product productSetUp = (Product)(productsComboBox.SelectedItem);
            itemsListView.Clear();

            if (orderInProgress == false)
            {
                itemsListView.View = View.Details;
                itemsListView.Columns.Insert(0, "Order Item ID", 90, HorizontalAlignment.Center);
                itemsListView.Columns.Insert(1, "Product ID", 90, HorizontalAlignment.Center);
                itemsListView.Columns.Insert(2, "Product Name", 90, HorizontalAlignment.Center);
                itemsListView.Columns.Insert(3, "Quantity", 90, HorizontalAlignment.Center);
               
            }

            else
            {

                itemsListView.View = View.Details;
                itemsListView.Columns.Insert(0, "Order Item ID", 90, HorizontalAlignment.Center);
                itemsListView.Columns.Insert(1, "Product ID", 90, HorizontalAlignment.Center);
                itemsListView.Columns.Insert(2, "Product Name", 90, HorizontalAlignment.Center);
                itemsListView.Columns.Insert(3, "Quantity", 90, HorizontalAlignment.Center);
                
                Collection<OrderItems> allItems = orderItemsController.FindByOrderID(order.OrderID); 

                foreach (OrderItems eachItem in allItems)     
                {
                    Product eachProduct = productController.Find(eachItem.ProductID);   
                    itemDetails = new ListViewItem();
                    itemDetails.Text = eachItem.OrderItemID;
                    itemDetails.SubItems.Add(eachItem.ProductID);
                    itemDetails.SubItems.Add(eachProduct.ProductName);
                    itemDetails.SubItems.Add(eachItem.Quantity.ToString());
                    itemsListView.Items.Add(itemDetails);
                }
            }
            itemsListView.Refresh();
            itemsListView.GridLines = true;

        }

        #endregion

        #region Order Creation Methods
        public bool CheckAvailability()
        {
            product = (Product)productsComboBox.SelectedItem;
            if (product.QuantityInStock == 0)
            {
                MessageBox.Show("Sorry, the product " + product.ProductName + "is out of stock");
                return false;
            }

            else if (qtyNumericUpDown.Value > product.QuantityInStock)
            {
                MessageBox.Show("We only have " + product.QuantityInStock + " " + product.ProductName + " in stock, please select items less/Equal" + product.QuantityInStock);
                return false;
            }
            else
            {
                return true;
            }
        }

        public string generateOrderID()
        {
            int noOfOrders = orderController.AllOrders.Count + 1000;
            return "ORDER " + noOfOrders;
        }

        public string generateOrderItemID()
        {
            int noOfOItems = orderItemsController.AllOrderItems.Count + 1000;
            return "ITEM " + noOfOItems;
        }

        public void CreateOrderItem()
        {
            OrderItems item = new OrderItems();

            if (orderInProgress == false)
            {
                order = new Order();
                order.OrderID = generateOrderID();
                order.CustomerID = customer.CustomerID;
                order.OrderDate = System.DateTime.Now;
                order.OrderValue = 0;

                orderController.DataMaintenance(order, DatabaseLayer.DB.DBOperation.Add);
                orderController.FinalizeChanges(order);

                orderInProgress = true;

            }
            item.OrderItemID = generateOrderItemID();
            item.OrderID = order.OrderID;
            item.ProductID = product.ProductID;
            item.Quantity = (int)qtyNumericUpDown.Value;

            product.QuantityInStock = (int)product.QuantityInStock - item.Quantity; 
            order.TotalCost += (int)(product.Price * item.Quantity);                
            customer.CurrentCredit -= (int)(product.Price * item.Quantity);         

            currentTotalLabel.Text = "R " + (double)order.TotalCost;                
            remainingCreditLabel.Text = "R " + customer.CurrentCredit;

            orderItemsController.DataMaintenance(item, DatabaseLayer.DB.DBOperation.Add);  
            orderItemsController.FinalizeChanges(item);

            productController.DataMaintenance(product, DatabaseLayer.DB.DBOperation.Edit); 
            productController.FinalizeChanges(product);
        }
        #endregion

        private void backButton_Click(object sender, System.EventArgs e)
        {
            close = true;
            this.Close();
        }

        private bool CreateNewPickingListForm()
        {
            int currentstatus = customer.CurrentCredit;
            if(customer.CurrentCredit.Equals("0"))
            {
                return false;
            }
            else
            {
                pickingListForm = new PickingListForm(productController, customerController,employeeController)
                {
                    StartPosition = FormStartPosition.CenterParent
                };
            }
            return true;
        }
        private void OrderForm_Load(object sender, System.EventArgs e)
        {
            qtyNumericUpDown.Enabled = false;
            itemsListView.Enabled = false;
            addToCartButton.Enabled = false;
            checkOutButton.Enabled = false;
        }

        private void productsComboBox_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            qtyNumericUpDown.Enabled = true;
            itemsListView.Enabled = true;
            addToCartButton.Enabled = true;
            checkOutButton.Enabled = true;
        }

        private void closeButton_Click(object sender, System.EventArgs e)
        {
            orderFormClosed = true;
            this.Close();
        }
    }
}
