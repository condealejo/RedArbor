using RedArbor.Employee.Business.Concrete;
using RedArbor.Employee.Business.Interfaces;

namespace RedArbor.Employee.Business.Factory
{
    public class FactoryBusiness
    {
        public static IEmployeeBusiness CreateEmployeeBusiness()
        {
            return new EmployeeBusiness();
        }
    } 
}
