using Microsoft.AspNetCore.Mvc;
using NetexioFormulaire.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NetexioFormulaire.Controllers
{
    public class FormsController : Controller
    {
        public string nom { get;set;}
        public string selectedSession { get; set; }
        public string noteAccueil { get; set; }
        public string noteSalle { get; set; }
        public string noteMateriel { get; set; }
        public string noteRestauration { get; set; }
        public string noteContenu { get; set; }
        public string noteNiveau { get; set; }
        public string noteSupport { get; set; }
        public string noteRythme { get; set; }

        public ActionResult FormsPage1(FormData Data)
        {
            FormData.Dbconnect();
            DataTable getSession = Data.GetSession();
            var tuple = new Tuple<DataTable, NetexioFormulaire.Models.FormData>(getSession, new FormData());
            return View(tuple);
        }
 
        [HttpPost]
        public ActionResult Validate([Bind(Prefix ="Item2")]FormData Data)
        {
            string nom = Data.Name;
            string selectedSession =Data.SelectedSession ;
            string noteAccueil = Data.NoteAccueil;
            string noteSalle = Data.NoteSalle;
            string noteMateriel = Data.NoteMateriel;
            string noteRestauration = Data.NoteRestauration ;
            string noteContenu = Data.NoteContenuCour;
            string noteNiveau = Data.NoteNiveauCour;
            string noteSupport = Data.NoteSupportCour;
            string noteRythme = Data.NoteRythme;
            string noteMaitrise = Data.NoteMaitrise;
            string noteComm = Data.NoteCommEtPedagogie;
            string noteDispo = Data.NoteDispo; 
            string formationS = Data.FormationsSouhaites;
            string commentaires = Data.Commentaires;
            FormData.Dbconnect();
            FormData.Validate(selectedSession,nom,noteAccueil,noteSalle,noteMateriel,noteRestauration,noteContenu,noteNiveau,noteSupport,noteRythme,noteMaitrise,noteComm,noteDispo,formationS,commentaires);

            return View("Index");
        }
    }
}
