﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BrainerHubDemoModel.DbEntities;

[Table("ProductImage")]
public partial class ProductImage
{
    [Key]
    public int ProductImageId { get; set; }

    public int? ProductsId { get; set; }

    [StringLength(4000)]
    public string ImageUrl { get; set; }

    public int? StatusId { get; set; }

    [ForeignKey("ProductsId")]
    [InverseProperty("ProductImages")]
    public virtual Product Products { get; set; }
}
