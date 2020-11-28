using Microsoft.AspNetCore.Mvc;
using ProjectManagement.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManagement.ViewModel;

namespace ProjectManagement.Controllers
{
   
    public class ProjectLogFrameController : Controller
    { 
        private readonly ILogFrameCore _logFrame;
        private readonly IProjectCore _project;

        public ProjectLogFrameController(ILogFrameCore logFrame, IProjectCore project)
        {
            this._logFrame = logFrame;
            _project = project;
        }

        //Log Frame
        public IActionResult LogFrame(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Features", "Projects");

            ViewBag.ProjectName = new SelectList(_project.Ddl(id.Value).Data, "value", "label");
            return View();
        }

        //POST: log frame
        [HttpPost]
        public IActionResult PostLogFrame(LogFrameModel model)
        {
            var response = _logFrame.AddorUpdate(model);
            return Json(response);
        }

        public IActionResult GetLogFrame(int id)
        {
            var response = _logFrame.Get(id);
            return Json(response);
        }

        //Log Frame Indicator
        public IActionResult LogFrameIndicator(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Features", "Projects");
            return View();
        }
    }
}
