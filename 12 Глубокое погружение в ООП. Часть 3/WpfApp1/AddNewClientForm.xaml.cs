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

namespace WPFApp
{
    /// <summary>
    /// Логика взаимодействия для AddNewCLientForm.xaml
    /// </summary>
    public partial class AddNewCLientForm : Window
    {
        private IEmployee employee;

        public AddNewCLientForm(IEmployee _employee)
        {
            employee = _employee;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var employee = new Manager();

            var client = new Client(); 

            client.Name = tbName.Text;

            client.SecondName = tbSecondName.Text;

            client.Surname = tbSurname.Text;

            client.MobilePhone = tbPhone.Text;

            client.Passport = tbPassport.Text;

            employee.AddClient(client);
            
            Close();
        }
    }
}