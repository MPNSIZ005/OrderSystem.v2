using System.Collections.ObjectModel;
using System.Windows.Forms;
using OrderSystem.BusinessLayer;

namespace OrderSystem.PresentationLayer
{
    public partial class LoginForm : Form
    {
        #region Attributes
        private EmployeeController employeeController;
        public bool loginFormClosed = false;   
        #endregion

        #region Constructor
        public LoginForm(EmployeeController anEmployeeController)
        {
            InitializeComponent();
            employeeController = anEmployeeController;
            errorLabel.Visible = false;
        }
        #endregion

        #region Form Events
        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginFormClosed = true;
        }
        #endregion

        #region Button clicked events
        private void LoginButton_Click(object sender, System.EventArgs e)
        {
            
            Collection<Employee> allEmployees = employeeController.AllEmployees;
            Employee emp = null;
            bool employeeFound = false;

            foreach (Employee eachEmployee in allEmployees)
            {
                if(eachEmployee.EmployeeID.Equals(usernameTextBox.Text.ToUpper()))
                {
                    employeeFound = true;
                    emp = eachEmployee;
                    break;
                }
            }


            if (employeeFound==true)   // user exist
            {
                if (emp.Password.Equals(passwordTextBox.Text))
                {
                    if (emp.RoleValue == Employee.Role.pickingClerk)
                    {
                        ((PoppelMDIParent)this.MdiParent).pickClerkLogin();
                    }
                    else
                    {
                        ((PoppelMDIParent)this.MdiParent).TellerSellerLogin();
                    }
                    this.Close();
                }

                else// but the password is incorrect
                {
                    passwordTextBox.Text = "";
                    errorLabel.Text = "Incorrect Password Entered.";
                    errorLabel.Visible = true;
                }
            }

            else //user does not exist
            {
                passwordTextBox.Text = "";
                errorLabel.Text = "Incorrect username/password combination.Please try again.";
               errorLabel.Visible = true;
            }
        }

        #endregion

        private void clearButton_Click(object sender, System.EventArgs e)
        {
            passwordTextBox.Text = "";
            usernameTextBox.Text = "";
        }
    }
}
