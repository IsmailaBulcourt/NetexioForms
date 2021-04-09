using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetexioFormulaire.Controllers
{
    public class FormsController : Controller
    {
        public ActionResult FormsPage1()
        {
            return View();
        }

        public ActionResult FormsPage2()
        {
            return View();
        }
    }
}
