using System.Net;

namespace RedArbor.Employee.Entities.Concrete.Response
{
    /// <summary>
    /// Respuesta de peticiones.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ActionResultResponse<T>
    {
        #region Private employee
        private HttpStatusCode status;
        private string message;
        private T response;
        #endregion

        #region Public Employee
        public HttpStatusCode Status { get { return status; } }
        public string Message { get { return message; } }
        public T Response { get { return response; } }
        #endregion

        #region Constructor
        public ActionResultResponse(HttpStatusCode prmStatus, string prmMessage, T prmResponse)
        {
            status = prmStatus;
            message = prmMessage;
            response = prmResponse;
        }
        #endregion
    }
}
 