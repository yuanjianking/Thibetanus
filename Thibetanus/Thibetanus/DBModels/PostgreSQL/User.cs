using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thibetanus.DBModels.PostgreSQL
{
    class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public override string ToString()
        {
            var orders = new StringBuilder();
            foreach (var o in Orders)
            {
                orders.Append(o.ToString());
            }
            return $"UserId: {Id} Name: {Name} Orders: {orders.ToString()}";
        }
    }
}
