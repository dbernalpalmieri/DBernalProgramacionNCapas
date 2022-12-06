using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Conexion
    {

        public static bool GetConnectionStatus()
        {
      
            using (SqlConnection connection = new SqlConnection(GetConnection()))
            {
                try
                {
                    connection.Open();
                    return true;

                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }
        public static string GetConnection()
        {
            return ConfigurationManager.ConnectionStrings["DBernalProgramacionNCapas"].ToString();
        }

    }
}


/*
            * Cadena de conexión para el App.Config
            Data Source=DESKTOP-0FGOK40\SQLEXPRESS; Initial Catalog = DBernalDapperSQL; User ID = sa; Password = 123
            * Cadena de conexión si se usa normal como string
            Data Source=DESKTOP-0FGOK40\\SQLEXPRESS; Initial Catalog = DBernalDapperSQL; User ID = sa; Password = 123         


            private SqlConnection Connection = new SqlConnection("Data Source=LAPTOP-BS7JUEF6;Initial Catalog=DBernalDia3;Integrated Security=True");
            return ConfigurationManager.AppSettings["enlaceDB"].ToString(); ;
            */