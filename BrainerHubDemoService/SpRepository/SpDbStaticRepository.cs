using Microsoft.EntityFrameworkCore;
using BrainerHubDemoModel.ResponseModel;
using BrainerHubDemoModel.SpDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainerHubDemoService
{
    public static class SpDbStaticRepository
    {
        public static async Task<List<StudentListResponse>> ExecuteStoreProcedureStudent(this POCSpDbContext catalogDbContext, string sqlQuery, object[] param)
        {
            var response = await catalogDbContext.Set<StudentListResponse>().FromSqlRaw(sqlQuery, param).ToListAsync();
            return response;
        }

        public static async Task ExecuteStoreProceduredNoReturn(this POCSpDbContext catalogDbContext, string sqlQuery, object[] param)
        {
            var response = await catalogDbContext.Database.ExecuteSqlRawAsync(sqlQuery,param);
        }
    }
}
