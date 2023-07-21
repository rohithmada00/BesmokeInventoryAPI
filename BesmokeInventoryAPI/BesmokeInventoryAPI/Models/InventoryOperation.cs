namespace BesmokeInventoryAPI.Models
{
    public class InventoryOperation
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int AmountChanged { get; set; } // +in / -out
    }
}
