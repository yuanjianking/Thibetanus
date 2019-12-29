using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Thibetanus.Controls.Service;

namespace Thibetanus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController: ControllerBase
    {
        // GET api/Service
        [HttpGet("{salonCode}")]
        public ActionResult<string> Get(string salonCode)
        {
            return JsonConvert.SerializeObject(new ServiceControl().GetAllServices(salonCode));
        }
    }
}
