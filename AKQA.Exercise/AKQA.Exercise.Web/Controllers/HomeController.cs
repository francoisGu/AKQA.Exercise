using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AKQA.Exercise.Web.Controllers.Base;
using AKQA.Exercise.AppLogic.Services;

namespace AKQA.Exercise.Web.Controllers
{
    public class HomeController : JsonController
    {
        private readonly INumToWords _numToWords;

        public HomeController(INumToWords numToWords)
        {
            _numToWords = numToWords;
        }

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///     API post username
        /// </summary>
        /// <param name="username"> username </param>
        /// <returns>username/badrequest</returns>
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public JsonResult GetUsername(string username)
        {
            return string.IsNullOrWhiteSpace(username) ?
                    BadRequest("Name shall not be empty") :
                    Json(username, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        ///     API post a double number
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Number As Words</returns>
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public JsonResult GetNumberWord(double number)
        {
            var result = _numToWords.ConvertNumToWords(number);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
