using BrainerHubDemoModel.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainerHubDemoService.BrainerHubDemoRepository.Interface
{
    public interface ITaskRepository
    {
        Task UpdateTask(UpdateTaskRequestModel updateTaskRequestModel,int task_id);
    }
}
