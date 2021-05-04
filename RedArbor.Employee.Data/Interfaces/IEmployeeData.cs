using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedArbor.Employee.Data.Interfaces
{
    public interface IEmployeeData
    {
        bool InsertEmployee(Entities.Concrete.Employee.Employee prmEmployee);
        List<Entities.Concrete.Employee.Employee> GetAllEmployees();
        bool UpdateEmployee(Entities.Concrete.Employee.Employee prmEmployee);
        Entities.Concrete.Employee.Employee GetEmployeeByCompanyID(long prmCompanyID); 
        bool DeleteEmployee(long prmCompanyID);

        bool ValidateEmployee(long prmCompanyID, string prmUserName, bool prmIsUpdated);
    }
}
