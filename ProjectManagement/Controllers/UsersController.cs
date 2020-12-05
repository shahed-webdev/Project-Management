using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagement.BusinessLogic;

namespace ProjectManagement.Controllers
{
    public class UsersController : Controller
    {
        private readonly IProjectSectorCore _sector;

        public UsersController(IProjectSectorCore sector)
        {
            _sector = sector;
        }


        //***Sub admin****
        public IActionResult CreateSubAdmin(int? id)
        {
            if (!id.HasValue) return RedirectToAction($"Features", $"Projects");

            var response = _sector.Get(id.GetValueOrDefault());
            if (!response.IsSuccess) return RedirectToAction($"Features", $"Projects");

            ViewBag.ProjectSector = response.Data;
            return View();
        } 
        
        public IActionResult SubAdminList(int? id)
        {
            if (!id.HasValue) return RedirectToAction($"Features", $"Projects");

            var response = _sector.Get(id.GetValueOrDefault());
            if (!response.IsSuccess) return RedirectToAction($"Features", $"Projects");

            ViewBag.ProjectSector = response.Data;
            return View();
        }
    }
}
