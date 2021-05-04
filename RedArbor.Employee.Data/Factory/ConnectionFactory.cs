
using RedArbor.Employee.Entities.Concrete.Enum;
using RedArbor.Employee.Utilities;
using System;
using System.Data;
using System.Data.SqlClient;
 
namespace RedArbor.Employee.Data.Factory
{
    /// <summary>
    /// Fabrica de conexión a BD ! 
    /// </summary>
    public class ConnectionFactory
    {
        public static IDbConnection CreateConnection(Database prmDb = Database.RedArbor)
        {
            string connString = GetConnectionString(prmDb);

            IDbConnection conn = prmDb switch
            {
                Database.RedArbor => new SqlConnection(connString),
                _ => throw new Exception("Base de datos no soportada"),
            };
            conn.Open();
            return conn;
        }

        private static string GetConnectionString(Database prmDb)
        {
            string conn = prmDb switch
            {
                Database.RedArbor => Configuration.GetSectionConfiguration("ConnectionStrings", "RedArbor"),
                _ => throw new Exception("Base de datos no soportada"),
            };
            return conn;
        }
    }
}
