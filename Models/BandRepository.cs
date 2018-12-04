using FavoriteBand.Models.Scaffold;
using FavoriteBand.Services;
using System.Collections.Generic;
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

        public Band GetBandById(int id)
        {
            var test = _dataContext.Band.Find(id).Albums;
            var res = _dataContext.Band.Find(id);
            return res;
        }
    }
}