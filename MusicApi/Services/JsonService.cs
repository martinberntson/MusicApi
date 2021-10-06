using MusicApi.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace MusicApi.Services
{
    internal static class JsonService
    {
        internal static void LoadAllTheData()
        {
            AllTheData.Artists = GetArtists();
            AllTheData.Albums = GetAlbums();
            AllTheData.Songs = GetSongs();
            AllTheData.CurrentIds = GetIdData();
        }

        internal static void SaveAllTheData()
        {
            SaveArtistData();
            SaveAlbumData();
            SaveSongData();
            SaveCurrentIdsData();
        }

        /*Load*/
        private static List<Artist> GetArtists()
        {
            using Stream stream = File.Open(@"C:\plushogskolan\Webbutveckling Backend\Inlämningsuppgift\MusicApi\MusicApi\wwwroot\Data\Artists.json", FileMode.Open);
            using StreamReader reader = new(stream);
            string jsonText = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<List<Artist>>(jsonText);

        }
        private static List<Album> GetAlbums()
        {
            using Stream stream = File.Open(@"C:\plushogskolan\Webbutveckling Backend\Inlämningsuppgift\MusicApi\MusicApi\wwwroot\Data\Albums.json", FileMode.Open);
            using StreamReader reader = new(stream);
            string jsonText = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<List<Album>>(jsonText);
        }
        private static List<Song> GetSongs()
        {
            using Stream stream = File.Open(@"C:\plushogskolan\Webbutveckling Backend\Inlämningsuppgift\MusicApi\MusicApi\wwwroot\Data\Songs.json", FileMode.Open);
            using StreamReader reader = new(stream);
            string jsonText = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<List<Song>>(jsonText);
        }
        private static CurrentIds GetIdData()
        {
            using Stream stream = File.Open(@"C:\plushogskolan\Webbutveckling Backend\Inlämningsuppgift\MusicApi\MusicApi\wwwroot\Data\CurrentIds.json", FileMode.Open);
            using StreamReader reader = new(stream);
            string jsonText = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<CurrentIds>(jsonText);
        }

        /*Save*/
        private static void SaveArtistData()
        {
            string artist = JsonConvert.SerializeObject(AllTheData.Artists);
            WriteToFile(artist, @"C:\plushogskolan\Webbutveckling Backend\Inlämningsuppgift\MusicApi\MusicApi\wwwroot\Data\Artists.json");
        }
        private static void SaveAlbumData()
        {
            string albums = JsonConvert.SerializeObject(AllTheData.Albums);
            WriteToFile(albums, @"C:\plushogskolan\Webbutveckling Backend\Inlämningsuppgift\MusicApi\MusicApi\wwwroot\Data\Albums.json");
        }
        private static void SaveSongData()
        {
            string songs = JsonConvert.SerializeObject(AllTheData.Songs);
            WriteToFile(songs, @"C:\plushogskolan\Webbutveckling Backend\Inlämningsuppgift\MusicApi\MusicApi\wwwroot\Data\Songs.json");
        }
        private static void SaveCurrentIdsData()
        {
            string currentIds = JsonConvert.SerializeObject(AllTheData.CurrentIds);
            WriteToFile(currentIds, @"C:\plushogskolan\Webbutveckling Backend\Inlämningsuppgift\MusicApi\MusicApi\wwwroot\Data\CurrentIds.json");
        }

        private static void WriteToFile(string fileText, string path)
        {
            using StreamWriter writer = new(File.Create(path));
            writer.Write(fileText);
        }
    }
}
