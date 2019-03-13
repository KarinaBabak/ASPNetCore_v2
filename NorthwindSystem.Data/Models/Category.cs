using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindSystem.Data.Models
{
    public class Category : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
    }
}
