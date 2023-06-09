using BrainerHubDemoModel.RequestModel;
using BrainerHubDemoModel.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainerHubDemoService.BrainerHubDemoRepository.Interface
{
    public interface IStudentRepository
    {
        Task<List<StudentListResponse>> Liststudent(StudentListRequestModel studentListRequestModel);
        Task CreateStudent(StudentRequestModel studentRequestModel);
        Task UpdateStudent(UpdateStudentRequestModel updateStudentRequestModel);


    }
}
