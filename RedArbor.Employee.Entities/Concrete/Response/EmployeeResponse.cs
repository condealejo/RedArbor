using RedArbor.Employee.Entities.Abstract;
using System.Runtime.Serialization;

namespace RedArbor.Employee.Entities.Concrete.Response
{
    [DataContract]
    public class EmployeeResponse : AbstractResponse
    {
        [DataMember]
        public Employee.Employee Employee { get; set; }
    }
}
 