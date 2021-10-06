using MusicApi.Models;
using System.Linq;

namespace MusicApi.Services
{
    internal static class UpdateService
    {
        internal static void UpdateArtist(int id, string name)
        {
            try
            {
                AllTheData.Artists
                .Where(x => x.Id == id).First()
                .Name = name;
                JsonService.SaveAllTheData();
            }
            catch { }
        }
        internal static void UpdateAlbum(int id, string name)
        {
            try
            {
                AllTheData.Albums
                    .Where(x => x.Id == id).First()
                    .Name = name;
                JsonService.SaveAllTheData();
            }
            catch { }
        }
        internal static void UpdateSong(int id, string name, int length)
        {
            try
            {
                UpdateSongLength(id, length);
                UpdateSongName(id, name);
                JsonService.SaveAllTheData();
            }
            catch { }
        }
        private static void UpdateSongName(int id, string name)
        {
            AllTheData.Songs
                .Where(x => x.Id == id).First()
                .Name = name;
        }
        private static void UpdateSongLength(int id, int length)
        {
            AllTheData.Songs
                .Where(x => x.Id == id).First()
                .Length = length;
        }
    }
}
