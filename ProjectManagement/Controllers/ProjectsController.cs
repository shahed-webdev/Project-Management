using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManagement.BusinessLogic;


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
   

        public ProjectsController(IProjectStatusCore status, IProjectBeneficiaryTypeCore type, ILocationCore location, IProjectSectorCore sector, IDonorCore donor)
        {
            _status = status;
            _type = type;
            _location = location;
            _sector = sector;
            _donor = donor;
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

            ViewBag.Status = new SelectList(_status.Ddl().Data, "value", "label");
            ViewBag.Country = new SelectList(_location.CountryDdl().Data, "value", "label");
            ViewBag.Type = new SelectList(_type.Ddl().Data, "value", "label");

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
            return Json(response);
        }
    }
}
