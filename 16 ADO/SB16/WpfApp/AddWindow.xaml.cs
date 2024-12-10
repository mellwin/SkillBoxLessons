using ConsoleApp1;
using System.Data;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private AddWindow() { InitializeComponent(); }

        public AddWindow(Custumer custumer) : this()
        {
            cancelBtn.Click += delegate { this.DialogResult = false; };
            okBtn.Click += delegate
            {
                custumer.Id = Guid.NewGuid();
                custumer.LastName = txtCustumerLastName.Text;
                custumer.Name = txtCustumerName.Text;
                custumer.SecondName = txtCustumerSecondName.Text;
                custumer.PhoneNumber = txtPhoneNumber.Text;
                custumer.Email = txtEmail.Text;
                this.DialogResult = !false;
            };

        }
    }
}