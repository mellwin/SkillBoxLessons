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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<Client> data;
        static IEmployee currentEmployee;

        public MainWindow()
        {
            InitializeComponent();
            
            cbEmployee.ItemsSource = new List<string>() { "Консультант", "Менеджер" };
            cbEmployee.SelectedIndex = 0;

            cbSort.ItemsSource = new List<string>() { "Имя", "Отчество", "Фамилия" };
            cbSort.SelectedIndex = 0;
        }

        private void cbEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChooseEmploee((sender as ComboBox).SelectedItem.ToString());

            FillLvWorkers();
        }
        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChooseSort((sender as ComboBox).SelectedItem.ToString());
        }

        private void ChooseEmploee(string input)
        {
            switch (input)
            {
                case "Консультант":
                    currentEmployee = new Consultant();
                    ComponentsHide(true);
                    break;
                case "Менеджер":
                    currentEmployee = new Manager();
                    ComponentsHide(false);
                    break;
            };
        }

        private void ChooseSort(string input)
        {
            IOrderedEnumerable<Client> orderedData;
            switch (input)
            {
                case "Имя":
                    orderedData = data.OrderBy(x => x.Name);
                    lvWorkers.ItemsSource = orderedData;
                    break;
                case "Фамилия":
                    orderedData = data.OrderBy(x => x.SecondName);
                    lvWorkers.ItemsSource = orderedData;
                    break;
                case "Отчество":
                    orderedData = data.OrderBy(x => x.Surname);
                    lvWorkers.ItemsSource = orderedData;
                    break;
            };
        }

        private void ComponentsHide(bool input)
        {
            if (input)
            {
                tbName.Visibility = Visibility.Hidden;
                tbSurname.Visibility = Visibility.Hidden;
                tbSecondName.Visibility = Visibility.Hidden;
                tbPassport.Visibility = Visibility.Hidden;

                lblName.Visibility = Visibility.Hidden;
                lblSurname.Visibility = Visibility.Hidden;
                lblSecondName.Visibility = Visibility.Hidden;
                lblPassport.Visibility = Visibility.Hidden;

                btnAdd.Visibility = Visibility.Hidden;
                btnRemove.Visibility = Visibility.Hidden;

            }

            if (!input)
            {
                tbName.Visibility = Visibility.Visible;
                tbSurname.Visibility = Visibility.Visible;
                tbSecondName.Visibility = Visibility.Visible;
                tbPassport.Visibility = Visibility.Visible;


                lblName.Visibility = Visibility.Visible;
                lblSurname.Visibility = Visibility.Visible;
                lblSecondName.Visibility = Visibility.Visible;
                lblPassport.Visibility = Visibility.Visible;

                btnAdd.Visibility = Visibility.Visible;
                btnRemove.Visibility = Visibility.Visible;
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            currentEmployee.RemoveClient((lvWorkers.SelectedItem as Client).Id);
            FillLvWorkers();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            var client = lvWorkers.SelectedItem as Client;

            client.Name = tbName.Text;
            client.Surname = tbSurname.Text;
            client.SecondName = tbSecondName.Text;
            client.MobilePhone = tbPhone.Text;
            client.Passport = tbPassport.Text;

            currentEmployee.EditClient(client);
        }

        private void FillLvWorkers()
        {
            data = currentEmployee.ShowAllClients();
            lvWorkers.ItemsSource = data;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //AddNewCLientForm addNewCLientForm = new AddNewCLientForm(currentEmployee);
            //addNewCLientForm.Show();

            AddNewCLientForm addNewCLientForm = new AddNewCLientForm(currentEmployee);
            addNewCLientForm.Show();

            FillLvWorkers();
        }

    }
}
