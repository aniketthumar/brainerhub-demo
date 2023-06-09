
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using BrainerHubDemoModel.CustomModels;
using BrainerHubDemoModel.ResponseModel;
using BrainerHubDemoModel.SpDbContext;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BrainerHubDemoModel.Helper.Constants;
using static BrainerHubDemoModel.SpDbContext.StoreProcedureResult;

namespace BrainerHubDemoService
{
    public static class SpRepository
    {

        public static SearchPage<T> BindSearchList<T>(Dictionary<string, object> parameters, List<T> records)
        {
            SearchPage<T> result = new SearchPage<T>
            {
                List = records
            };


            int from = 0, size = 10;
            if (parameters != null)
            {
                if (parameters.ContainsKey(SearchParameters.PageSize) && parameters.ContainsKey(SearchParameters.PageStart))
                {
                    size = Convert.ToInt32(parameters[SearchParameters.PageSize]);
                    from = (Convert.ToInt32(parameters[SearchParameters.PageStart]) - 1) * size;
                    result.Meta.PageSize = size;
                    result.Meta.Page = Convert.ToInt32(parameters[SearchParameters.PageStart]);
                }
                else
                {
                    result.Meta.PageSize = size;
                    result.Meta.Page = from + 1;
                }
            }
            else
            {
                result.Meta.PageSize = size;
                result.Meta.Page = from + 1;
            }

            return result;
        }


        public static async Task<string> ExecuteStoreProcedure(this POCSpContext catalogDbContext, string sqlQuery, object[] param)
        {
            var response = await catalogDbContext.Set<ExecutreStoreProcedureResult>().FromSqlRaw(sqlQuery, param).ToListAsync(); ;

            if (response == null || response.Count <= 0) return string.Empty;

            var result = response.FirstOrDefault();

            if (result == null) return string.Empty;

            if (!string.IsNullOrEmpty(result.ErrorMessage))
            {
                if (result.Result == DatabaseErrorCodes.NotExist) //not exist
                {
                }
                else if (result.Result == DatabaseErrorCodes.NotAllowed)
                {
                }
            }
            return string.IsNullOrEmpty(result.Result) ? string.Empty : result.Result;

        }

        public static async Task<Page> ExecuteStoreProcedureForSearchList(this POCSpContext catalogDbContext, string sqlQuery, object[] param)
        {
            Page page = new Page();
            var response = await catalogDbContext.Set<ExecutreStoreProcedureResultList>().FromSqlRaw(sqlQuery, param).ToListAsync();
            if (response != null && response.Count > 0)
            {
                var result = response.FirstOrDefault();

                if (result == null) return page;


                page.Meta.TotalResults = result.TotalCount;
                if (!string.IsNullOrWhiteSpace(result.Result))
                {

                    var list = JArray.Parse(result.Result);


                    page.Result = result.Result;
                    return page;
                }
            }
            return page;
        }

    }
}
