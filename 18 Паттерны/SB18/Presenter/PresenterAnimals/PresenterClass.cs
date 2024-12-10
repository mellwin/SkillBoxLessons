using ModelAnimals;

namespace PresenterAnimals
{
    public class PresenterClass
    {
        private readonly IViewMainWindow view;
        private readonly IRepository repo;
        public PresenterClass(IViewMainWindow view) 
        { 
            this.view = view;
            this.repo = new AnimalDBRepo();
        }

        public async Task RefillGrid()
        {
            //делаю выборку данных и вывожу на интерфейс
            var data = await repo.SelectAll();
            view.ShowGrid(data);
        }

        public async Task Delete()
        {
            //получаю выбранный на интерфейсе объект, проверяю его на null и удаляю его из БД
            var dataRow = view.GetSelectedInstanceFromGrid();
            if (dataRow != null)
            {
                await repo.Delete(dataRow.Id);
            }
            var data = await repo.SelectAll();
            view.ShowGrid(data);
        }

        public async Task Add(IAnimal dataRow)
        {
            //добавляю в БД новую запись
            await repo.Insert(dataRow);
        }

        public async Task Update()
        {
            // Сохранение изменений
            var dataRow = view.GetSelectedInstanceFromGrid();
            if (dataRow != null) await repo.Update(dataRow); 
        }

        public async void CreateDataSet()
        {
            //созданиеи тестового набора данных
            Random rnd = new();

            Dictionary<int, string> classes = new() {
                                                     {1, "Млекопитающее"},
                                                     {2, "Птица"},
                                                     {3, "Амфибия"}
            };

            for (int i = 0; i < 10; i++)
            {
                int a = rnd.Next(1, classes.Count + 1);
                var newDataRow = AnimalFactory.CreateAnimal(classes[a], "Имя_" + i, "Вид_" + i, "Питание_" + i);
                await repo.Insert(newDataRow);
            }
        }
    }
}