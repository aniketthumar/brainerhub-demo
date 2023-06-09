using BrainerHubDemoModel.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainerHubDemoService.BrainerHubDemoRepository.Interface
{
    public interface IJobsRepository
    {
        Task UpdateJob(UpdateJobsRequestModel updateJobsRequestModel,int job_id);

    }
}
