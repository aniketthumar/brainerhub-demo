using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BrainerHubDemoModel.POcSampleDB;

[Table("STLOG_StatusLog")]
[Index("StlogObjectCode", Name = "IX_STLOG_StatusLog__STLOG_ObjectCode")]
[Index("StlogObjectId", Name = "IX_STLOG_StatusLog__STLOG_ObjectID")]
[Index("StlogStatusId", Name = "IX_STLOG_StatusLog__STLOG_StatusID")]
public partial class StlogStatusLog
{
    [Key]
    [Column("STLOG_StatusLogID")]
    public int StlogStatusLogId { get; set; }

    [Column("STLOG_ObjectCode")]
    [StringLength(50)]
    [Unicode(false)]
    public string StlogObjectCode { get; set; } = null!;

    [Column("STLOG_ObjectID")]
    public int StlogObjectId { get; set; }

    [Column("STLOG_StatusID")]
    public int StlogStatusId { get; set; }

    [Column("STLOG_StatusID_Previous")]
    public int? StlogStatusIdPrevious { get; set; }

    [Column("STLOG_StartDate", TypeName = "datetime")]
    public DateTime StlogStartDate { get; set; }

    [Column("STLOG_EndDate", TypeName = "datetime")]
    public DateTime? StlogEndDate { get; set; }

    [Column("STLOG_IsCurrent")]
    public bool? StlogIsCurrent { get; set; }

    [Column("STLOG_CreateDate", TypeName = "datetime")]
    public DateTime StlogCreateDate { get; set; }

    [Column("STLOG_CreateUser")]
    [StringLength(200)]
    [Unicode(false)]
    public string StlogCreateUser { get; set; } = null!;

    [Column("STLOG_UpdateDate", TypeName = "datetime")]
    public DateTime StlogUpdateDate { get; set; }

    [Column("STLOG_UpdateUser")]
    [StringLength(200)]
    [Unicode(false)]
    public string StlogUpdateUser { get; set; } = null!;

    [ForeignKey("StlogStatusId")]
    [InverseProperty("StlogStatusLogs")]
    public virtual StatStatus StlogStatus { get; set; } = null!;
}
