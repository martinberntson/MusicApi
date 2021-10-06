using MusicApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApi.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }
    }
}
