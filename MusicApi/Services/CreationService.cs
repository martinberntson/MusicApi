using MusicApi.Models;
using System;
using System.Linq;

namespace MusicApi.Services
{
    internal static class CreationService
    {
        internal static string CreateArtist(string name)
        {
            AllTheData.Artists.Add(new() { 
                Name = name, 
                Id = AllTheData.CurrentIds.ArtistId
            });
            AllTheData.CurrentIds.ArtistId++;
            JsonService.SaveAllTheData();
            return $"Artist {name} with ID {AllTheData.CurrentIds.ArtistId-1} added.";
        }
        internal static string CreateAlbum(string name, int artistId)
        {
            if (AllTheData.Artists
                .Where(x => x.Id == artistId).ToList()
                .Count != 1)  // Could do this check in many different ways but this should work.
                return $"Artist with ID {artistId} does not exist";

            AllTheData.Albums.Add(new()
            {
                Name = name,
                ArtistId = artistId,
                Id = AllTheData.CurrentIds.AlbumId
            });
            AllTheData.CurrentIds.AlbumId++;
            JsonService.SaveAllTheData();
            return $"Album {name} with ID {AllTheData.CurrentIds.AlbumId-1} added.";
        }
        internal static string CreateSong(string name,int length, int albumId)
        {
            if (AllTheData.Albums
                .Where(x => x.Id == albumId).ToList()
                .Count != 1)
                return $"Album with ID {albumId} does not exist";

            AllTheData.Songs.Add(new() 
            {
                Name = name,
                Length = length,
                AlbumId = albumId,
                Id = AllTheData.CurrentIds.SongId
            });
            AllTheData.CurrentIds.SongId++;
            JsonService.SaveAllTheData();
            return $"Song {name} with ID {AllTheData.CurrentIds.SongId-1} added.";
        }
    }
}
