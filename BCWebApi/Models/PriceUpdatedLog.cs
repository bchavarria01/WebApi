using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BCWebApi.Models
{
    public class PriceUpdatedLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PriceUpdatedLogId { get; set; }
        public int ProductId { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal NewPrice { get; set; }
    }
}
