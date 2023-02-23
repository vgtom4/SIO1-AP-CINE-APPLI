using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.util;

namespace AP_CINE_APPLI
{
    class passerelle
    {
        public static List<filmClass> ChargementFilms()
        {
            List<filmClass> mesFilms = new List<filmClass>();

            OdbcConnection cnn = new OdbcConnection();
            OdbcCommand cmd = new OdbcCommand();
            OdbcDataReader drr;
            bool existenfilm;


            cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=" + password.pwdDb + "";
            cnn.Open();

            cmd.CommandText = "select * from film";
            cmd.Connection = cnn;

            drr = cmd.ExecuteReader();
            existenfilm = drr.Read();

            while (existenfilm == true)
            {
                mesFilms.Add(new filmClass(Convert.ToInt32(drr["nofilm"]), drr["titre"].ToString(), drr["realisateurs"].ToString(), drr["acteurs"].ToString(), drr["duree"].ToString(), drr["synopsis"].ToString(), drr["infofilm"].ToString(), drr["imgaffiche"].ToString(), Convert.ToInt32(drr["nopublic"])));
                existenfilm = drr.Read();
            }
            drr.Close();

            return mesFilms;


        }
    }
}