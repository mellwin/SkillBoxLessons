using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppDBFirst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataRowView row;
        DataTable dt;
        ObservableCollection<Custumer> custumers;
        /// <summary>
        /// Создал модель и контекст с помощью Entity Framework core и команды: 
        /// Scaffold-DbContext "data source=(localdb)\MSSQLLocalDB;Initial Catalog=CustumersStorage;Integrated Security=True;" 
        /// Microsoft.EntityFrameworkCore.SqlServer
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            custumers = new ObservableCollection<Custumer>();
            gridView.ItemsSource = custumers; // Устанавливаем источник данных
            CreateDataSet(); // Создаем данные
            ShowGrid(); // Загружаем данные в Grid
        }

        private void GVCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                var selectedCustumer = gridView.SelectedItem as Custumer;
                if (selectedCustumer != null)
                {
                    CustumerDBRepo.Update(selectedCustumer); // Сохранение изменений
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void GVCurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                var custumer = gridView.SelectedItem as Custumer;
                if (custumer != null) await CustumerDBRepo.Update(custumer); // Сохранение изменений в базу данных
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void MenuItemDeleteClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var custumer = gridView.SelectedItem as Custumer;
                if (custumer != null)
                {
                    await CustumerDBRepo.Delete(custumer.Id); // Удаление из базы данных
                    custumers.Remove(custumer);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void MenuItemAddClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var custumer = gridView.SelectedItem as Custumer;
                AddWindow add = new AddWindow(custumer);
                add.ShowDialog();

                if (add.DialogResult.Value)
                {
                    await CustumerDBRepo.Insert(custumer); // Добавление в базу данных
                }

                ShowGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AllViewShow(object sender, RoutedEventArgs e)
        {
            ShowGrid();
        }


        private async void ShowGrid()
        {
            var data = await CustumerDBRepo.SelectAllCustumers();
            custumers.Clear(); // Очищаем коллекцию перед добавлением новых данных
            foreach (var custumer in data)
            {
                custumers.Add(custumer); // Добавляем в коллекцию
            }
        }

        private async Task CreateDataSet()
        {
            try
            {
                if (custumers.Count == 0) { return; }

                for (int i = 0; i < 10; i++)
                {
                    await CustumerDBRepo.Insert(new Custumer(
                        Guid.NewGuid(),
                        "Фамилия_" + i,
                        "Имя_" + i,
                        "Отчество_" + i,
                        "Номер_" + i,
                        "Имейл_" + i)
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}