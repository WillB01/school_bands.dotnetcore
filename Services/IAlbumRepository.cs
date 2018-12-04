using FavoriteBand.Models.Scaffold;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavoriteBand.Services
{
    public interface IAlbumRepository
    {
        Task AddAlbum(string title, string year, int bandId);

        Task<IEnumerable<Band>> GetAllBands();


    }
}
