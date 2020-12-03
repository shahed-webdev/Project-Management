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
        private readonly ILogFrame1stStepCore _logFrameStep1;
        private readonly IProjectCore _project;
        private readonly IProjectSectorCore _sector;

        public ProjectLogFrameController(ILogFrameCore logFrame, IProjectCore project, IProjectSectorCore sector, ILogFrame1stStepCore logFrameStep1)
        {
            this._logFrame = logFrame;
            _project = project;
            _sector = sector;
            _logFrameStep1 = logFrameStep1;
        }

        //****Log Frame****
        public IActionResult LogFrame(int? id)
        {
            if (!id.HasValue) return RedirectToAction($"Features", $"Projects");

            var response = _sector.Get(id.GetValueOrDefault());
            if (!response.IsSuccess) return RedirectToAction($"Features", $"Projects");

            ViewBag.ProjectSector = response.Data;
            ViewBag.ProjectName = new SelectList(_project.Ddl(id.Value).Data, "value", "label");
           
            return View();
        }

        //POST: log frame(ajax)
        [HttpPost]
        public IActionResult PostLogFrame(LogFrameModel model)
        {
            var response = _logFrame.AddorUpdate(model);
            return Json(response);
        }

        //on project select(ajax)
        public IActionResult GetLogFrame(int id)
        {
            var response = _logFrame.Get(id);
            return Json(response);
        }



        //****Log Frame Indicator****
        public IActionResult LogFrameIndicator(int? id)
        {
            if (!id.HasValue) return RedirectToAction($"Features", $"Projects");

            var response = _sector.Get(id.GetValueOrDefault());
            if (!response.IsSuccess) return RedirectToAction($"Features", $"Projects");

            ViewBag.ProjectSector = response.Data;
            ViewBag.ProjectName = new SelectList(_project.Ddl(id.Value).Data, "value", "label");

            return View();
        }

        //POST: log frame(ajax)
        [HttpPost]
        public IActionResult PostLogFrameIndicator(LogFrame1stStepModel model)
        {
            var response = _logFrameStep1.AddorUpdate(model);
            return Json(response);
        }

        //on project select(ajax)
        public IActionResult GetLogFrameIndicator(int id)
        {
            var response = _logFrameStep1.Get(id);
            return Json(response);
        }
    }
}
