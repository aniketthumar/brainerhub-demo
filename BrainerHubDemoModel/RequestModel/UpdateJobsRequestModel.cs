using FluentValidation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainerHubDemoModel.RequestModel
{
    /// <summary>
    /// UpdateJobsRequestModel
    /// </summary>
    public class UpdateJobsRequestModel
    {

        /// <summary>
        /// The value that assign as Status Id
        /// </summary>
        [JsonProperty("status_id")]
        public int StatusId { get; set; }

        /// <summary>
        /// The string that assign as Status Code
        /// </summary>
        [JsonProperty("status_code")]
        public string? StatusCode { get; set; }

        /// <summary>
        /// The string that assign as Current Contact Id
        /// </summary>
        [JsonProperty("current_contact_id")]
        public int? CurrentContactId { get; set; }

        /// <summary>
        /// The string that assign as Current User
        /// </summary>
        [JsonProperty("current_user")]
        public string? CurrentUser { get; set; }

    }

    /// <summary>
    /// UpdateJobsRequestModelValidator
    /// </summary>
    public class UpdateJobsRequestModelValidator : AbstractValidator<UpdateJobsRequestModel>
    {
        /// <summary>
        /// Intializing UpdateJobsRequestModelValidator
        /// </summary>
        public UpdateJobsRequestModelValidator()
        {

            this.RuleFor(m => m.StatusId).NotNull().OverridePropertyName("status_id");

        }
    }
}
