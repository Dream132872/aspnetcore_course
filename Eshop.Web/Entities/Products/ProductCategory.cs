using System.ComponentModel.DataAnnotations;

namespace Eshop.Web.Entities.Products;

public class ProductCategory
{
    [Key] public int Id { get; set; }

    [Required] [MaxLength(200)] public string Title { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public ICollection<ProductSelectedCategory> ProductSelectedCategories { get; set; }
}