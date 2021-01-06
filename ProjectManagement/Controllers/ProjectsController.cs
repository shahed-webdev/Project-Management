using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManagement.BusinessLogic;
using ProjectManagement.ViewModel;
using System.Threading.Tasks;


namespace ProjectManagement.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly IProjectStatusCore _status;
        private readonly IProjectSectorCore _sector;
        private readonly IProjectBeneficiaryTypeCore _type;
        private readonly ILocationCore _location;
        private readonly IDonorCore _donor;
        private readonly IReportTypeCore _reportType;
        private readonly IProjectCore _project;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProjectsController(IProjectStatusCore status, IProjectBeneficiaryTypeCore type, ILocationCore location,
            IProjectSectorCore sector, IDonorCore donor, IReportTypeCore reportType, IProjectCore project,
            IWebHostEnvironment webHostEnvironment)
        {
            _status = status;
            _type = type;
            _location = location;
            _sector = sector;
            _donor = donor;
            _reportType = reportType;
            _project = project;
            _webHostEnvironment = webHostEnvironment;
        }

        //features
        public IActionResult Features()
        {
            var model = _sector.List();
            return View(model.Data);
        }

        //add project
        public IActionResult AddProject(int? id)
        {
            if (!id.HasValue) return RedirectToAction($"Features");

            var response = _sector.Get(id.GetValueOrDefault());
            if (!response.IsSuccess) return RedirectToAction($"Features");

            ViewBag.ProjectSector = response.Data;

            ViewBag.Status = new SelectList(_status.Ddl().Data, "value", "label");
            ViewBag.Country = new SelectList(_location.CountryDdl().Data, "value", "label");
            ViewBag.Type = new SelectList(_type.Ddl().Data, "value", "label");
            ViewBag.ReportType = new SelectList(_reportType.Ddl().Data, "value", "label");

            return View();
        }


        //POST: add project(ajax)
        [HttpPost]
        public IActionResult PostAddProject(ProjectAddModel model)
        {
            var response = _project.Add(model, _webHostEnvironment.WebRootPath);
            return Json(response);
        }




        //get state by country
        public IActionResult GetStateByCountry(int id)
        {
            var response = _location.StateDdl(id);
            return Json(response);
        }

        //get city by State
        public IActionResult GetCityByState(int id)
        {
            var response = _location.CityDdl(id);
            return Json(response);
        }

        //find donors
        public async Task<IActionResult> FindDonors(string name)
        {
            var response = await _donor.SearchAsync(name);
            return Json(response.Data);
        }


        /***project list**/
        public IActionResult List(int? id)
        {
            if (!id.HasValue) return RedirectToAction($"Features");

            var response = _sector.Get(id.GetValueOrDefault());
            if (!response.IsSuccess) return RedirectToAction($"Features");

            ViewBag.ProjectSector = response.Data;

            var model = _project.List(id.GetValueOrDefault());
            return View(model.Data);
        }

        //add expense
        [HttpPost]
        public IActionResult AddExpense(ProjectExpediterAddModel model)
        {
            var response = _project.AddExpediter(model);
            return Json(response);
        }


        /***Update Project**/
        [Route("/Projects/UpdateProject")]
        [Route("/Projects/UpdateProject/{id}/{project}")]
        public IActionResult UpdateProject(int? id, int project)
        {
            if (!id.HasValue) return RedirectToAction($"Features");

            var response = _sector.Get(id.GetValueOrDefault());
            if (!response.IsSuccess) return RedirectToAction($"Features");

            ViewBag.ProjectSector = response.Data;

            var responseProject = _project.Get(project);

            if (!responseProject.IsSuccess)
                return RedirectToAction($"List", new { id });

            ViewBag.Status = new SelectList(_status.Ddl().Data, "value", "label", responseProject.Data.ProjectStatusId);
            ViewBag.Country = new SelectList(_location.CountryDdl().Data, "value", "label");
            ViewBag.Type = new SelectList(_type.Ddl().Data, "value", "label");
            ViewBag.ReportType = new SelectList(_reportType.Ddl().Data, "value", "label");

            return View(responseProject.Data);
        }

        //POST: update project(ajax)
        [HttpPost]
        public IActionResult UpdateProject(ProjectEditModel model)
        {
            var response = _project.Edit(model);
            return Json(response);
        }


        //delete project
        public IActionResult DeleteProject(int id)
        {
            var response = _project.Delete(id);
            return Json(response);
        }


        /***Report****/
        public IActionResult Report(int? id)
        {
            if (!id.HasValue) return RedirectToAction($"Features");

            var response = _sector.Get(id.GetValueOrDefault());
            if (!response.IsSuccess) return RedirectToAction($"Features");
            ViewBag.ProjectSector = response.Data;
            ViewBag.ProjectName = new SelectList(_project.Ddl(id.Value).Data, "value", "label");

            return View();
        }

        //get report
        public IActionResult GetReport(int id)
        {
            var response = _project.Reports(id);
            return Json(response);
        }
    }
}
