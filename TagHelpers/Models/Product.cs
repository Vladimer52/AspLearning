namespace TagHelpers.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }

        public Company Company { get; set; }
        public int CompanyId { get; set; }
    }
}
