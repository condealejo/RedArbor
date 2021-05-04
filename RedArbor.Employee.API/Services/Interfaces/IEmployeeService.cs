using System.Collections.Generic;

namespace RedArbor.Employee.API.Services.Interfaces
{
    public interface IEmployeeService
    {
        bool InsertEmployee(Entities.Concrete.Employee.Employee prmEmployee);
        bool ValidateEmployee(long prmCompanyID, string prmUserName, bool prmIsUpdated);
        List<Entities.Concrete.Employee.Employee> GetAllEmployees();
        bool UpdateEmployee(Entities.Concrete.Employee.Employee prmEmployee);
        Entities.Concrete.Employee.Employee GetEmployeeByCompanyID(long prmCompanyID);
        bool DeleteEmployee(long prmCompanyID);
    } 
}
