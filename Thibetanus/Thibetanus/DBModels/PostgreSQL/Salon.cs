using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thibetanus.DBModels.PostgreSQL
{
    class Salon
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [ForeignKey("LocationCode")] //外键
        public string LocationCode { get; set; }     
        [Required]
        [ForeignKey("ManagerCode")] //外键
        public string ManagerCode { get; set; }
    }
}
