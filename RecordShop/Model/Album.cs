using System.ComponentModel.DataAnnotations;

namespace RecordShop.Model
{
    public class Album
    {
       
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Artist { get; set; }
        public int ReleaseYear { get; set; }
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
