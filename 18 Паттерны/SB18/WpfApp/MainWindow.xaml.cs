using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataRowView row;
        DataTable dt;
        ObservableCollection<IAnimal> animals;
        private readonly IRepository _repository = new AnimalDBRepo();

        public MainWindow()
        {
            InitializeComponent();
            animals = new ObservableCollection<IAnimal>();
            gridView.ItemsSource = animals; // Устанавливаем источник данных
            //CreateDataSet(); // Создаем данные
            ShowGrid(); // Загружаем данные в Grid
        }

        private void GVCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                var selectedAnimal = (IAnimal)gridView.SelectedItem;
                if (selectedAnimal != null)
                {
                    _repository.Update(selectedAnimal); // Сохранение изменений
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
                var animal = (IAnimal)gridView.SelectedItem;
                if (animal != null) await _repository.Update(animal); // Сохранение изменений в базу данных
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
                var animal = gridView.SelectedItem as IAnimal;
                if (animal != null)
                {
                    await _repository.Delete(animal.Id); // Удаление из базы данных
                    animals.Remove(animal);
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
                var animal = (IAnimal)gridView.SelectedItem;
                AddWindow add = new AddWindow(animal);
                add.ShowDialog();

                if (add.DialogResult!.Value && add.Animal != null)
                {
                    await _repository.Insert(add.Animal); // Добавление в базу данных из формы AddWindow
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
            var data = await _repository.SelectAll();
            animals.Clear(); // Очищаем коллекцию перед добавлением новых данных
            foreach (var animal in data)
            {
                animals.Add(animal); // Добавляем в коллекцию
            }
        }

        private async Task CreateDataSet()
        {
            Random rnd = new Random();

            Dictionary<int, string> classes = new Dictionary<int, string>() {
                                                                                {1, "Млекопитающее"},
                                                                                {2, "Птица"},
                                                                                {3, "Амфибия"}
                                                                            };
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    int a = rnd.Next(1, classes.Count + 1);
                    await _repository.Insert(AnimalFactory.CreateAnimal(classes[a], "Имя_" + i, "Вид_" + i, "Питание_" + i));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}