using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RetailInventory.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ProductDetail ProductDetail { get; set; }

        public virtual List<Tag> Tags { get; set; }
            = new();

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}