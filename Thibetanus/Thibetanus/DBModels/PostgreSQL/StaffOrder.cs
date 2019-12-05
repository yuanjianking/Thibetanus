using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thibetanus.DBModels.PostgreSQL
{
    class StaffOrder : Base
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string StaffCode { get; set; }
        [Required]
        public string StaffName { get; set; }
        [Required]
        public string SalonCode { get; set; }
        [Required]
        public string SalonName { get; set; } 
       
        public string OrderTime { get; set; }
       }
}
