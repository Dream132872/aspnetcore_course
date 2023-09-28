using System.ComponentModel.DataAnnotations;

namespace Eshop.Web.Entities.Products;

public class Product
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }
    
    [Required]
    public int Price { get; set; }
    
    public int? OldPrice { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string ShortDescription { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Image { get; set; }
    
    [MaxLength(1000)]
    public string? Tags { get; set; }
    public bool IsActive { get; set; }

    public ICollection<ProductGallery> ProductGalleries { get; set; }
    public ICollection<ProductSelectedCategory> ProductSelectedCategories { get; set; }
}