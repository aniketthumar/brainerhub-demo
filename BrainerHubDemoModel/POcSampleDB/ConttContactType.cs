using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BrainerHubDemoModel.POcSampleDB;

[Table("CONTT_ContactType")]
[Index("ConttTypeCode", Name = "IX_CONTT_Code", IsUnique = true)]
public partial class ConttContactType
{
    [Key]
    [Column("CONTT_TypeID")]
    public int ConttTypeId { get; set; }

    [Column("CONTT_TypeCode")]
    [StringLength(50)]
    [Unicode(false)]
    public string ConttTypeCode { get; set; } = null!;

    [Column("CONTT_TypeName")]
    [StringLength(100)]
    [Unicode(false)]
    public string? ConttTypeName { get; set; }

    [Column("CONTT_TypeNote")]
    [StringLength(200)]
    [Unicode(false)]
    public string? ConttTypeNote { get; set; }

    [Required]
    [Column("CONTT_Active")]
    public bool? ConttActive { get; set; }

    [Required]
    [Column("CONTT_Visible")]
    public bool? ConttVisible { get; set; }

    [Column("CONTT_CreateDate", TypeName = "datetime")]
    public DateTime? ConttCreateDate { get; set; }

    [Column("CONTT_CreateUser")]
    [StringLength(200)]
    [Unicode(false)]
    public string? ConttCreateUser { get; set; }

    [Column("CONTT_UpdateDate", TypeName = "datetime")]
    public DateTime? ConttUpdateDate { get; set; }

    [Column("CONTT_UpdateUser")]
    [StringLength(200)]
    [Unicode(false)]
    public string? ConttUpdateUser { get; set; }

    [Column("CONTT_ObjectCode")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ConttObjectCode { get; set; }

    [InverseProperty("ContType")]
    public virtual ICollection<ContContact> ContContacts { get; } = new List<ContContact>();
}
