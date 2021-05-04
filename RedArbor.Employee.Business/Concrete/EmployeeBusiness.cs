using RedArbor.Employee.Business.Interfaces;
using RedArbor.Employee.Data.Factory;
using RedArbor.Employee.Data.Interfaces;
using System.Collections.Generic;

namespace RedArbor.Employee.Business.Concrete
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        public bool DeleteEmployee(long prmCompanyID)
        {
            IEmployeeData employeeData = FactoryData.CreateEmployeeData();
            return employeeData.DeleteEmployee(prmCompanyID);
        }

        public List<Entities.Concrete.Employee.Employee> GetAllEmployees()
        {
            IEmployeeData employeeData = FactoryData.CreateEmployeeData();
            return employeeData.GetAllEmployees();
        }

        public Entities.Concrete.Employee.Employee GetEmployeeByCompanyID(long prmCompanyID)
        {
            IEmployeeData employeeData = FactoryData.CreateEmployeeData();
            return employeeData.GetEmployeeByCompanyID(prmCompanyID);
        }
         
        public bool InsertEmployee(Entities.Concrete.Employee.Employee prmEmployee)
        {
            IEmployeeData employeeData = FactoryData.CreateEmployeeData();
            return employeeData.InsertEmployee(prmEmployee);
        }
         
        public bool UpdateEmployee(Entities.Concrete.Employee.Employee prmEmployee)
        {
            IEmployeeData employeeData = FactoryData.CreateEmployeeData();
            return employeeData.UpdateEmployee(prmEmployee);
        }

        public bool ValidateEmployee(long prmCompanyID, string prmUserName, bool prmIsUpdated) 
        {
            IEmployeeData employeeData = FactoryData.CreateEmployeeData();
            return employeeData.ValidateEmployee(prmCompanyID, prmUserName, prmIsUpdated);
        }
    }
}
