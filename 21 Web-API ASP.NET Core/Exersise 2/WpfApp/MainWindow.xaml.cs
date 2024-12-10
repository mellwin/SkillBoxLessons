using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using WpfApp.Models;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataRowView row;
        DataTable dt;
        ObservableCollection<PhoneContact> contacts;

        public MainWindow()
        {
            InitializeComponent();
            ContactsDataApi context = new();

            btnRef.Click += async delegate {
                                        var contactsList = await context.GetContacts();
                                        listView.ItemsSource = contactsList;
            };
            btnAdd.Click += async delegate
            {
                await context.AddContact(new PhoneContact(
                    txtName.Text, txtPhoneNumber.Text, txtAddress.Text, txtDescriptions.Text
                ));
            };
        }
    }
}