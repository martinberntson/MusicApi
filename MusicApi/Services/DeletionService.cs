using MusicApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MusicApi.Services
{
    internal static class DeletionService
    {
        internal static void DeleteArtist(int id)
        {
            List<int> albumIds = GetAlbumIdsByArtistId(id);
            List<int> songIds = GetSongIdsByAlbumIds(albumIds);
            DeleteSongsByIdList(songIds);
            DeleteAlbumsByIdList(albumIds);
            DeleteArtistById(id);
            JsonService.SaveAllTheData();
        }
        internal static void DeleteAlbum(int id)
        {
            List<int> songIds = GetSongIdsByAlbumId(id);
            DeleteSongsByIdList(songIds);
            DeleteAlbumById(id);
            JsonService.SaveAllTheData();
        }
        internal static void DeleteSong(int id)
        {
            DeleteSongById(id);
            JsonService.SaveAllTheData();
        }


        /*Deleters*/
        private static void DeleteArtistById(int id)
        {
            AllTheData.Artists.Remove(
                AllTheData.Artists.Where(x => x.Id == id).First()
                );
        }
        private static void DeleteAlbumById(int id)
        {
            AllTheData.Albums.Remove(
                AllTheData.Albums.Where(x => x.Id == id).First()
                );
        }
        private static void DeleteSongById(int id)
        {
            AllTheData.Songs.Remove(
                AllTheData.Songs.Where(x => x.Id == id).First()
                );
        }

        private static void DeleteAlbumsByIdList(List<int> albumIds)
        {
            foreach (int i in albumIds)
            {
                AllTheData.Albums.Remove(
                    AllTheData.Albums.Where(x => x.Id == i).First()
                    );
            }
        }

        private static void DeleteSongsByIdList(List<int> songIds)
        {
            foreach (int i in songIds)
            {
                AllTheData.Songs.Remove(
                    AllTheData.Songs.Where(x => x.Id == i).First()
                    );
            }
        }


        /*Listers*/
        private static List<int> GetSongIdsByAlbumId(int id)
        {
            List<int> songIds = new();
            foreach (Song song in AllTheData.Songs)
            {
                if (song.AlbumId == id) songIds.Add(song.Id);
            }
            return songIds;
        }
        private static List<int> GetSongIdsByAlbumIds(List<int> albumIds)
        {
            List<int> songIds = new();
            foreach (int albumId in albumIds)
            {
                foreach (Song song in AllTheData.Songs)
                {
                    if (albumId == song.AlbumId) songIds.Add(song.Id);
                }
            }
            return songIds;
        }

        private static List<int> GetAlbumIdsByArtistId(int id)
        {
            List<int> albumIds = new();
            foreach (Album album in AllTheData.Albums)
            {
                if (album.ArtistId == id) albumIds.Add(album.Id);
            }
            return albumIds;
        }
    }
}
