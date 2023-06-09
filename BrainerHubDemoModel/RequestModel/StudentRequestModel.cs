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
    /// StudentRequestModel
    /// </summary>
    public class StudentRequestModel
    {
        /// <summary>
        /// The string that assign as Contact First Name
        /// </summary>
        [JsonProperty("contact_first_name")]
        public string ContactFirstName { get; set; }

        /// <summary>
        /// The string that assign as Contact Last Name
        /// </summary>
        [JsonProperty("contact_last_name")]
        public string ContactLastName { get; set; }

        /// <summary>
        /// The string that assign as Contact Email
        /// </summary>
        [JsonProperty("contact_email")]
        public string ContactEmail { get; set; }

        /// <summary>
        /// The string that assign as Contact Phone
        /// </summary>
        [JsonProperty("contact_phone")]
        public string ContactPhone { get; set; }

        /// <summary>
        /// The value that assign as Contact Location Id
        /// </summary>
        [JsonProperty("contact_location_id")]
        public int ContactLocationId { get; set; }

        /// <summary>
        /// The value that assign as Contact Method Id
        /// </summary>
        [JsonProperty("contact_method_id")]
        public int ContactMethodId { get; set; }

        /// <summary>
        /// The string that assign as Contact Method Name
        /// </summary>
        [JsonProperty("contact_method_name")]
        public string ContactMethodName { get; set; }

        /// <summary>
        /// The string that assign as Contact Method Note
        /// </summary>
        [JsonProperty("contact_method_note")]
        public string ContactMethodNote { get; set; }

        /// <summary>
        /// The value that assign as Student Status Id
        /// </summary>
        [JsonProperty("student_status_id")]
        public int StudentStatusId { get; set; }

        /// <summary>
        /// The string that assign as Student Status Code
        /// </summary>
        [JsonProperty("student_status_code")]
        public string StudentStatusCode { get; set; }

        /// <summary>
        /// The value that assign as Student Class Schedule Id
        /// </summary>
        [JsonProperty("student_class_schedule_id")]
        public int StudentClassScheduleId { get; set; }

        /// <summary>
        /// The value that assign as Student Source Contact Id
        /// </summary>
        [JsonProperty("student_source_contact_id")]
        public int StudentSourceContactId { get; set; }

        /// <summary>
        /// The value that assign as Student Teacher Id
        /// </summary>
        [JsonProperty("student_teacher_id")]
        public int StudentTeacherId { get; set; }

        /// <summary>
        /// The value that assign as Student Recruiter Id
        /// </summary>
        [JsonProperty("student_recruiter_id")]
        public int StudentRecruiterId { get; set; }

        /// <summary>
        /// The value that assign as Student Job Id
        /// </summary>
        [JsonProperty("student_job_id")]
        public int StudentJobId { get; set; }

        /// <summary>
        /// The value that assign as Student Contact Method Id
        /// </summary>
        [JsonProperty("student_contact_method_id")]
        public int StudentContactMethodId { get; set; }

        /// <summary>
        /// The string that assign as Student Contact Method
        /// </summary>
        [JsonProperty("student_contact_method")]
        public string StudentContactMethod { get; set; }

        /// <summary>
        /// The string that assign as Student Contact Method Note
        /// </summary>
        [JsonProperty("student_contact_method_note")]
        public string StudentContactMethodNote { get; set; }

        /// <summary>
        /// The string that assign as Student Classification ID
        /// </summary>
        [JsonProperty("student_classification_id")]
        public int StudentClassificationID { get; set; }

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
    /// StudentRequestModelValidator
    /// </summary>
    public class StudentRequestModelValidator : AbstractValidator<StudentRequestModel>
    {
        /// <summary>
        /// Intializing StudentRequestModelValidator
        /// </summary>
        public StudentRequestModelValidator()
        {

            this.RuleFor(m => m.ContactFirstName).NotEmpty().NotNull().MaximumLength(50).OverridePropertyName("contact_first_name");
            this.RuleFor(m => m.ContactLastName).NotEmpty().NotNull().MaximumLength(50).OverridePropertyName("contact_last_name");
            this.RuleFor(m => m.ContactEmail).NotEmpty().NotNull().EmailAddress().MaximumLength(200).OverridePropertyName("contact_email");
            this.RuleFor(m => m.ContactPhone).NotEmpty().NotNull().MaximumLength(20).OverridePropertyName("contact_phone");
            this.RuleFor(m => m.ContactLocationId).NotNull().OverridePropertyName("contact_location_id");
            this.RuleFor(m => m.ContactMethodId).NotNull().OverridePropertyName("contact_method_id");
            this.RuleFor(m => m.ContactMethodName).NotEmpty().NotNull().MaximumLength(100).OverridePropertyName("contact_method_name");
            this.RuleFor(m => m.ContactMethodNote).NotEmpty().NotNull().MaximumLength(100).OverridePropertyName("contact_method_note");
            this.RuleFor(m => m.StudentStatusId).NotNull().OverridePropertyName("student_status_id");
            this.RuleFor(m => m.StudentStatusCode).NotEmpty().NotNull().MaximumLength(50).OverridePropertyName("student_status_code");
            this.RuleFor(m => m.StudentClassScheduleId).NotNull().OverridePropertyName("student_class_schedule_id");
            this.RuleFor(m => m.StudentSourceContactId).NotNull().OverridePropertyName("student_source_contact_id");
            this.RuleFor(m => m.StudentTeacherId).NotNull().OverridePropertyName("student_teacher_id");
            this.RuleFor(m => m.StudentRecruiterId).NotNull().OverridePropertyName("student_recruiter_id");
            this.RuleFor(m => m.StudentJobId).NotNull().OverridePropertyName("student_job_id");
            this.RuleFor(m => m.StudentContactMethodId).NotNull().OverridePropertyName("stu_contact_method_id");
            this.RuleFor(m => m.StudentContactMethod).NotEmpty().NotNull().MaximumLength(100).OverridePropertyName("student_contact_method");
            this.RuleFor(m => m.StudentContactMethodNote).NotEmpty().NotNull().MaximumLength(100).OverridePropertyName("student_contact_method_note");
            this.RuleFor(m => m.StudentClassificationID).NotNull().OverridePropertyName("student_classification_id");
            this.RuleFor(m => m.CurrentContContactID).NotNull().OverridePropertyName("current_cont_contact_id");
            this.RuleFor(m => m.CurrentUser).NotEmpty().NotNull().MaximumLength(200).OverridePropertyName("current_user");

        }
    }
}
