using System;
using System.Runtime.Serialization;

namespace RedArbor.Employee.Entities.Abstract
{
    /// <summary>
    /// Entidad Persona -- abst.
    /// </summary>
    [DataContract]
    public abstract class AbstractPerson
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember] 
        public string UserName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Telephone { get; set; }
        [DataMember]
        public string Fax { get; set; }
        [DataMember]
        public int PortalID { get; set; }
        [DataMember]
        public int RoleID { get; set; }
        [DataMember]
        public int StatusID { get; set; }
    }
}
