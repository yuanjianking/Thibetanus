using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Thibetanus.DBModels
{
    public class ServiceGroup :Base
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string GroupName { get; set; }
        [Required]
        public string ShowIndex { get; set; }
    }
}
