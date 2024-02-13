using System.ComponentModel.DataAnnotations;

namespace Mission6_Diaz.Models
{
    public class Application
    {
        // primary key
        [Key]
        [Required]
        public int MovieId { get; set; }

        // if two categories, only require 1
        [Required]
        public string Category { get; set; }

        public string? SubCategory { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        // multiple directors, only require 1
        [Required]
        public string Director1 { get; set; }

        public string? Director2 { get; set; }

        public string? Director3 { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool? Edited { get; set; }

        public string? LentTo { get; set; }

        // limit to 25 characters
        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}

