using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using NetexioFormulaire.Controllers;

namespace NetexioFormulaire.Models
{
    public class AdministrationData
    {
        public string FormationName { get; set; }
        public string SessionName { get; set; }
        public DataTable SessionList = new DataTable(); 
        public DataTable FormationList = new DataTable();
        public string SessionToActivate { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Trainer { get; set; }
        public string Location { get; set; }
        public string SelectedFormation { get; set; }
        public string FormationToDelete { get; set; }
        public string SessionToDelete { get; set; }
        

        public static SqlConnection Dbconnect()
        {
            string DataSource = "ntxsqleventmanager.database.windows.net";
            string DataBase = "ntxdbeventmanager";
            string Username = "adminntxsqleventmanager";
            string Password = "Pa$$@2021ntxev0";
            string connectionString =@"Data Source=" +DataSource+";Initial Catalog="+DataBase+ ";Persist Security Info=True;User ID="+Username+";Password="+Password;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            return sqlConnection;
        }


        public static SqlCommand PostFormation(string ToSend)
        {
            string cmdText = "INSERT INTO Formations (Formation_Name) VALUES ('" +ToSend+"');";
            SqlCommand postFormation = new SqlCommand(cmdText, Dbconnect());
            postFormation.ExecuteNonQuery();
            return postFormation;
        }

        public static SqlCommand PostSession(string SessionNameToSend,DateTime BeginDateToSend,DateTime EndDateToSend, string FormationToSend, string LocationToSend,string TrainerToSend)
        {
            string cmdText = "INSERT INTO Sessions (Nom,DatedeDebut,DatedeFin,Formation,Lieu,Formateur) VALUES ('" + SessionNameToSend+ "','" + BeginDateToSend.ToString() +"','"+EndDateToSend.ToString()+"','"+FormationToSend+"','"+LocationToSend+"','"+TrainerToSend+"');";
            string tableName = "" + SessionNameToSend + "_Review";
            tableName.Replace(" ", "_");
            string Tablecmdtext ="CREATE TABLE "+tableName+ " (Nom nvarchar(50), Session nvarchar(500), Note_Accueil nvarchar(50), Note_Salle nvarchar(50), Note_Materiel nvarchar(50), Note_Restauration nvarchar(50), Note_Contenu nvarchar(50), Note_Niveau nvarchar(50), Note_Support nvarchar(50), Note_Rythme nvarchar(50), Note_Maitrise nvarchar(50), Note_Com nvarchar(50) , Note_Dispo nvarchar(50), Formations nvarchar(500), Commentaires nvarchar(500) );";
            SqlCommand postSession = new SqlCommand(cmdText, Dbconnect());
            SqlCommand createTableSession = new SqlCommand(Tablecmdtext, Dbconnect());
            postSession.ExecuteNonQuery();
            createTableSession.ExecuteNonQuery();
            return postSession;
        }

        public DataTable GetFormation()
        {
            string sqlquery = "SELECT Formation_Name FROM Formations";
            SqlCommand getformation = new SqlCommand(sqlquery, Dbconnect());
            SqlDataAdapter sqlData = new SqlDataAdapter(getformation);
            DataTable dt = new DataTable();
            sqlData.Fill(dt);
            return dt;
        }

        public static SqlCommand DeleteFormation(string FormationtoDelete)
        {
            string cmdText = "DELETE FROM Formations WHERE Formation_Name = '" + FormationtoDelete + "'";
            SqlCommand deleteFormation = new SqlCommand(cmdText, Dbconnect());
            deleteFormation.ExecuteNonQuery();
            return deleteFormation;
        }

        public DataTable GetSession()
        {
            string cdmText = "SELECT Nom FROM Sessions";
            SqlCommand getsession = new SqlCommand(cdmText, Dbconnect());
            SqlDataAdapter sqlData = new SqlDataAdapter(getsession);
            DataTable dt = new DataTable();
            sqlData.Fill(dt);
            return dt;
        }

        public static SqlCommand DeleteSession(string SessiontoDelete)
        {
            string cmdText = "DELETE FROM Sessions WHERE Nom = '" + SessiontoDelete + "'";
            SqlCommand deleteSession = new SqlCommand(cmdText, Dbconnect());
            deleteSession.ExecuteNonQuery();
            return deleteSession;
        }

        public static SqlCommand SetActiveSession(string SessiontoActivate)
        {
            string cmdText = "UPDATE Sessions SET IsActive = 1 WHERE Nom = '"+SessiontoActivate+"'";
            SqlCommand setactiveSession = new SqlCommand(cmdText, Dbconnect());
            setactiveSession.ExecuteNonQuery();
            return setactiveSession;
        }

    }
}
