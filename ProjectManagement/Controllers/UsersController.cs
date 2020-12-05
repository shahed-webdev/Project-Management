using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManagement.BusinessLogic;
using ProjectManagement.ViewModel;

namespace ProjectManagement.Controllers
{
    public class UsersController : Controller
    {
        private readonly IProjectSectorCore _sector;
        private readonly IRegistrationCore _registration;
        private readonly UserManager<IdentityUser> _userManager;

        public UsersController(IProjectSectorCore sector, IRegistrationCore registration, UserManager<IdentityUser> userManager)
        {
            _sector = sector;
            _registration = registration;
            _userManager = userManager;
        }


        //***Sub admin****
        public IActionResult CreateSubAdmin(int? id)
        {
            if (!id.HasValue) return RedirectToAction($"Features", $"Projects");

            var response = _sector.Get(id.GetValueOrDefault());
            if (!response.IsSuccess) return RedirectToAction($"Features", $"Projects");

            ViewBag.ProjectSector = response.Data;
            ViewBag.UserType = new SelectList(_registration.UserTypeDdl().Data, "value", "label");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubAdmin(SubAdminRegisterViewModel model)
        {
            ViewBag.UserType = new SelectList(_registration.UserTypeDdl().Data, "value", "label");

            //re assign sector
            if (model.ProjectSectorId != null)
            {
                var response = _sector.Get(model.ProjectSectorId.Value);
                if (!response.IsSuccess) return RedirectToAction($"Features", $"Projects");
                ViewBag.ProjectSector = response.Data;
            }


            if (!ModelState.IsValid) return View(model);

            var user = new IdentityUser { UserName = model.UserName, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password).ConfigureAwait(false);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, model.Type.ToString()).ConfigureAwait(false);

                _registration.AddSubAdmin(model);
                return RedirectToAction("SubAdminList", new { id = model.ProjectSectorId });
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }


        public IActionResult SubAdminList(int? id)
        {
            if (!id.HasValue) return RedirectToAction($"Features", $"Projects");

            var response = _sector.Get(id.GetValueOrDefault());
            if (!response.IsSuccess) return RedirectToAction($"Features", $"Projects");
            ViewBag.ProjectSector = response.Data;

            var list = _registration.UserList();

            return View(list.Data);
        }

        //Deactivate User Login
        public IActionResult DeactivateUserLogin(int id)
        {
            var response = _registration.ToggleActivation(id);
            return Json(response);
        }
    }
}
