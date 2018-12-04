namespace FavoriteBand.Models.Scaffold
{
    public partial class Albums
    {
        public Albums()
        {
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int BandId { get; set; }
        public string Year { get; set; }

        public Band Band
        { get; set; }
    }
}