using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thibetanus.DBModels.PostgreSQL
{
    class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Item { get; set; }
        [Required]
        public string Description { get; set; }
        public virtual User User { get; set; }

        public override string ToString()
        {
            return $"OrderId: {Id} Item: {Item} Descriptoin: {Description}";
        }
    }
}
