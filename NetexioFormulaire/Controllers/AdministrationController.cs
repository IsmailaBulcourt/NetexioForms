using Microsoft.AspNetCore.Mvc;
using NetexioFormulaire.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NetexioFormulaire.Controllers
{
    public class AdministrationController : Controller
    {
        
        public IActionResult CreateFormation()
        {
            return View();
        }

        public IActionResult CreateSession(AdministrationData Data)
        {
            AdministrationData.Dbconnect();
            DataTable data = Data.GetFormation();
            var tuple = new Tuple<DataTable, NetexioFormulaire.Models.AdministrationData>(data,new AdministrationData());
            return View(tuple);
        }

        public IActionResult DeleteFormation(AdministrationData Data)
        {
            AdministrationData.Dbconnect();
            DataTable data = Data.GetFormation();
            var tuple = new Tuple<DataTable, NetexioFormulaire.Models.AdministrationData>(data, new AdministrationData());
            return View(tuple);
        }

        public IActionResult DeleteSession(AdministrationData Data)
        {
            AdministrationData.Dbconnect();
            DataTable data = Data.GetSession();
            var tuple = new Tuple<DataTable, NetexioFormulaire.Models.AdministrationData>(data, new AdministrationData());
            return View(tuple);
        }

        public IActionResult SetActiveSession(AdministrationData Data)
        {
            AdministrationData.Dbconnect();
            DataTable data = Data.GetSession();
            var tuple = new Tuple<DataTable, NetexioFormulaire.Models.AdministrationData>(data, new AdministrationData());
            return View(tuple);
        }

        [HttpPost]
        public IActionResult Index(AdministrationData Data)
        {
            string Formationname = Data.FormationName.Replace(" ","_");
            AdministrationData.Dbconnect();
            AdministrationData.PostFormation(Formationname);
            return View();
        }

        [HttpPost]
        public IActionResult Createsession([Bind(Prefix = "Item2")] AdministrationData Data)
        {
            DateTime Begindate = Data.BeginDate;
            DateTime Enddate = Data.EndDate;
            string location = Data.Location;
            string trainer = Data.Trainer;
            string Selectedformation = Data.SelectedFormation;
            string Sessionname = "" +Selectedformation+"_"+location+"_"+trainer+"_"+Begindate.ToShortDateString().ToString().Replace("/","_")+"_"+Enddate.ToShortDateString().ToString().Replace("/","_")+"";
            AdministrationData.Dbconnect();
            AdministrationData.PostSession(Sessionname, Begindate, Enddate, Selectedformation, location, trainer);
            return View("Index");
        }

        [HttpPost]
        public IActionResult Deleteformation([Bind(Prefix = "Item2")] AdministrationData Data)
        {
            string formationtoDelete;
            if (Data.FormationToDelete != null) { 
             formationtoDelete= Data.FormationToDelete;
            }
            else
            {
                formationtoDelete = " ";
            }
            AdministrationData.Dbconnect();
            AdministrationData.DeleteFormation(formationtoDelete);
            return View("Index");
        }

        [HttpPost]
        public IActionResult Deletesession([Bind(Prefix = "Item2")] AdministrationData Data)
        {
            string sessiontoDelete;
            if (Data.SessionToDelete != null)
            {
                sessiontoDelete = Data.SessionToDelete;
            }
            else
            {
                sessiontoDelete = " ";
            }
            AdministrationData.Dbconnect();
            AdministrationData.DeleteSession(sessiontoDelete);
            return View("Index");
        }
        
        [HttpPost]
        public IActionResult SetSessionActive([Bind(Prefix = "Item2")] AdministrationData Data)
        {
            string sessiontoActivate;
            if (Data.SessionToActivate != null)
            {
                sessiontoActivate = Data.SessionToActivate;
            }
            else
            {
                sessiontoActivate = " ";
            }
            AdministrationData.Dbconnect();
            AdministrationData.SetActiveSession(sessiontoActivate);
            return View("Index");
        }
    }

}
