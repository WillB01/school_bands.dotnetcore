using FavoriteBand.Models.Scaffold;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoriteBand.Services
{
    public interface IBandRepository
    {
        Task<IEnumerable<Band>> GetAllBands();

        Band GetBandById(int id);

        Task AddBand(Band band);

        Task DeleteBand(int id);
        Task UppdateBand(Band band, string[] albumTitle, string[] albumYear, int[] albumIds);
    }
}