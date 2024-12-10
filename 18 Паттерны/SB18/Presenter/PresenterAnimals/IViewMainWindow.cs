using ModelAnimals;

namespace PresenterAnimals
{
    public interface IViewMainWindow
    {
        IAnimal GetSelectedInstanceFromGrid();

        void ShowGrid(List<IAnimal> data);

    }
}