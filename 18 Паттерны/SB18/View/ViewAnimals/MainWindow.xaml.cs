using ModelAnimals;
using PresenterAnimals;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace ViewAnimals
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IViewMainWindow
    {
        ObservableCollection<IAnimal> animals;
        private readonly PresenterClass presenter;

        public MainWindow()
        {
            InitializeComponent();
            animals = []; //создаю коллекцию объектов на гриде
            presenter = new PresenterClass(this); //передаю в презентер методы из интерфейса
            //presenter.CreateDataSet(); // Создаем тестовые данные
            presenter?.RefillGrid(); // Загружаем данные в грид
        }

        private void GVCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                presenter?.Update(); //обновляю выбранную запсь в гриде
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void GVCurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                presenter?.Update(); //обновляю выбранную запсь в гриде
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
                await presenter.Delete(); //удаляю выбранную запсь в гриде
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
                var animal = GetSelectedInstanceFromGrid() ?? new NullAnimal();
                AddWindow add = new(animal);
                add.ShowDialog();

                if (add.DialogResult!.Value && add.Animal != null)
                {
                    // Добавление в базу данных из формы AddWindow
                    await presenter.Add(add.Animal);
                }

                await presenter.RefillGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void AllViewShow(object sender, RoutedEventArgs e)
        {
            await presenter.RefillGrid(); //вывожу данные на грид
        }


        public IAnimal GetSelectedInstanceFromGrid()
        {
            //возвращаю экземпляр объекта из строки в гриде
            return (IAnimal)gridView.SelectedItem;
        }

        public void ShowGrid(List<IAnimal> data)
        {
            animals.Clear(); // Очищаем коллекцию перед добавлением новых данных
            foreach (var animal in data)
            {
                animals.Add(animal); // Добавляем в коллекцию
            }
            gridView.ItemsSource = animals; // Устанавливаем источник данных
        }
    }
}