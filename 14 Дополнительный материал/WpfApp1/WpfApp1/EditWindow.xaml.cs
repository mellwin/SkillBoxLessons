using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private ShowNotification showNotification;

        public readonly MenuActions menuActions;

        public MenuObjects menuObjects { get; set; }

        private readonly StackPanel stackpanel = new StackPanel();

        public EditWindow(ShowNotification showNotification)
        {
            InitializeComponent();

            this.showNotification = showNotification;
            TransactionRepo.TransactionCreatedNotification += ShowNotification;
            AccountRepo.AccnountCreatedNotification += ShowNotification;
            CustumerRepo.CustumerCreatedNotification += ShowNotification;
        }

        public void ChangeAction(MenuActions input)
        {
            switch (input)
            {
                case MenuActions.AddCustumer:
                    break;
                case MenuActions.ChangeAccount:
                    break;
                case MenuActions.DeleteCustumer:
                    break;
                case MenuActions.DeleteAccount:
                    break;
                default:
                    MessageBox.Show("Неизвестное действие");
                    break;
            }
        }

        public void ShowNotification(string message)
        {
            showNotification?.Invoke(message);
        }

        public void ChangeObjects(MenuObjects input)
        {
            switch (input)
            {
                case MenuObjects.Custumer:
                    CreateFieldsCustumer();
                    break;
                case MenuObjects.Account:
                    CreateFieldsAccount();
                    break;
                case MenuObjects.Transaction:
                    CreateFieldsTransactions();
                    break;
                default:
                    MessageBox.Show("Неизвестное действие");
                    break;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            AddInstance();
        }

        private void CreateFieldsCustumer()
        {
            Button btnSave = new Button()
            {
                Name = "btnSave",
                Content = "Сохранить",
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(10, 10, 0, 0),
                VerticalAlignment = VerticalAlignment.Top
            };
            btnSave.Click += (BtnSave_Click);

            stackpanel.Children.Add(new Label { Content = "Name", HorizontalAlignment = HorizontalAlignment.Left, Margin = new Thickness(10, 10, 0, 0), VerticalAlignment = VerticalAlignment.Top, Width = 120 });
            stackpanel.Children.Add(new TextBox { Name = "TbName", HorizontalAlignment = HorizontalAlignment.Left, Margin = new Thickness(10, 10, 0, 0), TextWrapping = TextWrapping.Wrap, VerticalAlignment = VerticalAlignment.Top, Width = 120 });

            stackpanel.Children.Add(btnSave);

            this.Content = stackpanel;
            menuObjects = MenuObjects.Custumer;

        }

        private void CreateFieldsAccount()
        {
            Button btnSave = new Button()
            {
                Name = "btnSave",
                Content = "Сохранить",
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(10, 10, 0, 0),
                VerticalAlignment = VerticalAlignment.Top
            };
            btnSave.Click += (BtnSave_Click);

            stackpanel.Children.Add(new Label { Content = "CustumerId", HorizontalAlignment = HorizontalAlignment.Left, Margin = new Thickness(10, 10, 0, 0), VerticalAlignment = VerticalAlignment.Top, Width = 120 });
            stackpanel.Children.Add(new TextBox { Name = "TbCustumerId", HorizontalAlignment = HorizontalAlignment.Left, Margin = new Thickness(10, 10, 0, 0), TextWrapping = TextWrapping.Wrap, VerticalAlignment = VerticalAlignment.Top, Width = 120 });

            stackpanel.Children.Add(new Label { Content = "AccountNum", HorizontalAlignment = HorizontalAlignment.Left, Margin = new Thickness(10, 10, 0, 0), VerticalAlignment = VerticalAlignment.Top, Width = 120 });
            stackpanel.Children.Add(new TextBox { Name = "TbAccountNum", HorizontalAlignment = HorizontalAlignment.Left, Margin = new Thickness(10, 10, 0, 0), TextWrapping = TextWrapping.Wrap, VerticalAlignment = VerticalAlignment.Top, Width = 120 });

            stackpanel.Children.Add(btnSave);

            this.Content = stackpanel;
            menuObjects = MenuObjects.Account;

        }

        private void CreateFieldsTransactions()
        {
            Button btnSave = new Button()
            {
                Name = "btnSave",
                Content = "Сохранить",
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(10, 10, 0, 0),
                VerticalAlignment = VerticalAlignment.Top
            };
            btnSave.Click += (BtnSave_Click);

            stackpanel.Children.Add(new Label { Content = "AccountIdFrom", HorizontalAlignment = HorizontalAlignment.Left, Margin = new Thickness(10, 10, 0, 0), VerticalAlignment = VerticalAlignment.Top, Width = 120 });
            stackpanel.Children.Add(new TextBox { Name = "TbAccountIdFrom", HorizontalAlignment = HorizontalAlignment.Left, Margin = new Thickness(10, 10, 0, 0), TextWrapping = TextWrapping.Wrap, VerticalAlignment = VerticalAlignment.Top, Width = 120 });

            stackpanel.Children.Add(new Label { Content = "AccountIdTo", HorizontalAlignment = HorizontalAlignment.Left, Margin = new Thickness(10, 10, 0, 0), VerticalAlignment = VerticalAlignment.Top, Width = 120 });
            stackpanel.Children.Add(new TextBox { Name = "TbAccountIdTo", HorizontalAlignment = HorizontalAlignment.Left, Margin = new Thickness(10, 10, 0, 0), TextWrapping = TextWrapping.Wrap, VerticalAlignment = VerticalAlignment.Top, Width = 120 });

            stackpanel.Children.Add(new Label { Content = "Sum", HorizontalAlignment = HorizontalAlignment.Left, Margin = new Thickness(10, 10, 0, 0), VerticalAlignment = VerticalAlignment.Top, Width = 120 });
            stackpanel.Children.Add(new TextBox { Name = "TbSum", HorizontalAlignment = HorizontalAlignment.Left, Margin = new Thickness(10, 10, 0, 0), TextWrapping = TextWrapping.Wrap, VerticalAlignment = VerticalAlignment.Top, Width = 120 });

            stackpanel.Children.Add(btnSave);

            this.Content = stackpanel;
            menuObjects = MenuObjects.Transaction;
        }

        private void AddInstance()
        {
            switch (menuObjects)
            {
                case MenuObjects.Custumer:
                    //
                    TextBox tbName = stackpanel.Children.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "TbName");
                    CustumerRepo custumerRepo = new CustumerRepo();
                    custumerRepo.Insert(new Custumer(tbName.Text.ToString()));
                    showNotification?.Invoke("Клиент успешно добавлен!");
                    break;
                case MenuObjects.Account:
                    //
                    TextBox TbCustumerId = stackpanel.Children.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "TbCustumerId");
                    TextBox TbAccountNum = stackpanel.Children.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "TbAccountNum");
                    AccountRepo accountRepo = new AccountRepo();
                    accountRepo.Insert(new Account(Convert.ToInt32(TbCustumerId.Text), TbAccountNum.Text));
                    showNotification?.Invoke("Клиент успешно добавлен!");
                    break;
                case MenuObjects.Transaction:
                    //
                    TextBox TbAccountIdFrom = stackpanel.Children.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "TbAccountIdFrom");
                    TextBox TbAccountIdTo = stackpanel.Children.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "TbAccountIdTo");
                    TextBox TbSum = stackpanel.Children.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "TbSum");
                    TextBox TbDateTimeTransaction = stackpanel.Children.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "TbDateTimeTransaction");
                    TransactionRepo transactionRepo = new TransactionRepo();
                    transactionRepo.Insert(new Transaction(
                                                        Convert.ToInt32(TbAccountIdFrom.Text),
                                                        Convert.ToInt32(TbAccountIdTo.Text),
                                                        Convert.ToDouble(TbSum.Text),
                                                        DateTime.Now

                        ));
                    showNotification?.Invoke("Клиент успешно добавлен!");
                    break;
                default:
                    MessageBox.Show("Неизвестное действие");
                    break;
            }
        }
    }
}
