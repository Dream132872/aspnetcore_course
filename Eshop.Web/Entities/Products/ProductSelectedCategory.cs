using System.ComponentModel.DataAnnotations;

namespace Eshop.Web.Entities.Products;

public class ProductSelectedCategory
{
    [Key]
    public int Id { get; set; }

    public int ProductId { get; set; }
    public int ProductCategoryId { get; set; }

    public Product Product { get; set; }
    public ProductCategory ProductCategory { get; set; }
}