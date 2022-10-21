using System;
using System.Windows.Forms;
using OrderSystem.BusinessLayer;

namespace OrderSystem
{
    public partial class RegistrationForm : Form
    {
        #region Attributes
        public bool registrationFormClosed = false;
        public bool registrationFormFormClosed = false;
        private Customer customer;
        private CustomerController customerController;
        #endregion

        #region Constructor
        public RegistrationForm(CustomerController aCustomerConstroller)
        {
            InitializeComponent();
            customerController = aCustomerConstroller; 
        }
        #endregion

        #region Form events
        private void RegistrationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            registrationFormFormClosed = true;
        }
        #endregion

        #region Buttion Clicked Events
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void submitButton_Click(object sender, EventArgs e)
        {
            if (PopulateObject() == true)
            {
               
                customerController.DataMaintenance(customer, DatabaseLayer.DB.DBOperation.Add);
                customerController.FinalizeChanges(customer);
                MessageBox.Show("Customer was successfully registered!");
                ClearAll();
            }
            else
            {
                MessageBox.Show("Customer was NOT successfully registered");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        #endregion

        #region methods
        private void ClearAll()
        {
            nameTextBox.Text = "";
            surnameTextBox.Text = "";
            phoneTextBox.Text = "";
            IDNumberTextBox.Text = "";
            dileveryAddressTextBox.Text = "";
        }

        public string CustomerIDGenerator(string name, string surname, string idNumber)
        {
            string customerID = name.ToUpper().Substring(0,3);
            customerID = customerID + surname.ToUpper().Substring(0, 3);
            customerID = customerID + idNumber.Substring(0, 3);
            return customerID;
        }

        private Boolean PopulateObject()//Get data customer data from the registration form
        {
            int phoneNum; 
            bool validPhoneNum = int.TryParse(phoneTextBox.Text, out phoneNum);
            long num;
            if (surnameTextBox.Text.Equals("") || nameTextBox.Text.Equals("") || phoneTextBox.Text.Equals("") || IDNumberTextBox.Text.Equals("") || dileveryAddressTextBox.Text.Equals(""))
            {
                MessageBox.Show("One or more of the fields are missing");
                return false;
            }

            else
            {
                if (!long.TryParse(IDNumberTextBox.Text, out num) && !long.TryParse(phoneTextBox.Text, out num))
                {
                    MessageBox.Show("Phone number and ID number must be numeric");
                    return false;
                }

                else if (!long.TryParse(IDNumberTextBox.Text, out num))
                {
                    MessageBox.Show("ID number must be numeric");
                    return false;
                }

                else if (string.IsNullOrEmpty(phoneTextBox.Text) || phoneTextBox.Text.Equals("Enter your Phone number") || validPhoneNum == false || !(phoneTextBox.Text.Length == 10) || !(phoneTextBox.Text.StartsWith("0"))) //start phone number check
                {
                    MessageBox.Show("Phone number MUST be numeric with 0 at the beginning");
                    return false;
                }

                else
                {
                    customer = new Customer();
                    customer.CustomerID = CustomerIDGenerator(nameTextBox.Text, surnameTextBox.Text, IDNumberTextBox.Text) ;                                     ///autoGerate
                    customer.Name = nameTextBox.Text;
                    customer.Surname = surnameTextBox.Text;
                    customer.Phone = phoneTextBox.Text;
                    customer.IDNumber = long.Parse(IDNumberTextBox.Text);
                    customer.CurrentCredit = int.Parse("2000");
                    customer.CreditStatus = "1";
                    customer.CustomerAddress = dileveryAddressTextBox.Text;
                    return true;
                }
            }    
        }
        #endregion
    }
}
