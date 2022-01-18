using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace models.Models
{
    public class Phone
    {
        public int Id { get; set; }
        //[BindRequired] //обязательный параметр
        public string Name { get; set; }
        public Company Company { get; set; }
        public decimal Price { get; set; }
       // [BindNever] //никогда не должен устанавливаться в ручную
        public bool HasRight { get; set; }
    }
}
