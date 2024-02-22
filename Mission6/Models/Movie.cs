using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Diaz.Models
{
    public class Movie
    {
        // primary key
        [Key]
        [Required]
        public int MovieId { get; set; }

        // category
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        // title
        [Required(ErrorMessage = "A title is required.")]
        public string Title { get; set; }

        // release year
        [Required(ErrorMessage = "The release year is required.")]
        // make min year 1888
        [Range(1888, int.MaxValue, ErrorMessage = "The year must be 1888 or later.")]
        public int Year { get; set; }

        // director
        public string? Director { get; set; }

        // rating
        public string? Rating { get; set; }

        // edited
        [Required(ErrorMessage = "Please enter if the entry was edited.")]
        public bool Edited { get; set; }

        // lent
        public string? LentTo { get; set; }

        // plex
        [Required(ErrorMessage = "Please enter if the move was uploaded to Plex.")]
        public bool CopiedToPlex { get; set; }

        // limit to 25 characters
        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}

