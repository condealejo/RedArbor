using System.Collections.Generic;

namespace RedArbor.Employee.Business.Interfaces
{
    public interface IEmployeeBusiness
    {
        bool ValidateEmployee(long prmCompanyID, string prmUserName, bool prmIsUpdated);
        bool InsertEmployee(Entities.Concrete.Employee.Employee prmEmployee);
        List<Entities.Concrete.Employee.Employee> GetAllEmployees();
        bool UpdateEmployee(Entities.Concrete.Employee.Employee prmEmployee);
        Entities.Concrete.Employee.Employee GetEmployeeByCompanyID(long prmCompanyID);
        bool DeleteEmployee(long prmCompanyID);
    }
} 
