using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetexioFormulaire.Controllers
{
    public class AdministrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateFormation()
        {
            return View();
        }

        public IActionResult CreateSession()
        {
            return View();
        }

        public IActionResult DeleteFormation()
        {
            return View();
        }

        public IActionResult DeleteSession()
        {
            return View();
        }

        public IActionResult SetActiveSession()
        {
            return View();
        }
    }
}
