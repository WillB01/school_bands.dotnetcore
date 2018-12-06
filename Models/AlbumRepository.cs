using FavoriteBand.Models.Scaffold;
using FavoriteBand.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task AddAlbum(Albums album)
        {   
            album.Id = 0;
            
            _dataContext.Albums.Add(album);
            var i = await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAlbum(List<JsonPostStuff> ids)
        {
            for (int i = 0; i < ids.ToArray().Length; i++)
            {

                var album = _dataContext.Albums.FirstOrDefault(p => p.Id == int.Parse(ids[i].AlbumId));
                _dataContext.Albums.Remove(album);
            }

            await _dataContext.SaveChangesAsync();




            //var dbBand = GetBandById(band.Id);

            //for (int i = 0; i < albumIds.Length; i++)
            //{
            //    var album = dbBand.Albums.FirstOrDefault(p => p.Id == albumIds[i]);
            //    album.Title = albumTitle[i];
            //    album.Year = albumYear[i];
            //}

            //dbBand.Name = band.Name;
            //dbBand.Description = band.Description;

            //await _dataContext.SaveChangesAsync();
        }

        public async Task<ICollection<Albums>> GetAlbumByBandId(int bandId)
        {
            var band = await  _dataContext.Band.FindAsync(bandId);
            var albums = band.Albums;
            return albums;
        }

        public Task<IEnumerable<Albums>> GetAllAlbums()
        {
            throw new NotImplementedException();
        }
    }
}