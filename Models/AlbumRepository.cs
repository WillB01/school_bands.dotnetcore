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

                var album = GetAlbumByBandId(int.Parse(ids[i].id));
                var albumToDelete = await _dataContext.Albums.FindAsync(album);
                 _dataContext.Albums.Remove(albumToDelete);
            }
            
              
           
           
            
           
            await _dataContext.SaveChangesAsync();
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