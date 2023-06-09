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
    /// UpdateTaskRequestModel
    /// </summary>
    public class UpdateTaskRequestModel
    {
        /// <summary>
        /// The value that assign as Done
        /// </summary>
        [JsonProperty("done")]
        public Boolean Done { get; set; }

        /// <summary>
        /// The string that assign as Current Cont Contact Id
        /// </summary>
        [JsonProperty("current_cont_contact_id")]
        public int CurrentContContactId { get; set; }

        /// <summary>
        /// The string that assign as Current User
        /// </summary>
        [JsonProperty("current_user")]
        public string? CurrentUser { get; set; }
    }

    /// <summary>
    /// UpdateTaskRequestModelValidator
    /// </summary>
    public class UpdateTaskRequestModelValidator : AbstractValidator<UpdateTaskRequestModel>
    {
        /// <summary>
        /// Intializing UpdateTaskRequestModelValidator
        /// </summary>
        public UpdateTaskRequestModelValidator()
        {

            this.RuleFor(m => m.Done).NotNull().OverridePropertyName("done");
            this.RuleFor(m => m.CurrentUser).MaximumLength(200).OverridePropertyName("current_user");

        }
    }
}
