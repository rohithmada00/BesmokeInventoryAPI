namespace BesmokeInventoryAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } // Erlenmeyer Flask, Beaker, etc.
        public string Size { get; set; } // 1 mL, 10 mL, etc.
        public string Material { get; set; } // Glass, Plastic
    }
}
