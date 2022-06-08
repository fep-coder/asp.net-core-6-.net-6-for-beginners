using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
        public class Product
        {
                public long Id { get; set; }
                [Required(ErrorMessage = "Please enter a value")]
                public string Name { get; set; }
                [Required]
                [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a value")]
                [Column(TypeName = "decimal(8, 2)")]
                public decimal Price { get; set; }

                [Required]
                [Range(1, long.MaxValue, ErrorMessage = "Please enter a value")]
                public long CategoryId { get; set; }
                public Category Category { get; set; }
        }
}
