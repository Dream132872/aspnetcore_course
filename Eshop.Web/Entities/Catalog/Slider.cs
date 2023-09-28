using System.ComponentModel.DataAnnotations;

namespace Eshop.Web.Entities.Catalog
{
    public class Slider
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(500)]
        public string Url { get; set; }

        [MaxLength(100)]
        public string Image { get; set; }
    }
}
