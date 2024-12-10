using ModelAnimals;
using System.Windows;

namespace ViewAnimals
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public IAnimal? Animal { get; private set; }

        private AddWindow()
        {
            InitializeComponent();
        }

        public AddWindow(IAnimal animal) : this()
        {
            txtClassAnimal.Text = animal.ClassAnimal;
            txtName.Text = animal.Name;
            txtSpecies.Text = animal.Species;
            txtNutrition.Text = animal.Nutrition;

            cancelBtn.Click += delegate { this.DialogResult = false; };
            okBtn.Click += delegate
            {
                Animal = AnimalFactory.CreateAnimal(txtClassAnimal.Text, txtName.Text, txtSpecies.Text, txtNutrition.Text);
                this.DialogResult = true;
            };
        }
    }
}