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

        [HttpPost]
        public IActionResult Index([Bind(Prefix = "Item2")] AdministrationData Data)
        {
            string Formationname = Data.FormationName;
            DateTime Begindate = Data.BeginDate;
            DateTime Enddate = Data.EndDate;
            string location = Data.Location;
            string trainer = Data.Trainer;
            string Selectedformation =Data.SelectedFormation;
            string Sessionname = ""+Selectedformation+"-" +Begindate+ "-"+Enddate+"-"+location+"-"+trainer+"";
            if (Formationname!= null) { 
            AdministrationData.Dbconnect();
            AdministrationData.PostFormation(Formationname);
            }
            else
            {
                AdministrationData.Dbconnect();
                AdministrationData.PostSession(Sessionname,Begindate,Enddate,Selectedformation,location,trainer);
            }
            return View();
        }

   
    }

}
