﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNL.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DNL.Controllers
{
    [ViewLayout("_ProfileLayout")]
    public class ProfileController : Controller
    {
        //[Authorize]
        //public IActionResult Index() => View(GetData(nameof(Index)));

        //[Authorize(Roles = "Users")]
        //public IActionResult OtherAction() => View("Index",
        //    GetData(nameof(OtherAction)));

        //private Dictionary<string, object> GetData(string actionName) =>
        //    new Dictionary<string, object>
        //    {
        //        ["Action"] = actionName,
        //        ["User"] = HttpContext.User.Identity.Name,
        //        ["Authenticated"] = HttpContext.User.Identity.IsAuthenticated,
        //        ["Auth Type"] = HttpContext.User.Identity.AuthenticationType,
        //        ["In Users Role"] = HttpContext.User.IsInRole("Users")
        //    };

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}