using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApi.Models
{
    public static class AllTheData
    {
        public static CurrentIds CurrentIds { get; set; }       // If an item is removed, my previous method of creating UIDs would fail, so this is here instead.
        public static List<Artist> Artists { get; set; }
        public static List<Album> Albums { get; set; }
        public static List<Song> Songs { get; set; }
    }
}
