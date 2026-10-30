using System.ComponentModel.DataAnnotations;

namespace Day3.Models
{
    public class Category
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "thieu name")]
        [StringLength(100,MinimumLength = 2, ErrorMessage = "ten phai tu 2 den 100 k itu")]
        public string? Name { get; set; }
        public List<Product>? Products { get; set; } 
    }
}
