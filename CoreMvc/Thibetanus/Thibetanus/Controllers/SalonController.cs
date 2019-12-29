using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Thibetanus.Models;

namespace Thibetanus.Controllers
{
    [Authorize]
    public class SalonController : Controller
    {
        public IActionResult SalonEdit()
        {
            return View();
        }
        
    }
}
