using FavoriteBand.Models;
using FavoriteBand.Models.Scaffold;
using FavoriteBand.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<IActionResult> AddAlbum(Albums albums)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Details), new { id = albums.BandId });
            }

            await _albumRepository.AddAlbum(albums);
            return RedirectToAction(nameof(Edit), new { id = albums.BandId });
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _bandRepository.DeleteBand(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit([FromRoute]int id)
        {
            var result = _bandRepository.GetBandById(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(
            [FromForm]Band band, string[] albumTitle, string[] albumYear, int[] albumIds, 
            string Deleteid)
        {
            if (band.Id != 0)
            {
                await _bandRepository.UppdateBand(band, albumTitle, albumYear, albumIds);

            }
            //await _albumRepository.AddAlbum(albums);
            //await _albumRepository.DeleteAlbum(ids);

            return RedirectToAction(nameof(Edit), new { id = band.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Korv( [FromBody] List<JsonPostStuff> ids)
        {
             await _albumRepository.DeleteAlbum(ids);
            return RedirectToAction(nameof(Index), new { id = int.Parse(ids[0].BandId)});
        }

        public IActionResult EditAlbums(Albums albums)
        {
            //var result = _albumRepository.GetAlbumByBandId(id).Result;
            return PartialView(albums);
        }

        //[HttpPost]
        //public async Task<IActionResult> DeleteAlbum(int id, int bandId)
        //{
        //    await _albumRepository.DeleteAlbum(id);
        //    return RedirectToAction(nameof(Edit), new { id = bandId });
        //}





    }
}