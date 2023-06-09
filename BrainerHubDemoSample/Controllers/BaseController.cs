using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BrainerHubDemo.Helper;
using BrainerHubDemoModel.CustomModels;
using BrainerHubDemoModel.Helper;
using System.Web;

namespace BrainerHubDemo.Controllers
{
    /// <summary>
    /// BaseController inherits ControllerBase
    /// </summary>
    public class BaseController : ControllerBase
    {


        /// <summary>
        /// ToEscapeXml
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [NonAction]
        public string ToEscapeXml(string s)
        {
            string escapeString = s;
            if (!string.IsNullOrWhiteSpace(escapeString))
            {
                escapeString = escapeString.Replace("&", "&amp;");
                //escapeString = escapeString.Replace("'", "&apos;");
                escapeString = escapeString.Replace("'", "''");
                escapeString = escapeString.Replace("\"", "&quot;");
                escapeString = escapeString.Replace(">", "&gt;");
                escapeString = escapeString.Replace("<", "&lt;");
                escapeString = escapeString.Replace("[", "%[[");
                escapeString = escapeString.Replace("]", "]]");
            }
            return escapeString;
        }

        /// <summary>
        /// GetFormData
        /// </summary>
        /// <returns></returns>
        [NonAction]
        private Dictionary<string, string> GetFormData()
        {
            return Request.Form.Keys.Cast<string>().ToDictionary(key => key, key => Convert.ToString(Request.Form[key]));
        }
    }
}
