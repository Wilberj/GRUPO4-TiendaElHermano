using System;
using System.Collections.Generic;
using System.Text;
namespace CAPA_DATOS
{
    public class SqlADOConexion
    {
        static string UserSQLConexion = "";
        public static SqlServerGDatos SQLM;
        static public bool IniciarConexion(string user, string password)
        {
            try
            {
                UserSQLConexion = "Data Source=MALI\\MALI;Initial Catalog=Tienda;Persist Security Info=True;User ID=sa;Password=1234";
                SQLM = new SqlServerGDatos(UserSQLConexion);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
