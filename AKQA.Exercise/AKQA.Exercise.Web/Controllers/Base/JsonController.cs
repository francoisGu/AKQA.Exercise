using System.Net;
using System.Web.Mvc;

namespace AKQA.Exercise.Web.Controllers.Base
{
    public class JsonController : Controller
    {
        /// <summary>
        ///     Builds an empty <see cref="JsonResult" /> with no error message and the
        /// <see cref="HttpStatusCode.BadRequest" /> status.
        /// </summary>
        /// <returns></returns>
        protected JsonResult BadRequest()
        {
            return BadRequest(string.Empty);
        }

        /// <summary>
        ///     Builds a <see cref="JsonResult" /> with the <see cref="errorMessage" /> and the
        ///     <see cref="HttpStatusCode.BadRequest" /> status.
        /// </summary>
        protected JsonResult BadRequest(string errorMessage)
        {
            return BadRequest(errorMessage, 400, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        ///     Builds a <see cref="JsonResult" /> with the <see cref="errorMessage" /> and the <see cref="httpStatusCode" />.
        /// </summary>
        protected JsonResult BadRequest(string errorMessage, int httpStatusCode)
        {
            return BadRequest(errorMessage, httpStatusCode, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        ///     Builds a <see cref="JsonResult" /> with the <see cref="errorMessage" /> and the <see cref="httpStatusCode" />.
        /// </summary>
        protected JsonResult BadRequest(string errorMessage, int httpStatusCode, JsonRequestBehavior requestBehavior)
        {
            Response.Clear();
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = httpStatusCode;

            return Json(new { Error = errorMessage }, requestBehavior);
        }
    }
}