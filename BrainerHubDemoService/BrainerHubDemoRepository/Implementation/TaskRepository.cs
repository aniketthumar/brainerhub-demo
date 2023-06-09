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
    /// TaskRepository
    /// </summary>
    public class TaskRepository : ITaskRepository
    {
        #region Initialization
        // Initialize the database context class.
        POCSpDbContext _spdbcontext;

        public TaskRepository(POCSpDbContext spdbcontext)
        {
            _spdbcontext = spdbcontext;
        }
        #endregion

        #region Put
        /// <summary>
        /// Update Tasks
        /// </summary>
        /// <param name="UpdateTaskRequestModel"></param>
        /// <returns></returns>
        public async Task UpdateTask(UpdateTaskRequestModel updateTaskRequestModel,int task_id)
        {
            string sqlQuery = "[sp_API_Task_Update] {0},{1},{2},{3}";
            object[] param = { task_id, updateTaskRequestModel.Done, updateTaskRequestModel.CurrentContContactId, updateTaskRequestModel.CurrentUser};
            await _spdbcontext.ExecuteStoreProceduredNoReturn(sqlQuery, param);
        }
        #endregion
    }
}
