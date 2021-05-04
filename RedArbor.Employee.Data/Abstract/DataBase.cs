using RedArbor.Employee.Data.Factory;
using RedArbor.Employee.Entities.Concrete.Enum;
using System.Data;

namespace RedArbor.Employee.Data.Abstract
{
    public abstract class DataBase
    {
        /// <summary>
        /// Obtiene la conexión de la base de datos según el enumerador
        /// </summary>
        /// <param name="prmDb">Base de datos a conectar</param>
        /// <returns>Conexión a DB</returns>
        protected static IDbConnection GetConnection(Database prmDb = Database.RedArbor)
        {
            return ConnectionFactory.CreateConnection(prmDb);
        }
    } 
}
