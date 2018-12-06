using FavoriteBand.Models.Scaffold;
using FavoriteBand.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavoriteBand.Models
{
    public class BandRepository : IBandRepository
    {
        private ScaffoldContext _dataContext;

        public BandRepository(ScaffoldContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Band>> GetAllBands() => await Task.FromResult(_dataContext.Band);

        public async Task AddBand(Band band)
        {
            _dataContext.Band.Add(band);
            var i = await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteBand(int id)
        {
            var bandToDelete = await _dataContext.Band.FindAsync(id);
            _dataContext.Albums.RemoveRange(bandToDelete.Albums);
            _dataContext.Band.RemoveRange(bandToDelete);
            await _dataContext.SaveChangesAsync();
        }

        public Band GetBandById(int id)
        {
            var test = _dataContext.Band.Find(id).Albums;
            var res = _dataContext.Band.Find(id);
            return res;
        }

        public async Task UppdateBand(Band band, string[] albumTitle, string[] albumYear, int[] albumIds)
        {
            var dbBand = GetBandById(band.Id);

            for (int i = 0; i < albumIds.Length; i++)
            {
                var album = dbBand.Albums.FirstOrDefault(p => p.Id == albumIds[i]);
                album.Title = albumTitle[i];
                album.Year = albumYear[i];
            }

            dbBand.Name = band.Name;
            dbBand.Description = band.Description;

            await _dataContext.SaveChangesAsync();
        }
    }
}