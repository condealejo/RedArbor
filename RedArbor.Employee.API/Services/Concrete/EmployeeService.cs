using RedArbor.Employee.API.Services.Interfaces;
using RedArbor.Employee.Business.Interfaces;
using RedArbor.Employee.Business.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedArbor.Employee.API.Services.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        public bool DeleteEmployee(long prmCompanyID)
        {
            IEmployeeBusiness employeeBusiness = FactoryBusiness.CreateEmployeeBusiness();
            return employeeBusiness.DeleteEmployee(prmCompanyID);
        }
         
        public List<Entities.Concrete.Employee.Employee> GetAllEmployees()
        {
            IEmployeeBusiness employeeBusiness = FactoryBusiness.CreateEmployeeBusiness();
            return employeeBusiness.GetAllEmployees();
        }

        public Entities.Concrete.Employee.Employee GetEmployeeByCompanyID(long prmCompanyID)
        {
            IEmployeeBusiness employeeBusiness = FactoryBusiness.CreateEmployeeBusiness();
            return employeeBusiness.GetEmployeeByCompanyID(prmCompanyID);
        }

        public bool InsertEmployee(Entities.Concrete.Employee.Employee prmEmployee) 
        {
            IEmployeeBusiness employeeBusiness = FactoryBusiness.CreateEmployeeBusiness();
            return employeeBusiness.InsertEmployee(prmEmployee);
        }

        public bool ValidateEmployee(long prmCompanyID, string prmUserName, bool prmIsUpdated) 
        {
            IEmployeeBusiness employeeBusiness = FactoryBusiness.CreateEmployeeBusiness();
            return employeeBusiness.ValidateEmployee(prmCompanyID, prmUserName, prmIsUpdated);
        }

        public bool UpdateEmployee(Entities.Concrete.Employee.Employee prmEmployee)
        {
            IEmployeeBusiness employeeBusiness = FactoryBusiness.CreateEmployeeBusiness();
            return employeeBusiness.UpdateEmployee(prmEmployee);
        }
    }
}
