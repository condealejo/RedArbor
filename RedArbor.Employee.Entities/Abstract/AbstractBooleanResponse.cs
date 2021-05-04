using System.Runtime.Serialization;

namespace RedArbor.Employee.Entities.Abstract
{
    [DataContract]
    public abstract class AbstractBooleanResponse : AbstractResponse
    {
        [DataMember] 
        public bool Successfull { get; set; }
    }
}
