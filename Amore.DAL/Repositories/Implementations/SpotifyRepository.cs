using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Core.Entities;
using Amore.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace Amore.DAL.Repositories.Implementations
{

    public class SpotifyRepository
    {
        private readonly AmoreDbContext _context;

        public SpotifyRepository(AmoreDbContext context)
        {
            _context = context;
        }

        public async Task AddPlaylistAsync(SpotifyPlaylist playlist)
        {
            await _context.SpotifyPlaylists.AddAsync(playlist);
            await _context.SaveChangesAsync();
        }

        public async Task<SpotifyPlaylist> GetPlaylistByIdAsync(int id)
        {
            return await _context.SpotifyPlaylists.FirstOrDefaultAsync(p => p.Id == id);
        }
    }

}
