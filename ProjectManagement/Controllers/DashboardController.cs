using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ProjectManagement.BusinessLogic;

namespace ProjectManagement.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IProjectSectorCore _sector;

        public DashboardController(IProjectSectorCore sector)
        {
            _sector = sector;
        }

        public IActionResult Index(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Features", "Projects");
            ViewBag.linkTitle = _sector.Get(id.GetValueOrDefault()).Data.Sector;

            return View();
        }
    }
}
