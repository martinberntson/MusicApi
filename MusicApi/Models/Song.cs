using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApi.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public int AlbumId { get; set; }

    }
}
