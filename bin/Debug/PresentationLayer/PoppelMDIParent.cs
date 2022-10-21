using System;
using System.Windows.Forms;
using OrderSystem.BusinessLayer;

namespace OrderSystem.PresentationLayer
{
    public partial class PoppelMDIParent : Form
    {
        private int childFormNumber = 0;

        #region 
        //1a. ***Declare a reference to an EmployeeForm object
        private ExpiredProductsForm expiredProductsForm;
        private RegistrationForm registrationForm;
        private PickingListForm  pickingListForm;
        private CreateOrderForm createOrderForm;
        private CatalogueForm catalogueForm;
        private LoginForm loginForm;
        private OrderItemsController orderItemsController;
        private EmployeeController employeeController;
        private CustomerController customerController;
        private ProductController productController;
        private OrderController orderController;
        private CustomerForm customerForm;


        public PoppelMDIParent()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            orderItemsController = new OrderItemsController();
            employeeController = new EmployeeController();
            customerController = new CustomerController();
            productController = new ProductController();
            orderController = new OrderController();
            HideAll();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        #endregion

        #region Toolstrip
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loginForm == null)
            {
                CreateLoginForm();
            }

            if (loginForm.loginFormClosed)
            {
                CreateLoginForm();
            }
            
            loginForm.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideAll();

        }

        private void registerCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (registrationForm == null)
            {
                CreateNewRegistrationForm();
            }

            if (registrationForm.registrationFormFormClosed)
             {
                CreateNewRegistrationForm();
             }

             registrationForm.Show();
        }

        private void createOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (createOrderForm == null)
            {
                CreateNewOrderForm();
            }

            if (createOrderForm.createOrderFormClosed)
            {
                CreateNewOrderForm();
            }

            createOrderForm.Show();
        }
        #endregion

        #region Method 
        private void CreateLoginForm()
        {
            loginForm = new LoginForm(employeeController);
            loginForm.MdiParent = this;       
            loginForm.StartPosition = FormStartPosition.CenterParent;
        }

        public void CreateNewCatalogueForm()
        {
            catalogueForm = new CatalogueForm(productController);
            catalogueForm.MdiParent = this;        
            catalogueForm.StartPosition = FormStartPosition.CenterParent;
        }
        private void CreateNewPickingListForm()
        {
            pickingListForm = new PickingListForm(productController,customerController,employeeController);
            pickingListForm.MdiParent = this;   
            pickingListForm.StartPosition = FormStartPosition.CenterParent;
        }

        private void CreateNewCustomerForm()
        {
            customerForm = new CustomerForm(customerController);
            customerForm.MdiParent = this;
            customerForm.StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateNewRegistrationForm()
        {
            registrationForm = new RegistrationForm(customerController);
            registrationForm.MdiParent = this;       
            registrationForm.StartPosition = FormStartPosition.CenterParent;
        }

        private void CreateNewExpiredProductsForm()
        {
            expiredProductsForm = new ExpiredProductsForm(productController);
            expiredProductsForm.MdiParent = this;       
            expiredProductsForm.StartPosition = FormStartPosition.CenterParent;
        }

        private void CreateNewOrderForm()
        {
            createOrderForm = new CreateOrderForm(customerController);
            createOrderForm.MdiParent = this; 
            createOrderForm.StartPosition = FormStartPosition.CenterParent;
        }
        public void pickClerkLogin()
        {
            loginToolStripMenuItem.Visible = false;
            logoutToolStripMenuItem.Visible = true;
            createOrderToolStripMenuItem.Visible = false;
            registerCustomerToolStripMenuItem.Visible = false;
            expiryReport.Visible = true;
            reportsToolStripMenuItem.Visible = true;
            customersToolStripMenuItem.Visible = true;
        }

        public void TellerSellerLogin()
        {
            loginToolStripMenuItem.Visible = false;
            logoutToolStripMenuItem.Visible = true;
            createOrderToolStripMenuItem.Visible = true;
            registerCustomerToolStripMenuItem.Visible = true;
            reportsToolStripMenuItem.Visible = true;
            expiryReport.Visible = true;
            customersToolStripMenuItem.Visible = true;
        }

        public void HideAll()
        {
            registerCustomerToolStripMenuItem.Visible = false;
            createOrderToolStripMenuItem.Visible = false;
            logoutToolStripMenuItem.Visible = false;
            loginToolStripMenuItem.Visible = true;
            reportsToolStripMenuItem.Visible = false;
            customersToolStripMenuItem.Visible = false;
        }


        #endregion

        private void expiryReport_Click(object sender, EventArgs e)
        {
            if(expiredProductsForm == null)
            {
                CreateNewExpiredProductsForm();
            }
            if (expiredProductsForm.productsFormClosed)
            {
                CreateNewExpiredProductsForm();
            }
            expiredProductsForm.Show();
        }

        private void pickingListToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pickingListForm == null)
            {
                CreateNewPickingListForm();
            }

            if (pickingListForm.pickingListFormClosed)
            {
                CreateNewPickingListForm();
            }

            pickingListForm.Show();
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(customerForm == null)
            {
                CreateNewCustomerForm();
            }
            if (customerForm.customersClosed)
            {
                CreateNewCustomerForm();
            }
            customerForm.Show();
        }

        private void quantityInStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
                if (catalogueForm == null)
                {
                    CreateNewCatalogueForm();
                }

                if (catalogueForm.catalogueClosed)
                {
                    CreateNewCatalogueForm();
                }

                catalogueForm.Show();
        }
    }
}