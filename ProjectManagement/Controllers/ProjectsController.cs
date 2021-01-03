using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManagement.BusinessLogic;
using ProjectManagement.ViewModel;


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
            foreach (var report in model.ProjectReports)
            {
                report.FileName = UploadedFile(report.Attachment, "projectReports");
                report.FileUrl = "~/FILES/projectReports";
            }
            
            model.Photo = UploadedFile(model.FilePhoto, "projectReports");

            var response = _project.Add(model);
            return Json(response);
        }

        private string UploadedFile(IFormFile file, string subPath)
        {
            if (file == null) return null;

            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, $"FILES/{subPath}");
            var fileExtension = Path.GetExtension(file.FileName);
            var fileName = Guid.NewGuid() + "." + fileExtension;
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return fileName;
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
    }
}
