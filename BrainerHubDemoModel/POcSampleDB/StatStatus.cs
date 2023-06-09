using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BrainerHubDemoModel.POcSampleDB;

[Table("STAT_Status")]
[Index("StatObjectCode", Name = "IX_STAT_Status__STAT_ObjectCode")]
[Index("StatParentStatusId", Name = "IX_STAT_Status__STAT_ParentStatusID")]
[Index("StatStatusCode", Name = "IX_STAT_Status__STAT_StatusCode")]
[Index("StatStatusName", Name = "IX_STAT_Status__STAT_StatusName")]
public partial class StatStatus
{
    [Key]
    [Column("STAT_StatusID")]
    public int StatStatusId { get; set; }

    [Column("STAT_ObjectCode")]
    [StringLength(50)]
    [Unicode(false)]
    public string StatObjectCode { get; set; } = null!;

    [Column("STAT_ParentStatusID")]
    public int? StatParentStatusId { get; set; }

    [Column("STAT_StatusCode")]
    [StringLength(50)]
    [Unicode(false)]
    public string StatStatusCode { get; set; } = null!;

    [Column("STAT_StatusName")]
    [StringLength(100)]
    [Unicode(false)]
    public string StatStatusName { get; set; } = null!;

    [Column("STAT_StatusNote")]
    [StringLength(200)]
    [Unicode(false)]
    public string? StatStatusNote { get; set; }

    [Column("STAT_IsDefault")]
    public bool StatIsDefault { get; set; }

    [Column("STAT_Sequence")]
    public int StatSequence { get; set; }

    [Required]
    [Column("STAT_Active")]
    public bool? StatActive { get; set; }

    [Column("STAT_Visible")]
    public bool StatVisible { get; set; }

    [Column("STAT_CreateDate", TypeName = "datetime")]
    public DateTime StatCreateDate { get; set; }

    [Column("STAT_CreateUser")]
    [StringLength(200)]
    [Unicode(false)]
    public string StatCreateUser { get; set; } = null!;

    [Column("STAT_UpdateDate", TypeName = "datetime")]
    public DateTime StatUpdateDate { get; set; }

    [Column("STAT_UpdateUser")]
    [StringLength(200)]
    [Unicode(false)]
    public string StatUpdateUser { get; set; } = null!;

    [Column("STAT_FilterTypeID")]
    public int? StatFilterTypeId { get; set; }

    [InverseProperty("StlogStatus")]
    public virtual ICollection<StlogStatusLog> StlogStatusLogs { get; } = new List<StlogStatusLog>();

    [InverseProperty("StudStatus")]
    public virtual ICollection<StudStudent> StudStudents { get; } = new List<StudStudent>();
}
