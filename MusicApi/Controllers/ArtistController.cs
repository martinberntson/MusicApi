using Microsoft.AspNetCore.Mvc;
using MusicApi.Models;
using MusicApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApi.Controllers
{
    public class ArtistController : Controller
    {
        [Route("Artist/")]
        public IActionResult Index()
        {
            return View(AllTheData.Artists);
        }
        [Route("Artist/{id:int}")]
        public IActionResult Index(int id)
        {
            return View(
                AllTheData.Artists
                .Where(x => x.Id == id)
                .ToList()
                );
        }


        [Route("Artist/Update/")]
        public IActionResult Update(int id, string name)
        {
            string message = "You can update an Artist's name here.";
            if (!String.IsNullOrEmpty(name))
            {
                UpdateService.UpdateArtist(id, name);
                message = $"Artist with ID:{id} updated to {name}";
            }
            return View(message as object);
        }


        [Route("Artist/Delete/")]
        public IActionResult Delete()
        {
            return View(AllTheData.Artists);
        }

        [Route("Artist/Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            DeletionService.DeleteArtist(id);
            return View(AllTheData.Artists);
        }

        [Route("Artist/Create")]
        public IActionResult Create(string name)
        {
            string message = "You can add an Artist here.";
            if (!String.IsNullOrEmpty(name)) message = CreationService.CreateArtist(name);
            return View(message as object);
        }
        [Route("Artist/Create/{name}")]
        public IActionResult Create(string name, bool filler) // Needs another variable to differentiate this from the other Create()-method. Should be fine?
        {
            string message = CreationService.CreateArtist(name);
            return View(message as object);
        }
        public static int GetAlbumCountByArtistId(int id)
        {
            return CountingService.GetAlbumCountByArtistId(id);
        }
        public static List<Album> GetAlbumsByArtistId(int id)
        {
            return ListingService.GetAlbumsByArtistId(id);
        }
    }
}
