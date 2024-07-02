using DomainModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public GenreEnum Genre { get; set; }
        [Required]
        public LanguageEnum Language { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        [Required, DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ReleaseDate { get; set; }
        [Required, RegularExpression(@"^([0-1][0-9]|2[0-3]):([0-5][0-9]):([0-5][0-9])$", ErrorMessage = "Invalid Time. Time must be in the format HH:mm:ss")]
        public TimeSpan Length { get; set; }
        [Required]
        public int AgeRestriction { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
