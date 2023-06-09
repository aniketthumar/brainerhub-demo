using BrainerHubDemoModel.Helper;
using BrainerHubDemoModel.RequestModel;
using BrainerHubDemoService.BrainerHubDemoRepository.Interface;
using Microsoft.AspNetCore.Http;
using BrainerHubDemoModel.DbEntities;
using System.Web.Helpers;
using Microsoft.EntityFrameworkCore;
using BrainerHubDemoModel.ResponseModel;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static BrainerHubDemoModel.CustomModels.Constant;

namespace BrainerHubDemoService.BrainerHubDemoRepository.Implementation
{
    /// <summary>
    /// AuthenticationRepository
    /// </summary>
    public class AuthenticationRepository : IAuthenticationRepository
    {
        #region Initialization
        // Initialize the database context class.
        BrainerHubContex _brainerHubContex;

        public AuthenticationRepository(BrainerHubContex brainerHubContex)
        {
            _brainerHubContex = brainerHubContex;
        }
        #endregion

        #region Register User
        public async Task RegisterUser(UserRegisterationRequestModel model)
        {

            #region Validate
            var checkuser = await _brainerHubContex.Users.SingleOrDefaultAsync(t => t.EmailId.ToLower() == model.Email.ToLower());
            if (checkuser != null)
            {
                throw new HttpStatusCodeException(StatusCodes.Status400BadRequest, $"User with email id '{model.Email}' already Exists");
            }
            #endregion

            #region Add User
            User user = new User();
            user.EmailId = model.Email;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Password = Crypto.HashPassword(model.Password);

            await _brainerHubContex.Users.AddAsync(user);
            await _brainerHubContex.SaveChangesAsync();
            #endregion


        }
        #endregion

        #region Login
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginRequestModel"></param>
        /// <returns></returns>
        public async Task<LoginResponseModel> Login(LoginRequestModel loginRequestModel)
        {
            var user = await _brainerHubContex.Users.SingleOrDefaultAsync(x=>x.EmailId.ToLower() == loginRequestModel.EmailAddress.ToLower());
            if (user == null)
            {
                throw new HttpStatusCodeException(StatusCodes.Status401Unauthorized, "User Not Found");
            }
            if (!Crypto.VerifyHashedPassword(user.Password, loginRequestModel.Password))
            {
                throw new HttpStatusCodeException(StatusCodes.Status401Unauthorized, "Invalid Username or Password");
            }
            return await BindWithAccessToken(loginRequestModel, user);
        }
        #endregion

        #region Helper
        private async Task<LoginResponseModel> BindWithAccessToken(LoginRequestModel loginRequestModel, User user)
        {
            var loginResponseModel = new LoginResponseModel
            {
                EmailAddress = user.EmailId,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            ClaimsIdentity identity = GetClaimsIdentity(user);
            loginResponseModel.AccessToken = GetJwtToken(identity);
            loginResponseModel.Expires_in = (int)TimeSpan.FromMinutes(50).TotalSeconds;
          
            return loginResponseModel;
        }

        private ClaimsIdentity GetClaimsIdentity(User user, bool issuperadmin = false)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.EmailId),
                new Claim(JWTClaimParameters.UserId, user.UserId.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Token");
            return claimsIdentity;
        }

        private string GetJwtToken(ClaimsIdentity identity)
        {
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: JWTTokenCredentials.ValidIssuer,
                audience: JWTTokenCredentials.ValidAudience,
                notBefore: DateTime.UtcNow,
                claims: identity.Claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(50)),
                signingCredentials: new SigningCredentials(JWTTokenCredentials.GetSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        #endregion

    }
}
