namespace FOODBANK.Models
{
    public class FoodItem
    {
        public int FoodItemID { get; set; }
        public string Name { get; set; }
        public string? Category { get; set; }
        public string? Brand { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Unit { get; set; }
        public int? QuantityInStock { get; set; }
        public DateOnly? ExpirationDate { get; set; }
        public bool? IsPerishable { get; set; }
        public int? CaloriesPerServing { get; set; }
        public string? Ingredients { get; set; }
        public string? Barcode { get; set; }
        public string? Supplier { get; set; }
        public DateTime? DateAdded { get; set; }
        public bool? IsActive { get; set; }
        public int? RoleId { get; set; }
    }
}
