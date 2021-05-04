using RedArbor.Employee.Entities.Concrete.Response;
using System.Collections.Generic;

namespace RedArbor.Employee.Mapper
{
    public class EmployeeMapper
    {
        public static ActionResultResponse<EmployeeCreatedOrUpdateResponse> EmployeeCreatedOrUpdateToActionResult(bool prmCreatedOrUpdate)
        {
            EmployeeCreatedOrUpdateResponse response = new EmployeeCreatedOrUpdateResponse()
            {
                Successfull = prmCreatedOrUpdate
            };
            return new ActionResultResponse<EmployeeCreatedOrUpdateResponse>(System.Net.HttpStatusCode.OK, string.Empty, response);
        }

        public static ActionResultResponse<EmployeeListResponse> EmployeeGetAllToActionResult(List<Entities.Concrete.Employee.Employee> prmEmployeesList)
        {
            EmployeeListResponse response = new EmployeeListResponse()
            {
                EmployeesList = prmEmployeesList
            };
            return new ActionResultResponse<EmployeeListResponse>(System.Net.HttpStatusCode.OK, string.Empty, response);
        }

        public static ActionResultResponse<EmployeeResponse> EmployeeGetByIdResult(Entities.Concrete.Employee.Employee prmEmployee)
        {
            EmployeeResponse response = new EmployeeResponse()
            {
                Employee = prmEmployee
            };
            return new ActionResultResponse<EmployeeResponse>(System.Net.HttpStatusCode.OK, string.Empty, response);
        }
    } 
}
