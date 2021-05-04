using RedArbor.Employee.Entities.Abstract;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RedArbor.Employee.Entities.Concrete.Response
{
    [DataContract]
    public class EmployeeListResponse : AbstractResponse
    {
        [DataMember]
        public List<Employee.Employee> EmployeesList { get; set; }
    }
}
 