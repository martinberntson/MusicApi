using Microsoft.AspNetCore.Mvc;
using MusicApi.Models;
using MusicApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApi.Controllers
{
    public class SongController : Controller
    {
        [Route("Song/")]
        public IActionResult Index()
        {
            return View(AllTheData.Songs);
        }
        [Route("Song/{id:int}")]
        public IActionResult Index(int id)
        {
            return View(
                AllTheData.Songs
                .Where(x => x.Id == id)
                .ToList()
                );
        }

        [Route("Song/Update")]
        public IActionResult Update(int id, string name, int length)
        {
            string message = "You can update a Song's name here.";
            if (!String.IsNullOrEmpty(name))
            {
                UpdateService.UpdateSong(id, name, length);
                message = $"Song with ID:{id} updated to {name} with length {length}";
            }
            return View(message as object);
        }

        [Route("Song/Delete")]
        public IActionResult Delete()
        {
            return View(AllTheData.Songs);
        }

        [Route("Song/Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            DeletionService.DeleteSong(id);
            return View(AllTheData.Songs);
        }


        [Route("Song/Create")]
        public IActionResult Create(string name, int length, int albumId)
        {
            string message = "You can create a new Song here.";
            if (!String.IsNullOrEmpty(name)) message = CreationService.CreateSong(name, length, albumId);
            return View(message as object);
        }
        [Route("Artist/Create/{name}&{length}&{albumId}")]
        public IActionResult Create(string name, int length, int albumId, bool filler)
        {
            string message = CreationService.CreateSong(name, length, albumId);
            return View(message);
        }

        public static string GetAlbumNameById(int id)
        {
            return ListingService.GetAlbumByAlbumId(id).Name;
        }
        public static string GetArtistNameByAlbumId(int id)
        {
            return ListingService.GetArtistByArtistId(
                ListingService.GetAlbumByAlbumId(id)
                .ArtistId)
                .Name;
        }
    }
}
