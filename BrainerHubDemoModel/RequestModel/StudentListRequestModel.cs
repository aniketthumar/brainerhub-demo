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
    /// StudentListRequestModel
    /// </summary>
    public class StudentListRequestModel
    {
        /// <summary>
        /// The value that assign as Student Id
        /// </summary>
        [JsonProperty("student_id")]
        public int StudentID { get; set; }

        /// <summary>
        /// The value that assign as Student Contact Id
        /// </summary>
        [JsonProperty("student_contact_id")]
        public int StudentContactId { get; set; }

        /// <summary>
        /// The value that assign as Student Status Id
        /// </summary>
        [JsonProperty("student_status_id")]
        public int StudentStatusId { get; set; }

        /// <summary>
        /// The string that assign as Student Status Name
        /// </summary>
        [JsonProperty("student_status_name")]
        public string StudentStatusName { get; set; }

        /// <summary>
        /// The string that assign as Current Cont Contact ID
        /// </summary>
        [JsonProperty("current_cont_contact_id")]
        public int CurrentContContactID { get; set; }

        /// <summary>
        /// The string that assign as Current User
        /// </summary>
        [JsonProperty("current_user")]
        public string CurrentUser { get; set; }
    }


    /// <summary>
    /// StudentListRequestModelValidator
    /// </summary>
    public class StudentListRequestModelValidator : AbstractValidator<StudentListRequestModel>
    {
        /// <summary>
        /// Intializing StudentListRequestModelValidator
        /// </summary>
        public StudentListRequestModelValidator()
        {

            this.RuleFor(m => m.StudentID).NotNull().OverridePropertyName("student_id");
            this.RuleFor(m => m.StudentContactId).NotEmpty().OverridePropertyName("student_contact_id");
            this.RuleFor(m => m.StudentStatusId).NotEmpty().OverridePropertyName("student_status_id");
            this.RuleFor(m => m.StudentStatusName).NotEmpty().NotNull().MaximumLength(200).OverridePropertyName("student_status_name");
            this.RuleFor(m => m.CurrentContContactID).NotNull().OverridePropertyName("current_cont_contact_id");
            this.RuleFor(m => m.CurrentUser).NotNull().NotEmpty().MaximumLength(200).OverridePropertyName("current_user");

        }
    }
}
