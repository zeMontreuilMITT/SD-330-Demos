namespace SD_330_Demos.Models
{
    public abstract class Organism
    {
        public int Id { get; set; }
        public string BinomialName { get; set; }
        public string EnglishName { get; set; }
        public int AgeDays { get; set; }
        public double CellCount { get; set; }
        public string TypeOfReproduction { get; set; }

        public HashSet<Diet> Diets { get; set; } = new HashSet<Diet>();


        public Organism(string binomial, string english)
        {
            BinomialName= binomial;
            EnglishName= english;
        }
    }

    public class Animal: Organism
    {

        // Animal cat = new Animal("Felis Catus", "Cat", 4);

        public int Legs { get; set; }

    }

    public class Plant :Organism
    {
        public bool Photosynthetic { get; set; }
    }
}
