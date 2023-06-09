using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BrainerHubDemoModel.POcSampleDB;

/// <summary>
/// CONT_Contact_Student
/// </summary>
[Table("CONT_Contact")]
[Index("ContCreateDate", Name = "IX_CONT_Contact__CONT_CreateDate")]
[Index("ContEmail1", Name = "IX_CONT_Contact__CONT_Email1")]
[Index("ContFullName", Name = "IX_CONT_Contact__CONT_FullName")]
[Index("ContLocationId", Name = "IX_CONT_Contact__CONT_LocationID")]
[Index("ContPhone1", Name = "IX_CONT_Contact__CONT_Phone1")]
[Index("ContTypeId", Name = "IX_CONT_Contact__CONT_TypeID")]
public partial class ContContact
{
    [Key]
    [Column("CONT_ContactID")]
    public int ContContactId { get; set; }

    [Column("CONT_TypeID")]
    public int ContTypeId { get; set; }

    [Column("xCONT_StatusID")]
    public int? XContStatusId { get; set; }

    [Column("CONT_CompanyName")]
    [StringLength(60)]
    [Unicode(false)]
    public string? ContCompanyName { get; set; }

    [Column("CONT_CompanyNameShort")]
    [StringLength(20)]
    [Unicode(false)]
    public string? ContCompanyNameShort { get; set; }

    [Column("CONT_CompanyType")]
    [StringLength(20)]
    [Unicode(false)]
    public string? ContCompanyType { get; set; }

    [Column("CONT_TitlePrefix")]
    [StringLength(10)]
    [Unicode(false)]
    public string? ContTitlePrefix { get; set; }

    [Column("CONT_FirstName")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ContFirstName { get; set; }

    [Column("CONT_MiddleName")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ContMiddleName { get; set; }

    [Column("CONT_LastName")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ContLastName { get; set; }

    [Column("CONT_FullName")]
    [StringLength(112)]
    [Unicode(false)]
    public string ContFullName { get; set; } = null!;

    [Column("CONT_Position")]
    [StringLength(60)]
    [Unicode(false)]
    public string? ContPosition { get; set; }

    [Column("CONT_Address1")]
    [StringLength(60)]
    [Unicode(false)]
    public string? ContAddress1 { get; set; }

    [Column("CONT_Address2")]
    [StringLength(60)]
    [Unicode(false)]
    public string? ContAddress2 { get; set; }

    [Column("CONT_City")]
    [StringLength(35)]
    [Unicode(false)]
    public string? ContCity { get; set; }

    [Column("CONT_State")]
    [StringLength(10)]
    [Unicode(false)]
    public string? ContState { get; set; }

    [Column("CONT_Zip")]
    [StringLength(10)]
    [Unicode(false)]
    public string? ContZip { get; set; }

    [Column("CONT_County")]
    [StringLength(60)]
    [Unicode(false)]
    public string? ContCounty { get; set; }

    [Column("CONT_Country")]
    [StringLength(60)]
    [Unicode(false)]
    public string? ContCountry { get; set; }

    [Column("CONT_Phone1")]
    [StringLength(20)]
    [Unicode(false)]
    public string? ContPhone1 { get; set; }

    [Column("CONT_Phone2")]
    [StringLength(20)]
    [Unicode(false)]
    public string? ContPhone2 { get; set; }

    [Column("CONT_Email1")]
    [StringLength(200)]
    [Unicode(false)]
    public string? ContEmail1 { get; set; }

    [Column("CONT_Email2")]
    [StringLength(200)]
    [Unicode(false)]
    public string? ContEmail2 { get; set; }

    [Column("CONT_Web")]
    [StringLength(500)]
    [Unicode(false)]
    public string? ContWeb { get; set; }

    [Column("CONT_ContactMethod")]
    [StringLength(100)]
    [Unicode(false)]
    public string? ContContactMethod { get; set; }

    [Column("CONT_LocationID")]
    public int? ContLocationId { get; set; }

    [Column("CONT_UserID")]
    public int? ContUserId { get; set; }

    [Column("xCONT_RoleID")]
    public int? XContRoleId { get; set; }

    [Column("CONT_Login")]
    [StringLength(200)]
    [Unicode(false)]
    public string? ContLogin { get; set; }

    [Column("CONT_Password")]
    [StringLength(200)]
    [Unicode(false)]
    public string? ContPassword { get; set; }

    [Column("CONT_DOB", TypeName = "datetime")]
    public DateTime? ContDob { get; set; }

    [Column("CONT_Note")]
    [Unicode(false)]
    public string? ContNote { get; set; }

    [Column("CONT_Active")]
    public bool? ContActive { get; set; }

    [Column("CONT_Visible")]
    public bool? ContVisible { get; set; }

    [Column("CONT_CreateDate", TypeName = "datetime")]
    public DateTime ContCreateDate { get; set; }

    [Column("CONT_CreateUser")]
    [StringLength(200)]
    [Unicode(false)]
    public string ContCreateUser { get; set; } = null!;

    [Column("CONT_UpdateDate", TypeName = "datetime")]
    public DateTime ContUpdateDate { get; set; }

    [Column("CONT_UpdateUser")]
    [StringLength(200)]
    [Unicode(false)]
    public string ContUpdateUser { get; set; } = null!;

    [Column("xCONT_ObjectCode")]
    [StringLength(50)]
    [Unicode(false)]
    public string? XContObjectCode { get; set; }

    [Column("xCONT_StudentClassificationID")]
    public int? XContStudentClassificationId { get; set; }

    [Column("xCONT_JobID")]
    public int? XContJobId { get; set; }

    [Column("xCONT_ClassID")]
    public int? XContClassId { get; set; }

    [Column("xCONT_ClassScheduleID")]
    public int? XContClassScheduleId { get; set; }

    [Column("xCONT_RecruiterID")]
    public int? XContRecruiterId { get; set; }

    [Column("xCONT_TeacherID")]
    public int? XContTeacherId { get; set; }

    [Column("xCONT_StudentID")]
    public int? XContStudentId { get; set; }

    [Column("xCONT_SourceContactID")]
    public int? XContSourceContactId { get; set; }

    [Column("xCONT_ApplicationID")]
    public int? XContApplicationId { get; set; }

    [Column("xCONT_SurveyID")]
    public int? XContSurveyId { get; set; }

    [ForeignKey("ContTypeId")]
    [InverseProperty("ContContacts")]
    public virtual ConttContactType ContType { get; set; } = null!;

    [InverseProperty("StudContact")]
    public virtual ICollection<StudStudent> StudStudents { get; } = new List<StudStudent>();
}
