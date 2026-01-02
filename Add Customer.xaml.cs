using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BIT706AS1
{
    /// <summary>
    /// Interaction logic for Add_Customer.xaml
    /// </summary>
    public partial class Add_Customer : Window
    {
        public Add_Customer()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Store the value in the related textboxes to variables
            string name = tbName.Text;
            string phoneNumber = tbPhoneNumber.Text;
            string email = tbEmail.Text;
            string address = tbAddress.Text;

            // Validate the above data (enforcing required fields)

            // Validate a name is provided, shows an error box is not provided
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Name is required", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validate a address is provided, shows an error box is not provided
            if (string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Address is required", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(phoneNumber) && string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Either Phone Number or Email required", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }


            // Once Validated, create a new object for the entry
            // Will try adding a new customer
            try
            {
                Customer newCustomer = new Customer(name, email, address, phoneNumber);

                // Show successful message so the user knows the action worked
                MessageBox.Show("Customer successfully added!", "Success", MessageBoxButton.OK);

                // Clear inputs
                tbName.Text = string.Empty;
                tbPhoneNumber.Text = string.Empty;
                tbEmail.Text = string.Empty;
                tbAddress.Text = string.Empty;

            }
                catch (Exception ex) // Throw error if unable to add customer
                {
                    MessageBox.Show("Unable to add customer", "Fatal Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Are you sure you want to cancel dialogue
            MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel?", ":Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);

            // If the user selects yes, close the window
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
            else
            {
                // if no, do nothing
            }


        }
    }
}
