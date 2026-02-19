using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FOODBANK.Models;

[Index("Barcode", Name = "UQ__FoodItem__177800D3100BFBB7", IsUnique = true)]
public partial class FoodItem
{
    [Key]
    [Column("FoodItemID")]
    public int FoodItemId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    public string? Category { get; set; }

    [StringLength(50)]
    public string? Brand { get; set; }

    [StringLength(255)]
    public string? Description { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    [StringLength(20)]
    public string? Unit { get; set; }

    public int? QuantityInStock { get; set; }

    public DateOnly? ExpirationDate { get; set; }

    public bool? IsPerishable { get; set; }

    public int? CaloriesPerServing { get; set; }

    [StringLength(500)]
    public string? Ingredients { get; set; }

    [StringLength(50)]
    public string? Barcode { get; set; }

    [StringLength(100)]
    public string? Supplier { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateAdded { get; set; }

    public bool? IsActive { get; set; }

    public int? RoleId { get; set; }

    [ForeignKey("RoleId")]
    [InverseProperty("FoodItems")]
    public virtual Role? Role { get; set; }
}
