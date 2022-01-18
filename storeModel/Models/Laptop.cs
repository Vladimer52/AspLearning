namespace storeModel.Models
{
    public class Laptop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Company Company { get; set; }
        public decimal Price { get; set; }
    }
}
