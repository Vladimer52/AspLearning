using System.Collections.Generic;
using storeModel.Models;

namespace storeModel.ViewModels
{
    public class IndexViewModel
    {
       public IEnumerable<Laptop> Laptops { get; set; }
       public IEnumerable<CompanyModel> Companies { get; set; }
    }
}
