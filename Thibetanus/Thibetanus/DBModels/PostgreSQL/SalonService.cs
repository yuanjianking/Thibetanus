using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thibetanus.DBModels.PostgreSQL
{
    class SalonService : Base
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("SalonCode")] //外键
        public string SalonCode { get; set; }
        [Required]
        [ForeignKey("ServiceCode")] //外键
        public string ServiceCode { get; set; }
        public virtual Service Service { get; set; }
    }
}
