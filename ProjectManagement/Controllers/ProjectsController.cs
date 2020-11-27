using System;
using System.Collections.Generic;
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

        public IActionResult Features()
        {
            var model = _sector.List();
            return View(model.Data);
        }

        public IActionResult AddProject(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Features");

            ViewBag.linkTitle = _sector.Get(id.GetValueOrDefault()).Data.Sector;
            ViewBag.ProjectSectorId = _sector.Get(id.GetValueOrDefault()).Data.ProjectSectorId;

            ViewBag.Status = new SelectList(_status.Ddl().Data, "value", "label");
            ViewBag.Country = new SelectList(_location.CountryDdl().Data, "value", "label");
            ViewBag.Type = new SelectList(_type.Ddl().Data, "value", "label");
            ViewBag.ReportType = new SelectList(_reportType.Ddl().Data, "value", "label");

            return View();
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

        //POST: Add Project
        [HttpPost]
        public IActionResult PostAddProject(ProjectAddModel model)
        {
            foreach (var report in model.ProjectReports)
            {
                report.FileName = UploadedFile(report.Attachment);
                report.FileUrl = "~/FILES/projectReports";
            }
            
            var response = _project.Add(model);
            return Json(response);
        }

        private string UploadedFile(IFormFile file)
        {
            if (file == null) return null;

            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "FILES/projectReports");
            var fileExtension = Path.GetExtension(file.FileName);
            var fileName = Guid.NewGuid() + "." + fileExtension;
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return fileName;
        }
    }
}
