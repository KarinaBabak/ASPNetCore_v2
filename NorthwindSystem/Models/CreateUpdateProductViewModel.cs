using NorthwindSystem.Data.Models;
using System.Collections.Generic;

namespace NorthwindSystem.Models
{
    public class CreateUpdateProductViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Supplier> Suppliers { get; set; }
    }
}
