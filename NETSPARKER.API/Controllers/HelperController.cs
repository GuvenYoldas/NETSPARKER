using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NETSPARKER.API.Controllers
{
    public class HelperController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}