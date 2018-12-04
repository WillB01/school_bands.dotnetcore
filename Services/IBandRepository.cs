using FavoriteBand.Models.Scaffold;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavoriteBand.Services
{
    public interface IBandRepository
    {
        Task<IEnumerable<Band>> GetAllBands();

        Band GetBandById(int id);
  
        Task AddBand(Band band);


    }
}
