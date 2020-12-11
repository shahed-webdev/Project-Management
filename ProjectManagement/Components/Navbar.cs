using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagement.Components
{
    public class NavbarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> Invoke()
        {
            return View();
        }


        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    var model = socialIcons;
        //    return await Task.FromResult((IViewComponentResult)View("SocialLinks", model));
        //}
    }
}
