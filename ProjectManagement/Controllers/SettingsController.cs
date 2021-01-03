using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManagement.BusinessLogic;
using ProjectManagement.ViewModel;

namespace ProjectManagement.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly IProjectStatusCore _status;
        private readonly IDonorCore _donor;
        private readonly IProjectBeneficiaryTypeCore _beneficiary;
        private readonly IProjectSectorCore _sector;
        private readonly ILocationCore _location;
        private readonly IReportTypeCore _reportType;

        public SettingsController(IProjectStatusCore status, IDonorCore donor, IProjectBeneficiaryTypeCore beneficiary, IProjectSectorCore sector, ILocationCore location, IReportTypeCore reportType)
        {
            _status = status;
            _donor = donor;
            _beneficiary = beneficiary;
            _sector = sector;
            _location = location;
            _reportType = reportType;
        }

        //*****Project Status*****
        public IActionResult ProjectStatus()
        {
            var model = _status.List();
            return View(model.Data);
        }

        [HttpPost]
        public IActionResult PostProjectStatus(ProjectStatusAddModel model)
        {
            var response = _status.Add(model);
            return Json(response);
        }

        [HttpPost]
        public IActionResult UpdateProjectStatus(ProjectStatusViewModel model)
        {
            var response = _status.Edit(model);
            return Json(response);
        }
       
        [HttpPost]
        public IActionResult DeleteProjectStatus(int id)
        {
            var response = _status.Delete(id);
            return Json(response);
        }


        //*****Project Donor*****
        public IActionResult ProjectDonor()
        {
            var model = _donor.List();
            return View(model.Data);
        }

        [HttpPost]
        public IActionResult PostDonor(DonorAddModel model)
        {
            var response = _donor.Add(model);
            return Json(response);
        }

        [HttpPost]
        public IActionResult UpdateProjectDonor(DonorViewModel model)
        {
            var response = _donor.Edit(model);
            return Json(response);
        }

        [HttpPost]
        public IActionResult DeleteProjectDonor(int id)
        {
            var response = _donor.Delete(id);
            return Json(response);
        }


        //*****Project Beneficiary Type*****
        public IActionResult BeneficiaryType()
        {
            var model = _beneficiary.List();
            return View(model.Data);
        }

        [HttpPost]
        public IActionResult PostBeneficiaryType(ProjectBeneficiaryTypeAddModel model)
        {
            var response = _beneficiary.Add(model);
            return Json(response);
        }

        [HttpPost]
        public IActionResult UpdateBeneficiaryType(ProjectBeneficiaryTypeViewModel model)
        {
            var response = _beneficiary.Edit(model);
            return Json(response);
        }

        [HttpPost]
        public IActionResult DeleteBeneficiaryType(int id)
        {
            var response = _beneficiary.Delete(id);
            return Json(response);
        }


        //****Country****
        public IActionResult Country()
        {
            var model = _location.CountryList();
            return View(model.Data);
        }

        [HttpPost]
        public IActionResult PostCountry(CountryAddModel model)
        {
            var response = _location.CountryAdd(model);
            return Json(response);
        }

        [HttpPost]
        public IActionResult UpdateCountry(CountryViewModel model)
        {
            var response = _location.CountryEdit(model);
            return Json(response);
        }

        [HttpPost]
        public IActionResult DeleteCountry(int id)
        {
            var response = _location.CountryDelete(id);
            return Json(response);
        }

        //*****State****
        public IActionResult State()
        {
            ViewBag.Country = new SelectList(_location.CountryDdl().Data, "value", "label");
            return View();
        }

        public IActionResult GetStateByCountry(int id)
        {
            var model = _location.StateList(id);
            return Json(model.Data);
        }

        [HttpPost]
        public IActionResult PostState(StateAddModel model)
        {
            var response = _location.StateAdd(model);
            return Json(response);
        }

        [HttpPost]
        public IActionResult UpdateState(StateEditModel model)
        {
            var response = _location.StateEdit(model);
            return Json(response);
        }

        [HttpPost]
        public IActionResult DeleteState(int id)
        {
            var response = _location.StateDelete(id);
            return Json(response);
        }

        //****City****
        public IActionResult City()
        {
            ViewBag.Country = new SelectList(_location.CountryDdl().Data, "value", "label");
            return View();
        }

        public IActionResult GetCityByState(int id)
        {
            var model = _location.CityList(id);
            return Json(model.Data);
        }

        [HttpPost]
        public IActionResult PostCity(CityAddModel model)
        {
            var response = _location.CityAdd(model);
            return Json(response);
        }

        [HttpPost]
        public IActionResult UpdateCity(CityEditModel model)
        {
            var response = _location.CityEdit(model);
            return Json(response);
        }

        [HttpPost]
        public IActionResult DeleteCity(int id)
        {
            var response = _location.CityDelete(id);
            return Json(response);
        }



        //*****Report Type*****
        public IActionResult ReportType()
        {
            var model = _reportType.List();
            return View(model.Data);
        }

        [HttpPost]
        public IActionResult PostReportType(ReportTypeAddModel model)
        {
            var response = _reportType.Add(model);
            return Json(response);
        }

        [HttpPost]
        public IActionResult UpdateReportType(ReportTypeViewModel model)
        {
            var response = _reportType.Edit(model);
            return Json(response);
        }

        [HttpPost]
        public IActionResult DeleteReportType(int id)
        {
            var response = _reportType.Delete(id);
            return Json(response);
        }
    }
}
