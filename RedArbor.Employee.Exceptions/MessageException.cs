using System;

namespace RedArbor.Employee.Exceptions
{
    public class MessageException
    {
        public static string GetGeneralMessage(Exception ex)
        {
            return $"Ha ocurrido un error en la aplicación: {ex.Message}";
        }

        public static string GetEmployeeAlreadyExists(long prmCompanyID, string prmUserName, bool prmIsUpdate = false) 
        {
            if (!prmIsUpdate)
            {
                return $"Ya existe un empleado con el CompanyId: {prmCompanyID} o con un UserName: {prmUserName.Trim()}";
            }
            else {
                return $"Ya existe un empleado con el UserName: {prmUserName.Trim()}";
            }
            
        }
    }
}
