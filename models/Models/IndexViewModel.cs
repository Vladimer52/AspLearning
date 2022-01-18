using System.Collections.Generic;

namespace models.Models
{
    public class IndexViewModel
    {
       public IEnumerable<Phone> Phones { get; set; }
       public IEnumerable<CompanyViewModel> Companies { get; set; }
    }
}
