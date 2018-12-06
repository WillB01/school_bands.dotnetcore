using FavoriteBand.Models;
using FavoriteBand.Models.Scaffold;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoriteBand.Services
{
    public interface IAlbumRepository
    {
        Task AddAlbum(List<JsonAddAlbum> albumInfo);

        Task<IEnumerable<Albums>> GetAllAlbums();

        Task<ICollection<Albums>> GetAlbumByBandId(int bandId);

        Task DeleteAlbum(List<JsonDeleteAlbum> ids);


    }
}