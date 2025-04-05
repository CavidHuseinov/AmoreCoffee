using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Core.Entities
{
    public class SpotifyPlaylist
    {
        public int Id { get; set; }
        public string PlaylistId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

