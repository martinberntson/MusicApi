using MusicApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MusicApi.Services
{
    internal static class ListingService
    {
        internal static List<Album> GetAlbumsByArtistId(int artistId)
        {
            return AllTheData.Albums
                .Where(x => x.ArtistId == artistId)
                .ToList();
        }
        internal static List<Song> GetSongsByAlbumId(int albumId)
        {
            return AllTheData.Songs
                .Where(x => x.AlbumId == albumId)
                .ToList();
        }
        internal static Album GetAlbumByAlbumId(int albumId)
        {
            return AllTheData.Albums
                .Where(x => x.Id == albumId)
                .First();
        }
        internal static Artist GetArtistByArtistId(int artistId)
        {
            return AllTheData.Artists
                .Where(x => x.Id == artistId)
                .First();
        }
    }
}
