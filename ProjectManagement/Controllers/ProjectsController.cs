using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ProjectManagement.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        public IActionResult Features()
        {
            return View();
        }  
        
        public IActionResult AddProject(string id)
        {
            ViewBag.linkTitle = id;
            return View();
        }
    }
}
