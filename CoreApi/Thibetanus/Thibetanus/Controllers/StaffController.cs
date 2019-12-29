using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Thibetanus.Controls.Service;
using Thibetanus.Controls.Staff;

namespace Thibetanus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        // GET api/values
        [HttpGet("{salonCode}")]
        public ActionResult<string> Get(string salonCode)
        {
            return JsonConvert.SerializeObject(new StaffControl().GetStaffInfosBySalon(salonCode));
        }
    }
}
