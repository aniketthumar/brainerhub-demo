using BrainerHubDemoModel.RequestModel;
using BrainerHubDemoModel.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainerHubDemoService.BrainerHubDemoRepository.Interface
{
    public interface IAuthenticationRepository
    {
        Task RegisterUser(UserRegisterationRequestModel model);

        Task<LoginResponseModel> Login(LoginRequestModel loginRequestModel);
    }
}
