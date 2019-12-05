using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thibetanus.DBModels.PostgreSQL
{
    class SalonStaff
    { 
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("SalonCode")] //外键
        public string SalonCode { get; set; }
        [Required]
        [ForeignKey("StaffCode")] //外键
        public string StaffCode { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
