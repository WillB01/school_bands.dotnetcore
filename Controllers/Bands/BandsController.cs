using FavoriteBand.Models.Scaffold;
using FavoriteBand.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FavoriteBand.Controllers.Bands
{
    public class BandsController : Controller
    {
        private readonly IBandRepository _bandRepository;
        private readonly IAlbumRepository _albumRepository;

        public BandsController(
            IBandRepository bandRepository, IAlbumRepository albumRepository)
        {
            _bandRepository = bandRepository;
            _albumRepository = albumRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await Task.FromResult(_bandRepository.GetAllBands()).Result;
            return View(result);
        }

        [HttpGet]
        public IActionResult Details([FromRoute] int id)
        {
            var result = _bandRepository.GetBandById(id);
            return View(result);
        }

        [HttpGet]
        public IActionResult AddBand() => View();

        [HttpPost]
        public async Task<IActionResult> AddBand([FromForm]Band band)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _bandRepository.AddBand(band);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> AddAlbum(string title, string year, int bandId)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(year))
            {
                return RedirectToAction(nameof(Details), new { id = bandId });
            }
            await _albumRepository.AddAlbum(title, year, bandId);
            return RedirectToAction(nameof(Details), new { id = bandId });
        }
    }
}