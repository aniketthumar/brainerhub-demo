using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BrainerHubDemoModel.POcSampleDB;

[Table("Product")]
public partial class Product
{
    [Key]
    public int ProductId { get; set; }

    [StringLength(100)]
    public string ProductName { get; set; } = null!;

    [StringLength(1000)]
    public string? ProductdDescription { get; set; }

    public byte Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }
}
