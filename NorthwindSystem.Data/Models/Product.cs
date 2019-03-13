using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NorthwindSystem.Data.Models
{
    public class Product : IModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required] // TODO: split validation and Model
        public string Name { get; set; }
        [MaxLength(300, ErrorMessage = "The impossible value of Quantity Per Unit")]
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        [Range(1, 100)]
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
 
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }

        //public Category Category { get; set; }
        //public Supplier Supplier { get; set; }

        public string SupplierName { get; set; }
        public string CategoryName { get; set; }

    }
}
