using RedArbor.Employee.Entities.Abstract;
using System;
using System.Runtime.Serialization;

namespace RedArbor.Employee.Entities.Concrete.Employee
{
    /// <summary>
    /// Entidad Empleado. 
    /// </summary>
    [DataContract]
    public class Employee : AbstractPerson
    {
        [DataMember] 
        public long CompanyID { get; set; }
        [DataMember]
        public DateTime DeletedOn { get; set; }
        [DataMember]
        public DateTime LastLogin { get; set; }
        [DataMember]
        public DateTime CreatedOn { get; set; }
        [DataMember]
        public DateTime UpdatedOn { get; set; }
    }
}
