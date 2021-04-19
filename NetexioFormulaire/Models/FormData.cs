using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace NetexioFormulaire.Models
{
    public class FormData
    {
        public string Name { get; set; }
        public string SelectedSession { get; set; }
        public string NoteAccueil { get; set; }
        public string NoteSalle { get; set; }
        public string NoteMateriel { get; set; }
        public string NoteRestauration { get; set; }
        public string NoteContenuCour { get; set; }
        public string NoteNiveauCour { get; set; }
        public string NoteSupportCour { get; set; }
        public string NoteRythme { get; set; }
        public string NoteMaitrise { get; set; }
        public string NoteCommEtPedagogie { get; set; }
        public string NoteDispo { get; set; }
        public string FormationsSouhaites { get; set; }
        public string Commentaires { get; set; }

        public static SqlConnection Dbconnect()
        {
            string DataSource = "ntxsqleventmanager.database.windows.net";
            string DataBase = "ntxdbeventmanager";
            string Username = "adminntxsqleventmanager";
            string Password = "Pa$$@2021ntxev0";
            string connectionString = @"Data Source=" + DataSource + ";Initial Catalog=" + DataBase + ";Persist Security Info=True;User ID=" + Username + ";Password=" + Password;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            return sqlConnection;
        }

        public DataTable GetSession()
        {
            string cdmText = "SELECT Nom FROM Sessions WHERE IsActive = 1";
            SqlCommand getsession = new SqlCommand(cdmText, Dbconnect());
            SqlDataAdapter sqlData = new SqlDataAdapter(getsession);
            DataTable dt = new DataTable();
            sqlData.Fill(dt);
            return dt;
        }

        public static SqlCommand Validate(string sessionName, string nom, string noteAccueil,string noteSalle, string noteMateriel, string noteRestau, string noteContenu, string noteNiveau, string noteSupport, string noteRythme, string noteMaitrise, string noteCom, string noteDispo, string formations, string commentaires)
        {
            string SessionName = ""+sessionName+"_Review";
            string cmdText = "INSERT INTO "+SessionName+" (Nom, Session, Note_Accueil, Note_Salle, Note_Materiel, Note_Restauration, Note_Contenu, Note_Niveau, Note_Support, Note_Rythme, Note_Maitrise, Note_Com, Note_Dispo, Formations, Commentaires) VALUES ('"+nom+"','"+sessionName+"','"+noteAccueil+"','"+noteSalle+"','"+noteMateriel+"','"+noteRestau+"','"+noteContenu+"','"+noteNiveau+"','"+noteSupport+"','"+noteRythme+"','"+noteMaitrise+"','"+noteCom+"','"+noteDispo+"','"+formations+"','"+commentaires+"'); ";
            SqlCommand validate = new SqlCommand(cmdText, Dbconnect());
            validate.ExecuteNonQuery();
            return validate;
        }
    }
}
