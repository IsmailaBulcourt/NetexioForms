using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetexioFormulaire.Controllers
{
    public class FormsController : Controller
    {
        public string Name { get; set; }
        public string Session { get; set; }
        public string Note_Accueil { get; set; }
        public string Note_Salle { get; set; }
        public string Note_Materiel { get; set; }
        public string Note_Restauration { get; set; }
        public string Note_Contenu { get; set; }
        public string Note_Niveau { get; set; }
        public string Note_Support { get; set; }
        public string Note_Rythme { get; set; }
        public int Note_Maitrise { get; set; }
        public int Note_Qualite_Com { get; set; }
        public int Note_Ecoute { get; set; }
        public string Formation_Desir { get; set; }
        public string Commentaire { get; set; }

        public ActionResult FormsPage1()
        {
            return View();
        }

        public ActionResult FormsPage2()
        {
            
            return View();
        }

        public ActionResult Validate()
        {
            return FormsPage1();
        }
    }
}
