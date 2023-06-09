using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BrainerHubDemoModel.POcSampleDB;

[Table("STUD_Student")]
[Index("StudClassScheduleId", Name = "IX_STUD_Student__STUD_ClassScheduleID")]
[Index("StudJobId", Name = "IX_STUD_Student__STUD_JobID")]
[Index("StudLocationId", Name = "IX_STUD_Student__STUD_LocationID")]
[Index("StudRecruiterId", Name = "IX_STUD_Student__STUD_RecruiterID")]
[Index("StudStatusId", Name = "IX_STUD_Student__STUD_StatusID")]
public partial class StudStudent
{
    [Key]
    [Column("STUD_StudentID")]
    public int StudStudentId { get; set; }

    [Column("STUD_ContactID")]
    public int StudContactId { get; set; }

    [Column("STUD_StatusID")]
    public int? StudStatusId { get; set; }

    [Column("STUD_StatusDate", TypeName = "datetime")]
    public DateTime? StudStatusDate { get; set; }

    [Column("STUD_StatusDays")]
    public int? StudStatusDays { get; set; }

    [Column("STUD_LocationID")]
    public int? StudLocationId { get; set; }

    [Column("xSTUD_ClassID")]
    public int? XStudClassId { get; set; }

    [Column("STUD_ClassScheduleID")]
    public int? StudClassScheduleId { get; set; }

    [Column("STUD_TeacherID")]
    public int? StudTeacherId { get; set; }

    [Column("STUD_RecruiterID")]
    public int? StudRecruiterId { get; set; }

    [Column("STUD_JobID")]
    public int? StudJobId { get; set; }

    [Column("STUD_SourceContactID")]
    public int? StudSourceContactId { get; set; }

    [Column("STUD_StudentClassificationID")]
    public int? StudStudentClassificationId { get; set; }

    [Required]
    [Column("STUD_Active")]
    public bool? StudActive { get; set; }

    [Required]
    [Column("STUD_Visible")]
    public bool? StudVisible { get; set; }

    [Column("STUD_CreateDate", TypeName = "datetime")]
    public DateTime StudCreateDate { get; set; }

    [Column("STUD_CreateUser")]
    [StringLength(200)]
    [Unicode(false)]
    public string StudCreateUser { get; set; } = null!;

    [Column("STUD_UpdateDate", TypeName = "datetime")]
    public DateTime StudUpdateDate { get; set; }

    [Column("STUD_UpdateUser")]
    [StringLength(200)]
    [Unicode(false)]
    public string StudUpdateUser { get; set; } = null!;

    [Column("STUD_ApplicationID")]
    public int? StudApplicationId { get; set; }

    [Column("STUD_ApplicationDate", TypeName = "datetime")]
    public DateTime? StudApplicationDate { get; set; }

    [ForeignKey("StudContactId")]
    [InverseProperty("StudStudents")]
    public virtual ContContact StudContact { get; set; } = null!;

    [ForeignKey("StudStatusId")]
    [InverseProperty("StudStudents")]
    public virtual StatStatus? StudStatus { get; set; }
}
