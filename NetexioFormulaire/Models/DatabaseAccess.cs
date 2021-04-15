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
        public string SessionList { get; set; }
        public DataTable FormationList = new DataTable();
        public Boolean SessionActive { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Trainer { get; set; }
        public string Location { get; set; }
        public string SelectedFormation { get; set; }
        

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
            string cmdText = "INSERT INTO Formations (Nom) VALUES ('" +ToSend+"');";
            SqlCommand postFormation = new SqlCommand(cmdText, Dbconnect());
            postFormation.ExecuteNonQuery();
            return postFormation;
        }

        public static SqlCommand PostSession(string SessionNameToSend,DateTime BeginDateToSend,DateTime EndDateToSend, string FormationToSend, string LocationToSend,string TrainerToSend)
        {
            string cmdText = "INSERT INTO Sessions (Nom,DatedeDebut,DatedeFin,Formation,Lieu,Formateur) VALUES ('" + SessionNameToSend+ "','" + BeginDateToSend+"','"+EndDateToSend+"','"+FormationToSend+"','"+LocationToSend+"','"+TrainerToSend+"');";
            SqlCommand postSession = new SqlCommand(cmdText, Dbconnect());
            postSession.ExecuteNonQuery();
            return postSession;
        }

        public DataTable GetFormation()
        {
            string sqlquery = "SELECT Nom FROM Formations";
            SqlCommand getformation = new SqlCommand(sqlquery, Dbconnect());
            SqlDataAdapter sqlData = new SqlDataAdapter(getformation);
            DataTable dt = new DataTable();
            sqlData.Fill(dt);
            return dt;
        }
    }
}
