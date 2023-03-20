namespace SD_330_Demos.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public HashSet<Diet> Diets { get; set; }= new HashSet<Diet>();
    }

    public class Diet
    {
        public int Id { get; set; }
        public int OrganismId { get; set; }
        public Organism Organism { get; set; }

        public Food Food { get; set; }
        public int FoodId { get; set; }
    }
}
