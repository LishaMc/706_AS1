using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BIT706AS1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Cancel_Button(object sender, RoutedEventArgs e)
        {

            //Shut down application
            Application.Current.Shutdown();

        }

        private void Microchip_Click(object sender, RoutedEventArgs e)
        {
            // Create the window
            recordMicrochip recordMicrochipWindow = new recordMicrochip();

            // Open the window
            recordMicrochipWindow.Show();

        }

        private void Animal_Click(object sender, RoutedEventArgs e)
        {
            // Create the window
            addAnimal addAnimalWindow = new addAnimal();

            // Open the window
            addAnimalWindow.Show();
        }

        private void Customer_Click(object sender, RoutedEventArgs e)
        {
            // Create the window
            Add_Customer addCustomerWindow = new Add_Customer();
            
            // Open the window
            addCustomerWindow.Show();
        }
    }
}