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

namespace WpfAppDBFirst
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
