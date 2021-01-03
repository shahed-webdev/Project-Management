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
        private readonly ILogFrame2ndStepOutputCore _logFrameStep2;
        private readonly ILogFrame3rdStepActivityCore _logFrameStep3;
        private readonly IProjectCore _project;
        private readonly IProjectSectorCore _sector;
        private readonly IProjectBeneficiaryTypeCore _type;
        private readonly ILocationCore _location;

        public ProjectLogFrameController(ILogFrameCore logFrame, IProjectCore project, IProjectSectorCore sector, ILogFrame1stStepCore logFrameStep1, ILogFrame2ndStepOutputCore logFrameStep2, ILogFrame3rdStepActivityCore logFrameStep3, IProjectBeneficiaryTypeCore type, ILocationCore location)
        {
            this._logFrame = logFrame;
            _project = project;
            _sector = sector;
            _logFrameStep1 = logFrameStep1;
            _logFrameStep2 = logFrameStep2;
            _logFrameStep3 = logFrameStep3;
            _type = type;
            _location = location;
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
            ViewBag.Participants = new SelectList(_type.Ddl().Data, "value", "label");
            ViewBag.Country = new SelectList(_location.CountryDdl().Data, "value", "label");

            return View();
        }


        //POST: Step1 log frame(ajax)
        [HttpPost]
        public IActionResult PostLogFrameIndicatorStep1(LogFrame1stStepModel model)
        {
            var response = _logFrameStep1.AddorUpdate(model);
            return Json(response);
        }

        //POST: Step2 log frame(ajax)
        [HttpPost]
        public IActionResult PostLogFrameIndicatorStep2(LogFrame2ndStepModel model)
        {
            var response = _logFrameStep2.AddorUpdate(model);
            return Json(response);
        }

        //POST: Step3 log frame(ajax)
        [HttpPost]
        public IActionResult PostLogFrameIndicatorStep3(LogFrame3rdStepModel model)
        {
            var response = _logFrameStep3.AddorUpdate(model);
            return Json(response);
        }

        //on project select(ajax)
        public IActionResult GetLogFrameIndicatorStep(int id, int step)
        {
            switch (step)
            {
                case 1:
                {
                    var response = _logFrameStep1.Get(id);
                    return Json(response);
                }
                case 2:
                {
                    var response = _logFrameStep2.Get(id);
                    return Json(response);
                }
                case 3:
                {
                    var response = _logFrameStep3.Get(id);
                    return Json(response);
                }
                default:
                    return Json("");
            }
        }


        //***Delete***
        [HttpPost]
        public IActionResult DeleteStep1(int id)
        {
            var response = _logFrameStep1.Delete(id);
            return Json(response);
        }

        [HttpPost]
        public IActionResult DeleteStep2(int id)
        {
            var response = _logFrameStep2.Delete(id);
            return Json(response);
        }

        [HttpPost]
        public IActionResult DeleteStep3(int id)
        {
            var response = _logFrameStep3.Delete(id);
            return Json(response);
        }
    }
}

