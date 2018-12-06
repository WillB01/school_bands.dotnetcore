using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavoriteBand.Models
{
    public class JsonMainModel
    {
        // bad names it has to batch the incoming JS name

        public List<JsonDeleteAlbum> albumIdsAndBandIds { get; set; }  //Delete albums
        public List<JsonAddAlbum> newAlbum { get; set; } // new Album
    }
}
