using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FavoriteBand.Models.Scaffold
{
    public partial class Band
    {
        private ILazyLoader _LazyLoader;
        private ICollection<Albums> _albums;

        public Band()
        {

        }

        public Band(ILazyLoader lazyLoader)
        {
            _LazyLoader = lazyLoader;
            Albums = new HashSet<Albums>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<Albums> Albums
        { get => _LazyLoader.Load(this, ref _albums);
          set => _albums = value;
        }
    }
}
