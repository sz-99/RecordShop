using System.ComponentModel.DataAnnotations;

namespace RecordShop.Model
{
    public class Album
    {
       
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Artist name cannot exceed 100 characters")]
        public string Artist { get; set; }
        [Required]
        [Range(1500, 2050, ErrorMessage = "Please enter valid year.")]
        public int ReleaseYear { get; set; }
        [Required]
        [Range(0,7, ErrorMessage = "Please enter between 0 to 7.")]
        public Genre Genre { get; set; }
    }
    public enum Genre
    {
        Pop,
        Rock,
        Country,
        RnB,
        HipHop,
        Jazz,
        Classic,
        Metal
    }
}
