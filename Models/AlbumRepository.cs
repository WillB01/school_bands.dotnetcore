using FavoriteBand.Models.Scaffold;
using FavoriteBand.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoriteBand.Models
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly ScaffoldContext _dataContext;

        public AlbumRepository(ScaffoldContext scaffoldContext)
        {
            _dataContext = scaffoldContext;
        }

        public async Task AddAlbum(string title, string year, int bandId)
        {
            var a = new Albums
            {
                Title = title,
                Year = year,
                BandId = bandId,
            };

            _dataContext.Albums.Add(a);
            var i = await _dataContext.SaveChangesAsync();
        }

        public Task<IEnumerable<Band>> GetAllBands()
        {
            throw new NotImplementedException();
        }
    }
}