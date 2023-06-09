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
    /// UpdateStudentRequestModel
    /// </summary>
    public class UpdateStudentRequestModel : StudentRequestModel
    {
        /// <summary>
        /// Identity of Student
        /// </summary>
        [JsonIgnore]
        public int StudentId { get; set; }

        /// <summary>
        /// The value that assign as Student Contact Id
        /// </summary>
        [JsonProperty("student_contact_id")]
        public int StudentContactId { get; set; }

    }

    /// <summary>
    /// UpdateStudentRequestModelValidator
    /// </summary>
    public class UpdateStudentRequestModelValidator : AbstractValidator<UpdateStudentRequestModel>
    {
        /// <summary>
        /// Intializing UpdateStudentRequestModelValidator
        /// </summary>
        public UpdateStudentRequestModelValidator()
        {
            this.RuleFor(m => m.StudentContactId).NotNull().OverridePropertyName("student_contact_id");
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
