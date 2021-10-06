using MusicApi.Models;
using System.Linq;

namespace MusicApi.Services
{
    internal static class CountingService
    {
        internal static int GetAlbumCountByArtistId(int artistId)
        {
            return AllTheData.Albums
                .Where(x => x.ArtistId == artistId)
                .ToList().Count;
        }

        internal static int GetSongCountByAlbumId(int albumId)
        {
            return AllTheData.Songs
                .Where(x => x.AlbumId == albumId)
                .ToList().Count;
        }
    }
}
