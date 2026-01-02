using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Xml.Linq;

namespace BIT706AS1
{
    /// <summary>
    /// Interaction logic for addAnimal.xaml
    /// </summary>
    public partial class addAnimal : Window
    {
        public addAnimal()
        {
            InitializeComponent();
            PopulateAnimalType();
            PopulateAnimalSex();


        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Store the value in the related textboxes to variables
            string animalName = tbAnimalName.Text;
            int animalAge = int.Parse(tbAnimalAge.Text);
            string customer = tbCustomerName.Text;
            AnimalType selectedAnimalType = (AnimalType)animalType.SelectedValue;
            AnimalSex selectedAnimalSex = (AnimalSex)animalSex.SelectedValue;

            // Validating whether the required fields for the Animal Class are supplied
            if (string.IsNullOrWhiteSpace(animalName))
            {
                MessageBox.Show("Name is required", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (animalType.SelectedIndex == -1)
            {
                MessageBox.Show("An Animal Type is required", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Creating the animal object
            try
            {
                Animal newAnimal = new Animal(animalName, selectedAnimalType, selectedAnimalSex, "", animalAge, MicrochipStatus.Pending, customer);
            }
            catch {
                MessageBox.Show("Unable to add animal", "Fatal Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Are you sure you want to cancel dialogue
            MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);

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


        private void PopulateAnimalType()
        {
            animalType.ItemsSource = Enum.GetValues(typeof(AnimalType));
        }

        private void PopulateAnimalSex()
        {
            animalSex.ItemsSource = Enum.GetValues(typeof(AnimalSex));
        }



    }
}
