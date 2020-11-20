using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
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

        public SettingsController(IProjectStatusCore status, IDonorCore donor, IProjectBeneficiaryTypeCore beneficiary, IProjectSectorCore sector)
        {
            this._status = status;
            _donor = donor;
            _beneficiary = beneficiary;
            _sector = sector;
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


        //*****Project Sector*****
        public IActionResult ProjectSector()
        {
            var model = _sector.List();
            return View(model.Data);
        }

        [HttpPost]
        public IActionResult PostProjectSector(ProjectSectorAddModel model)
        {
            var response = _sector.Add(model);
            return Json(response);
        }
    }
}
