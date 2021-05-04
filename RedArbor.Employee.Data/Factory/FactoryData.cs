using RedArbor.Employee.Data.Concrete;
using RedArbor.Employee.Data.Interfaces;

namespace RedArbor.Employee.Data.Factory
{
    public class FactoryData
    {
        public static IEmployeeData CreateEmployeeData()
        {
            return new EmployeeData();
        }
    } 
}
