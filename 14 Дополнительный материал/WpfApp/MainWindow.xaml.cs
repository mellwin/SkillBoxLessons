using DAL;
using Domain;
using App;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Linq.Expressions;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public delegate void ShowNotification(string message);

    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            this.InitializeComponent();
            FillChangeAction();
            FillCustumers();
            FillAccounts();
            ShowListView();

            AccountRepo.AccnountCheckCurrentBalanceNotification += ShowNotification;
            Try.ExceptionNotification += ShowNotification;
        }


        private void CbCusFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Try.TryExecute(FillAccounts);
        }

        private void CbCusTo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Try.TryExecute(FillAccounts);
        }

        private void BtnChange_Click(object sender, RoutedEventArgs e)
        {
            Try.TryExecute(ShowEditForm);
        }

        private void BtnTransfer_Click(object sender, RoutedEventArgs e)
        {
            Try.TryExecute(MakeTransaction);
        }

        private void FillChangeAction()
        {
            cbChange.ItemsSource = new DdlOption[]
            {
                new DdlOption("Клиент", "1"),
                new DdlOption("Счет", "2"),
                new DdlOption("Транзакция", "3")
            };
        }

        private void FillCustumers()
        {
            CustumerRepo custumerRepo = new CustumerRepo();
            var custumers = custumerRepo.SelectAllDataFromJsonFile();

            if (custumers == null || custumers.Count == 0)
            {
                //MessageBox.Show("Нет доступных клиентов для заполнения");
                throw new NotFoundCustumersEx();
            }

            cbCusFrom.Items.Clear();
            cbCusTo.Items.Clear();

            foreach (var custumer in custumers)
            {
                cbCusFrom.Items.Add(new DdlOption(custumer.Name, custumer.Id.ToString()));
                cbCusTo.Items.Add(new DdlOption(custumer.Name, custumer.Id.ToString()));
            }
        }

        private void FillAccounts()
        {
            var accounts = new AccountRepo().SelectAllDataFromJsonFile(); // Получаем все счета
            cbAccFrom.Items.Clear();
            cbAccTo.Items.Clear();

            if (cbCusFrom.SelectedItem != null)
            {
                var selectedCustumerFrom = cbCusFrom.SelectedItem as DdlOption;
                int custumerIdFrom = int.Parse(selectedCustumerFrom.Value);

                var customerAccountsFrom = accounts.Where(a => a.CustumerId == custumerIdFrom).ToList();
                foreach (var account in customerAccountsFrom)
                {
                    cbAccFrom.Items.Add(new DdlOption(account.AccuntNum, account.Id.ToString()));
                }
            }

            if (cbCusTo.SelectedItem != null)
            {
                var selectedCustumerTo = cbCusTo.SelectedItem as DdlOption;
                int custumerIdTo = int.Parse(selectedCustumerTo.Value);

                var customerAccountsTo = accounts.Where(a => a.CustumerId == custumerIdTo).ToList();
                foreach (var account in customerAccountsTo)
                {
                    cbAccTo.Items.Add(new DdlOption(account.AccuntNum, account.Id.ToString()));
                }
            }
        }

        private void ShowListView()
        {
            List<Transaction> data = new TransactionRepo().SelectAllDataFromJsonFile(); //currentEmployee.ShowAllClients();
            lvWorkers.ItemsSource = data;
        }

        private void ShowEditForm()
        {
            CustumerRepo custumerRepo = new CustumerRepo();
            AccountRepo accountRepo = new AccountRepo();

            //for (int i = 1; i <= 10; i++)
            //{
            //    custumerRepo.Insert(new Custumer("Клиент_" + i));

            //    for (int j = 1; j <= 2; j++)
            //    {
            //        accountRepo.Insert(new Account(i, $"Счет_{i}.{j}"));
            //    }
            //}

            var selectedOption = cbChange.SelectedItem as DdlOption;

            MenuObjects Changed;

            ShowNotification shwNotifiation = ShowNotification;

            EditWindow ew = new EditWindow(ShowNotification);

            if (selectedOption != null)
            {
                // В зависимости от значения выполняем соответствующее действие
                switch (selectedOption.Value)
                {
                    case "1":
                        Changed = MenuObjects.Custumer;
                        ew.ChangeObjects(Changed);
                        ew.Show();
                        break;
                    case "2":
                        Changed = MenuObjects.Account;
                        ew.ChangeObjects(Changed);
                        ew.Show();
                        break;
                    case "3":
                        Changed = MenuObjects.Transaction;
                        ew.ChangeObjects(Changed);
                        ew.Show();
                        break;
                    default:
                        MessageBox.Show("Неизвестное действие");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите действие");
            }
        }

        private void MakeTransaction()
        {
            if (cbCusFrom.SelectedItem == null || cbCusTo.SelectedItem == null || cbAccFrom.SelectedItem == null || cbAccTo.SelectedItem == null)
            {
                throw new CustumerOrAccountNotChangedEx();
            }

            if (tbSUM.Text == "")
            {
                throw new RecordOrSumNotSelectedUseEx();
            }

            CustumerRepo custumerRepo = new CustumerRepo();
            AccountRepo accountRepo = new AccountRepo();
            TransactionRepo transactionRepo = new TransactionRepo();

            var selectedAccountrFrom = cbCusFrom.SelectedItem as DdlOption;
            var selectedAccountTo = cbCusTo.SelectedItem as DdlOption;
            var AccFrom = accountRepo.Find(int.Parse(selectedAccountrFrom.Value));
            var AccTo = accountRepo.Find(int.Parse(selectedAccountTo.Value));
            var Sum = Convert.ToDouble(tbSUM.Text);
            if (AccFrom.Balance < Sum)
            {
                ShowNotification("Недостаточно средств");
                return;
            }

            Transaction transaction = new Transaction(AccFrom.Id, AccTo.Id, Sum, DateTime.Now);
            transactionRepo.Insert(transaction);

            AccFrom -= Sum;
            AccTo += Sum;

            accountRepo.Update(AccFrom);
            accountRepo.Update(AccTo);

            ShowListView();

        }

        public void ShowNotification(string message)
        {
            tbNotification.Text = message;
            tbNotification.Visibility = Visibility.Visible;

            // Создаем анимацию для подъема вверх
            DoubleAnimation moveUpAnimation = new DoubleAnimation
            {
                From = 0,
                To = -150, // Поднимаем на 50 пикселей
                Duration = TimeSpan.FromSeconds(2),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }  // Плавное замедление
            };

            // Создаем анимацию для затухания
            DoubleAnimation fadeOutAnimation = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(2),
                BeginTime = TimeSpan.FromSeconds(1) // Задержка перед началом затухания
            };

            // Применяем анимацию к Opacity (затухание)
            tbNotification.BeginAnimation(OpacityProperty, fadeOutAnimation);

            // Применяем анимацию к перемещению (TranslateTransform.Y)
            notificationTransform.BeginAnimation(TranslateTransform.YProperty, moveUpAnimation);

            // Скрываем уведомление по завершении анимации
            fadeOutAnimation.Completed += (s, e) =>
            {
                tbNotification.Visibility = Visibility.Collapsed;
                notificationTransform.Y = 0;
                tbNotification.Opacity = 1;
            };
        }
    }
}