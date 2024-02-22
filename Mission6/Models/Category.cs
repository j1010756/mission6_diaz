using System.ComponentModel.DataAnnotations;

namespace Mission6_Diaz.Models
{
    // make category class
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
