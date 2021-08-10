using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class ProductDetailDto : IDto // Dto sayasinde tabloları birleştirip istediğimiz verileri tek seferde alabiliriz.
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public int UnitsInStock { get; set; }

    }
}
