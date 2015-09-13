using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using HtmlAgilityPack;

namespace Comda.Test.Controllers
{
    public class TestController : Controller
    {
        public ActionResult WebSkills()
        {
            return View("WebSkills");
        }


        public ActionResult RegEx()
        {
            MatchCollection model;
            try
            {
                var url = "http://www.bbc.com";
                HtmlWeb stream = new HtmlWeb();
                HtmlDocument doc = stream.Load(url);
                var content = doc.DocumentNode.InnerHtml;
                var regex = new System.Text.RegularExpressions.Regex(@"(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);


                model = regex.Matches(content);

            }
            catch (Exception)
            {
                
                throw;
            }



            return View("RegEx", model);
        }

    }
}
