using System.ComponentModel.DataAnnotations;

namespace SD_330_Demos.Models
{
    public abstract class Organism
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string BinomialName { get; set; }
        public string EnglishName { get; set; }
        public int AgeDays { get; set; }
        public double CellCount { get; set; }
        public string TypeOfReproduction { get; set; }

        public HashSet<Diet> Diets { get; set; } = new HashSet<Diet>();

        public Organism()
        {

        }
    }

    public class Animal: Organism
    {
        public int Legs { get; set; }

        [MaxLength(50)]
        public string Habitat { get; set; }
    }

    public class Plant :Organism
    {
        public bool Photosynthetic { get; set; }
    }
}
