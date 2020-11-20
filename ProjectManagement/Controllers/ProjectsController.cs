using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManagement.BusinessLogic;

namespace ProjectManagement.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        //private readonly IProjectStatusCore _status;

        //public ProjectsController(IProjectStatusCore status)
        //{
        //    _status = status;
        //}

        public IActionResult Features()
        {
            return View();
        }  
        
        public IActionResult AddProject(string id)
        {
            ViewBag.linkTitle = id;
            //ViewBag.Status = new SelectList(_status.Ddl().Data, "value", "label");

            return View();
        }
    }
}
