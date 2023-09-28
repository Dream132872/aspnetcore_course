using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Web.Entities.Products;

public class ProductGallery
{
    [Key]
    public int Id { get; set; }

    public int ProductId { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Image { get; set; }

    public Product Product { get; set; }
}