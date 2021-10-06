using Microsoft.AspNetCore.Mvc;
using MusicApi.Models;
using MusicApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApi.Controllers
{
    public class AlbumController : Controller
    {
        [Route("Album/")]
        public IActionResult Index()
        {
            return View(AllTheData.Albums);
        }
        [Route("Album/{id:int}")]
        public IActionResult Index(int id)
        {
            return View(
                AllTheData.Albums
                .Where(x => x.Id == id)
                .ToList()
                );
        }

        [Route("Album/Update")]
        public IActionResult Update(int id, string name)
        {
            string message = "You can update an Album's name here.";
            if (!String.IsNullOrEmpty(name))
            {
                UpdateService.UpdateAlbum(id, name);
                message = $"Album with ID:{id} updated to {name}";
            }
            return View(message as object);
        }

        [Route("Album/Delete")]
        public IActionResult Delete()
        {
            return View(AllTheData.Albums);
        }

        [Route("Album/Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            DeletionService.DeleteAlbum(id);
            return View(AllTheData.Albums);
        }


        [Route("Album/Create")]
        public IActionResult Create(string name, int artistId)
        {
            string message = "You can create a new Album here.";
            if (!String.IsNullOrEmpty(name)) message = CreationService.CreateAlbum(name, artistId);
            return View(message as object);
        }
        [Route("Artist/Create/{name}&{artistId}")]
        public IActionResult Create(string name, int artistId, bool filler) // Needs another variable to differentiate this from the other Create()-method. Should be fine?
        {
            string message = CreationService.CreateAlbum(name, artistId);
            return View(message as object);
        }

        public static string GetArtistNameById(int id)                  // So apparently cshtml files do not count as part of the assembly for the purposes of using internal methods.
        {
            return ListingService.GetArtistByArtistId(id).Name;
        }
        public static int GetSongCountByAlbumId(int id)
        {
            return CountingService.GetSongCountByAlbumId(id);
        }
        public static List<Song> GetSongsByAlbumId(int id)
        {
            return ListingService.GetSongsByAlbumId(id);
        }
    }
}
