using BrainerHubDemoModel.POcSampleDB;
using BrainerHubDemoModel.RequestModel;
using BrainerHubDemoModel.SpDbContext;
using BrainerHubDemoService.BrainerHubDemoRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainerHubDemoService.BrainerHubDemoRepository.Implementation
{
    /// <summary>
    /// JobsRepository
    /// </summary>
    public class JobsRepository : IJobsRepository
    {
        #region Initialization
        // Initialize the database context class.
        POCSpDbContext _spdbcontext;

        public JobsRepository(POCSpDbContext spdbcontext)
        {
            _spdbcontext = spdbcontext;
        }
        #endregion

        #region Put
        /// <summary>
        /// Update Jobs
        /// </summary>
        /// <param name="UpdateJobsRequestModel"></param>
        /// <returns></returns>
        public async Task UpdateJob(UpdateJobsRequestModel updateJobsRequestModel,int job_id)
        {
            string sqlQuery = "[sp_API_Job_Update] {0},{1},{2},{3},{4}";
            object[] param = {job_id,updateJobsRequestModel.StatusId,updateJobsRequestModel.StatusCode,updateJobsRequestModel.CurrentContactId,updateJobsRequestModel.CurrentUser};
            await _spdbcontext.ExecuteStoreProceduredNoReturn(sqlQuery, param);
        }
        #endregion
    }
}
