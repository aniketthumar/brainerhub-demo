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
        /// fill params from model
        /// </summary>
        /// <param name="model">request params</param>
        /// <returns>dictinoary object </returns>
        protected Dictionary<string, object> FillParamesFromModel(SearchRequestModel model, long user_id = 0)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            double pageStart = 1, pageSize = 10;

            if (model != null)
            {
                if (!double.TryParse(model.Page.ToString(), out pageStart) || pageStart < -1)
                {
                    throw new HttpStatusCodeException(StatusCodes.Status400BadRequest, "Invalid Page Start");
                }
                if (!double.TryParse(model.PageSize.ToString(), out pageSize) || pageSize < -1)
                {
                    throw new HttpStatusCodeException(StatusCodes.Status400BadRequest, "Invalid Page Size");
                }
                if (!double.TryParse(model.PageSize.ToString(), out pageSize) || pageSize > 1000)
                {
                    throw new HttpStatusCodeException(StatusCodes.Status400BadRequest, "Page size must be less than 1000");
                }
                if (!string.IsNullOrWhiteSpace(model.SortColumn))
                {
                    //TODO: can add condition here  for check allowed column or not
                    parameters.Add(Constants.SearchParameters.SortColumn, model.SortColumn.Trim());
                }
                else
                {
                    parameters.Add(Constants.SearchParameters.SortColumn, "LastModifiedByDateTime");
                }
                if (!string.IsNullOrWhiteSpace(model.SortOrder))
                {
                    parameters.Add(Constants.SearchParameters.SortOrder, model.SortOrder.Trim());
                }
                else
                {
                    parameters.Add(Constants.SearchParameters.SortOrder, "desc");
                }
                if (!string.IsNullOrWhiteSpace(model.SearchText))
                {
                    model.SearchText = ToEscapeXml(model.SearchText);
                    parameters.Add(Constants.SearchParameters.SearchText, model.SearchText.Trim());
                }
                else
                {
                    parameters.Add(Constants.SearchParameters.SearchText, "%");
                }
                if (!string.IsNullOrWhiteSpace(model.Filters))
                {
                    // check here for fields allowrd or not
                    string filter = "";
                    if (model.Filters.IsValidJson())
                    {
                        filter = GetFilterConditionFromModel(model.Filters.ToString().Trim());
                      
                    }
                    parameters.Add(Constants.SearchParameters.Filters, filter.Trim());
                }
                else
                {
                    parameters.Add(Constants.SearchParameters.Filters, " 1=1 and");
                }
            }
            if (user_id > 0)
            {
                parameters.Add("logged_in_userid", user_id);
            }
            parameters.Add(Constants.SearchParameters.PageStart, pageStart);
            parameters.Add(Constants.SearchParameters.PageSize, pageSize);
            return parameters;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        protected string GetFilterConditionFromModel(string filter)
        {
            string condition = " ";
            if (filter == null)
            {
                return condition;
            }


            var filterConditions = JsonConvert.DeserializeObject<List<FilterRequestModel>>(filter);

            int i = 0;
            foreach (var item in filterConditions)
            {
                i++;
                if (item.Value != null)
                {
                    item.Value = ToEscapeXml(item.Value.ToString());
                }
                if (!string.IsNullOrWhiteSpace(item.Condition))
                {
                    if (item.Condition.ToLower() == "in")
                    {
                        var data = item.Value.ToString().Split(",");
                        string query = string.Empty;
                        int j = 0;
                        foreach (var val in data)
                        {
                            j++;
                            var intValue = 0;
                            bool isInt = int.TryParse(val, out intValue);
                            if (isInt)
                            {
                                query += intValue;
                            }
                            else
                            {
                                query += "'" + val + "'";
                            }
                            if (j < data.Count())
                            {
                                query += " , ";
                            }
                        }

                        condition += item.Key + " in (" + query + ")";
                    }
                    else if (item.Condition.ToLower() == "nin")
                    {
                        var data = item.Value.ToString().Split(",");
                        string query = string.Empty;
                        int j = 0;
                        foreach (var val in data)
                        {
                            j++;
                            var intValue = 0;
                            bool isInt = int.TryParse(val, out intValue);
                            if (isInt)
                            {
                                query += intValue;
                            }
                            else
                            {
                                query += "'" + val + "'";
                            }
                            if (j < data.Count())
                            {
                                query += " , ";
                            }
                        }

                        condition += item.Key + " not in (" + query + ")";
                    }
                    else if (item.Condition.ToLower() == "between")
                    {
                        var intValue = 0;
                        bool isInt = int.TryParse(item.From.ToString(), out intValue);

                        if (isInt)
                        {
                            condition += item.Key + " between " + item.From + " AND " + item.To;
                        }
                        else
                        {
                            try
                            {
                                if (Convert.ToDateTime(item.From) == Convert.ToDateTime(item.To))
                                {
                                    item.To = Convert.ToDateTime(item.To).AddHours(23.59).ToString("yyyy-MM-dd HH:mm:ss");
                                }

                            }
                            catch (Exception)
                            {

                            }
                            condition += item.Key + " between '" + item.From + "' AND '" + item.To + "'";
                        }
                    }
                    else if (item.Condition.ToLower() == "=")
                    {
                        var data = item.Key.ToString().Split(",");
                        string query = "( ";
                        int j = 0;

                        var intValue = 0;
                        bool isInt = int.TryParse(item.Value.ToString(), out intValue);

                        foreach (var keyVal in data)
                        {
                            j++;

                            if (isInt)
                            {
                                query += keyVal + " = " + intValue;
                            }
                            else
                            {
                                query += keyVal + "  = '" + item.Value + "'";
                            }
                            if (j < data.Count())
                            {
                                query += " OR ";
                            }
                        }
                        condition += query + " ) ";
                    }
                    else if (item.Condition.ToLower() == ">=")
                    {
                        var data = item.Key.ToString().Split(",");
                        string query = "( ";
                        int j = 0;

                        var intValue = 0;
                        bool isInt = int.TryParse(item.Value.ToString(), out intValue);

                        foreach (var keyVal in data)
                        {
                            j++;

                            if (isInt)
                            {
                                query += keyVal + " >= " + intValue;
                            }
                            else
                            {
                                query += keyVal + "  >= '" + item.Value + "'";
                            }
                            if (j < data.Count())
                            {
                                query += " OR ";
                            }
                        }
                        condition += query + " ) ";
                    }
                    else if (item.Condition.ToLower() == ">")
                    {
                        var data = item.Key.ToString().Split(",");
                        string query = "( ";
                        int j = 0;

                        var intValue = 0;
                        bool isInt = int.TryParse(item.Value.ToString(), out intValue);

                        foreach (var keyVal in data)
                        {
                            j++;

                            if (isInt)
                            {
                                query += keyVal + " > " + intValue;
                            }
                            else
                            {
                                query += keyVal + "  > '" + item.Value + "'";
                            }
                            if (j < data.Count())
                            {
                                query += " OR ";
                            }
                        }
                        condition += query + " ) ";
                    }
                    else if (item.Condition.ToLower() == "<=")
                    {
                        var data = item.Key.ToString().Split(",");
                        string query = "( ";
                        int j = 0;

                        var intValue = 0;
                        bool isInt = int.TryParse(item.Value.ToString(), out intValue);

                        foreach (var keyVal in data)
                        {
                            j++;

                            if (isInt)
                            {
                                query += keyVal + " #lte# " + intValue;
                            }
                            else
                            {
                                query += keyVal + "  #lte# '" + item.Value + "'";
                            }
                            if (j < data.Count())
                            {
                                query += " OR ";
                            }
                        }
                        condition += query + " ) ";
                    }
                    else if (item.Condition.ToLower() == "<")
                    {
                        var data = item.Key.ToString().Split(",");
                        string query = "( ";
                        int j = 0;

                        var intValue = 0;
                        bool isInt = int.TryParse(item.Value.ToString(), out intValue);

                        foreach (var keyVal in data)
                        {
                            j++;

                            if (isInt)
                            {
                                query += keyVal + " #lt# " + intValue;
                            }
                            else
                            {
                                query += keyVal + "  #lt# '" + item.Value + "'";
                            }
                            if (j < data.Count())
                            {
                                query += " OR ";
                            }
                        }
                        condition += query + " ) ";
                    }
                    else
                    {
                        throw new HttpStatusCodeException(StatusCodes.Status400BadRequest, "Invalid Filter Condition");
                    }
                }
                else
                {
                    // (key = 1 or key like '%test%')

                    var data = item.Key.ToString().Split(",");
                    string query = "( ";
                    int j = 0;

                    var intValue = 0;
                    bool isInt = int.TryParse(item.Value.ToString(), out intValue);

                    if (!string.IsNullOrWhiteSpace(item.Type) && item.Type != typeof(int).ToString())
                    {
                        isInt = false;

                    }

                    foreach (var keyVal in data)
                    {
                        j++;

                        if (isInt)
                        {
                            query += keyVal + " = " + intValue;
                        }
                        else
                        {
                            query += keyVal + "  LIKE ('%" + item.Value + "%')";
                        }
                        if (j < data.Count())
                        {
                            query += " OR ";
                        }
                    }
                    condition += query + " ) ";

                }


                condition += " AND ";

            }
            return condition;
        }


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

        /// <summary>
        /// BindSearchResult
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="model"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        [NonAction]
        public SearchPage<T> BindSearchResult<T>(SearchPage<T> list, SearchRequestModel model, string key)
        {
            if (list.Meta.NextPageExists)
                list.Meta.NextPageUrl = HttpUtility.UrlDecode(HttpContext.Request.HttpContext.AddOrReplaceQueryParameter("page", model.Page + 1 + ""));
            if (model.Page > 1)
                list.Meta.PreviousPageUrl = HttpUtility.UrlDecode(HttpContext.Request.HttpContext.AddOrReplaceQueryParameter("page", model.Page - 1 + ""));
            list.Meta.Url = HttpUtility.UrlDecode(HttpContext.Request.HttpContext.AddOrReplaceQueryParameter("page", model.Page + ""));
            list.Meta.FirstPageUrl = HttpUtility.UrlDecode(HttpContext.Request.HttpContext.AddOrReplaceQueryParameter("page", 1 + ""));
            list.Meta.Key = key;
            if (list.Meta.TotalResults > 0)
            {
                if (list.Meta.PageSize != 0)
                    list.Meta.TotalPages = (int)Math.Ceiling((double)list.Meta.TotalResults / list.Meta.PageSize);
                else
                    list.Meta.TotalPages = (int)list.Meta.TotalResults;
            }
            return list;
        }

        /// <summary>
        /// BindSearchResult page
        /// </summary>
        /// <param name="list"></param>
        /// <param name="model"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        [NonAction]
        public Page BindSearchResult(Page list, SearchRequestModel model, string key)
        {
            list.Meta.FirstPageUrl = HttpContext.Request.HttpContext.AddOrReplaceQueryParameter("page", 1 + "");
            list.Meta.Url = HttpContext.Request.HttpContext.AddOrReplaceQueryParameter("page", model.Page + "");
            list.Meta.Page = model.Page;
            list.Meta.PageSize = model.PageSize;
            if (list.Meta.TotalResults > 0)
            {
                if (list.Meta.TotalResults > (model.Page * model.PageSize))
                {
                    list.Meta.NextPageUrl = HttpContext.Request.HttpContext.AddOrReplaceQueryParameter("page", model.Page + 1 + "");
                }
                if (model.Page > 1)
                    list.Meta.PreviousPageUrl = HttpContext.Request.HttpContext.AddOrReplaceQueryParameter("page", model.Page - 1 + "");

                list.Meta.TotalPages = (int)Math.Ceiling((double)list.Meta.TotalResults / model.PageSize);

            }
            list.Meta.Key = key;
            return list;
        }

    }
}
