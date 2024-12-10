namespace WpfApp
{
    public static class AnimalFactory
    {
        public static IAnimal CreateAnimal(string classAnimal, string name, string species, string nutrition)
        {
            switch (classAnimal)
            {
                case "Млекопитающее":
                    return new Mammal(classAnimal, name, species, nutrition);
                case "Птица":
                    return new Bird(classAnimal, name, species, nutrition);
                case "Амфибия":
                    return new Amphibian(classAnimal, name, species, nutrition);
                default: throw new Exception("Нет такого животного");
            }

        }

        public static IAnimal CreateAnimal(Animal animal)
        {
            switch (animal.ClassAnimal)
            {
                case "Млекопитающее":
                    return new Mammal(animal.ClassAnimal, animal.Name, animal.Species, animal.Nutrition);
                case "Птица":
                    return new Bird(animal.ClassAnimal, animal.Name, animal.Species, animal.Nutrition);
                case "Амфибия":
                    return new Amphibian(animal.ClassAnimal, animal.Name, animal.Species, animal.Nutrition);
                default: throw new Exception("Нет такого животного");
            }

        }
    }
}
