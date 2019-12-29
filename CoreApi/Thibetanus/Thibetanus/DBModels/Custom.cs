using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thibetanus.DBModels
{
    public class Custom : Base
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
      
        public string Age { get; set; }

        public string Sex { get; set; }

        public string Height { get; set; }

        public string Weight { get; set; }

        public string Blood { get; set; }

        public string Tel { get; set; }
     
        public string WeiXin { get; set; }

        public string Detail { get; set; }

        [Required]
        public string SalonCode { get; set; }
    }
}
