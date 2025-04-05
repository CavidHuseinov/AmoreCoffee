using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.DTOs.Spotify
{
    public record CustomPlaylistDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> TrackNames { get; set; }
        public string Owner { get; set; }
        public string Href { get; set; }
        public List<string> TrackUris
        {
            get; set;
        }


    }
}
