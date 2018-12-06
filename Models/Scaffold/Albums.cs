using System.ComponentModel.DataAnnotations;

namespace FavoriteBand.Models.Scaffold
{
    public partial class Albums
    {
        public Albums()
        {
        }

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int BandId { get; set; }
        [Required]
        public string Year { get; set; }

        public Band Band
        { get; set; }
    }
}