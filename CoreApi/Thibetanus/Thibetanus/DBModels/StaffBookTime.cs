using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Thibetanus.DBModels
{
    public class StaffBookTime : Base
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string StaffCode { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string ServiceTimeCode { get; set; }

        public string CustomCode { get; set; }
    }
}
