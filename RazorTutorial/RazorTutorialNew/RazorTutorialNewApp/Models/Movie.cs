using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorTutorialNewApp.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; } = string.Empty;

        //This allows EF Core to correctly map Price
        //to currency in the database
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
