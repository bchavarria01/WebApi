using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BCWebApi.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int StockQuantity { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<ProductsLog> ProductsLog { get; set; }
        public virtual ICollection<PriceUpdatedLog> PriceUpdatedLog { get; set; }
    }
}
