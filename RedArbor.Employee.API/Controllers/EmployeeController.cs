using Microsoft.AspNetCore.Mvc;
using RedArbor.Employee.API.Controllers.Base;
using RedArbor.Employee.API.Services.Interfaces;
using RedArbor.Employee.Entities.Concrete.Enum;
using RedArbor.Employee.Entities.Concrete.Response;
using RedArbor.Employee.Entities.Concrete.Validators;
using RedArbor.Employee.Exceptions;
using RedArbor.Employee.Mapper;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace RedArbor.Employee.API.Controllers
{
    [Route("api/redarbore")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _service;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service"></param>
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        /// <summary>
        /// Metodo que obtiene un Dummy del objeto Employee.
        /// </summary>
        /// <returns>Objeto employee vacio</returns>
        [HttpGet]
        [Route("Dummy")]
        public async Task<IActionResult> GetDummyEmployee()
        {
            Entities.Concrete.Employee.Employee employee = new Entities.Concrete.Employee.Employee();
            ActionResultResponse<EmployeeResponse> response;
            try
            {
                response = EmployeeMapper.EmployeeGetByIdResult(employee);
            }
            catch (Exception ex)
            {
                LogException.WriteLog(ex, "EmployeeController.InsertEmployee", JsonSerializer.Serialize(employee), LogType.Error);
                response = new ActionResultResponse<EmployeeResponse>(System.Net.HttpStatusCode.InternalServerError, MessageException.GetGeneralMessage(ex), null);
            }
            return GetResponse(response);
        }

        /// <summary>
        /// Metodo encargado de crear un empleado 
        /// </summary>
        /// <param name="employeeRequest">Información del empleado</param>
        /// <returns>Confirmación de si se creo correctamente</returns>
        /// <response code="200">Consulta de forma exitosa</response>
        /// <response code="500">Ha ocurrido un error</response>
        /// <response code="400">Error en la información enviada</response>
        /// <response code="401">No autorizado</response>
        [HttpPost]
        public async Task<IActionResult> InsertEmployee([FromBody] Entities.Concrete.Employee.Employee employeeRequest)
        {
            ActionResultResponse<EmployeeResponse> response;
            Entities.Concrete.Employee.Employee employee = null;
            try
            {
                if (_service.ValidateEmployee(employeeRequest.CompanyID, employeeRequest.UserName, false))
                {
                    if (_service.InsertEmployee(employeeRequest)) 
                    {
                        employee = _service.GetEmployeeByCompanyID(employeeRequest.CompanyID);
                    }
                    response = EmployeeMapper.EmployeeGetByIdResult(employee);
                }
                else
                {
                    response = new ActionResultResponse<EmployeeResponse>(System.Net.HttpStatusCode.Locked, MessageException.GetEmployeeAlreadyExists(employeeRequest.CompanyID, employeeRequest.UserName), null);
                }
            }
            catch (Exception ex)
            {
                LogException.WriteLog(ex, "EmployeeController.InsertEmployee", JsonSerializer.Serialize(employeeRequest), LogType.Error);
                response = new ActionResultResponse<EmployeeResponse>(System.Net.HttpStatusCode.InternalServerError, MessageException.GetGeneralMessage(ex), null);
            }
            return GetResponse(response);
        }

        /// <summary>
        /// Este metodo obtiene todos los empleados de la base de datos ordenados por fecha de creacion,
        /// del mas reciente al mas antiguo DESC, y que no sean eliminados STATUS 3. 
        /// </summary>
        /// <returns>Retorna una lista de tipo Empleado.</returns>
        /// <response code="200">Consulta de forma exitosa</response>
        /// <response code="500">Ha ocurrido un error</response>
        /// <response code="400">Error en la información enviada</response>
        /// <response code="401">No autorizado</response>
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            List<Entities.Concrete.Employee.Employee> employeesList = null;
            ActionResultResponse<EmployeeListResponse> response;
            try
            {
                employeesList = _service.GetAllEmployees();
                response = EmployeeMapper.EmployeeGetAllToActionResult(employeesList);
            }
            catch (Exception ex)
            {
                LogException.WriteLog(ex, "EmployeeController.InsertEmployee", JsonSerializer.Serialize(employeesList), LogType.Error);
                response = new ActionResultResponse<EmployeeListResponse>(System.Net.HttpStatusCode.InternalServerError, MessageException.GetGeneralMessage(ex), null);
            }
            return GetResponse(response);
        }

        /// <summary>
        /// Metodo que obtiene un empleado dado su CompanyID, no importa el estado.
        /// </summary>
        /// <param name="prmCompanyID">Codigo de compañia</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{prmCompanyID}")]
        public async Task<IActionResult> GetEmployeeByCompanyID(long prmCompanyID)
        {
            Entities.Concrete.Employee.Employee employee = null;
            ActionResultResponse<EmployeeResponse> response;
            try
            {
                employee = _service.GetEmployeeByCompanyID(prmCompanyID);
                response = EmployeeMapper.EmployeeGetByIdResult(employee);
            }
            catch (Exception ex)
            {
                LogException.WriteLog(ex, "EmployeeController.InsertEmployee", JsonSerializer.Serialize(employee), LogType.Error);
                response = new ActionResultResponse<EmployeeResponse>(System.Net.HttpStatusCode.InternalServerError, MessageException.GetGeneralMessage(ex), null);
            }
            return GetResponse(response);
        }

        /// <summary>
        /// Metodo encargado de actualizar un empleado, tener en cuenta que el CompanyID no se puede cambiar, es la llave primaria. 
        /// </summary>
        /// <param name="employeeRequest">Información del empleado</param>
        /// <returns>Confirmación de si se creo correctamente</returns>
        /// <response code="200">peticion de forma exitosa</response>
        /// <response code="500">Ha ocurrido un error</response>
        /// <response code="400">Error en la información enviada</response>
        /// <response code="401">No autorizado</response>
        [HttpPut]
        [Route("{prmCompanyID}")]
        public async Task<IActionResult> UpdateEmployee(long prmCompanyID, [FromBody] Entities.Concrete.Employee.Employee employeeRequest)
        {
            ActionResultResponse<EmployeeCreatedOrUpdateResponse> response;
            try
            {
                if (_service.ValidateEmployee(prmCompanyID, employeeRequest.UserName, true))
                {
                    employeeRequest.CompanyID = prmCompanyID;
                    bool result = _service.UpdateEmployee(employeeRequest);
                    response = EmployeeMapper.EmployeeCreatedOrUpdateToActionResult(result);
                }
                else
                {
                    response = new ActionResultResponse<EmployeeCreatedOrUpdateResponse>(System.Net.HttpStatusCode.Locked, MessageException.GetEmployeeAlreadyExists(employeeRequest.CompanyID, employeeRequest.UserName, true), null);
                }
            }
            catch (Exception ex)
            {
                LogException.WriteLog(ex, "EmployeeController.InsertEmployee", JsonSerializer.Serialize(employeeRequest), LogType.Error);
                response = new ActionResultResponse<EmployeeCreatedOrUpdateResponse>(System.Net.HttpStatusCode.InternalServerError, MessageException.GetGeneralMessage(ex), null);
            }
            return GetResponse(response);
        }

        /// <summary>
        /// Metodo encargado realizar un eliminado logico de un empleado, dado su identificador CompanyID
        /// </summary>
        /// <param name="prmCompanyID">Identificador unico de empleado</param>
        /// <returns>Confirmación de si se creo correctamente</returns>
        /// <response code="200">peticion de forma exitosa</response>
        /// <response code="500">Ha ocurrido un error</response>
        /// <response code="400">Error en la información enviada</response>
        /// <response code="401">No autorizado</response>
        [HttpDelete]
        [Route("{prmCompanyID}")]
        public async Task<IActionResult> DeleteEmployee(long prmCompanyID)
        {
            ActionResultResponse<EmployeeCreatedOrUpdateResponse> response;
            try
            {
                bool result = _service.DeleteEmployee(prmCompanyID);
                response = EmployeeMapper.EmployeeCreatedOrUpdateToActionResult(result);
            }
            catch (Exception ex)
            {
                LogException.WriteLog(ex, "EmployeeController.InsertEmployee", JsonSerializer.Serialize(prmCompanyID), LogType.Error);
                response = new ActionResultResponse<EmployeeCreatedOrUpdateResponse>(System.Net.HttpStatusCode.InternalServerError, MessageException.GetGeneralMessage(ex), null);
            }
            return GetResponse(response);
        }
    }
}
