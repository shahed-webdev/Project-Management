using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    public class ProjectLogFrameController : Controller
    {
        //Log Frame
        public IActionResult LogFrame(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Features", "Projects");
            return View();
        }

        //Log Frame Indicator
        public IActionResult LogFrameIndicator(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Features", "Projects");
            return View();
        }
    }
}
