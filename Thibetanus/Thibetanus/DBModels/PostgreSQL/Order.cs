using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thibetanus.DBModels.PostgreSQL
{
    class Order : Base
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CustomName { get; set; }
        public virtual Custom Custom { get; set; }
        [Required]
        public string SalonCode { get; set; }
        [Required]
        public string SalonName { get; set; }
        public virtual Salon Salon { get; set; }
        [Required]
        public string StaffName { get; set; }
        public virtual Staff Staff { get; set; }
        [Required]
        public string ServiceName { get; set; }
        public virtual Service Service { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string OrderTime { get; set; }

        public string ServiceTime { get; set; }
       
        public string CustomComment { get; set; }
       
        public string StaffComment { get; set; }

        public string Status { get; set; }
    }
}
