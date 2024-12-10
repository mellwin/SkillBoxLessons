namespace ModelAnimals
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
                default: return new NullAnimal();
            }

        }
    }
}
