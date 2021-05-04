using Microsoft.AspNetCore.Mvc;
using RedArbor.Employee.Entities.Abstract;
using RedArbor.Employee.Entities.Concrete.Response;

namespace RedArbor.Employee.API.Controllers.Base
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        public IActionResult GetResponse<T>(ActionResultResponse<T> prmModel) where T : AbstractResponse
        {
            IActionResult actionResult = null;

            switch (prmModel.Status)
            {
                case System.Net.HttpStatusCode.OK:
                    actionResult = Ok(prmModel.Response);
                    break;
                case System.Net.HttpStatusCode.BadRequest:
                    actionResult = BadRequest(prmModel.Response);
                    break;
                case System.Net.HttpStatusCode.Unauthorized:
                    actionResult = Unauthorized();
                    break;
                default:
                    actionResult = Problem(prmModel.Message);
                    break;
            }
            return actionResult;
        }
    } 
}
