using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Spotify;
using Amore.Core.Entities;
using SpotifyAPI.Web;

namespace Amore.Business.Services.Interfaces
{
    public interface ISpotifyService
    {
        Task<CustomPlaylistDto> GetPlaylistAsync(string playlistId);
        Task<SpotifyAuthResponse> GetSpotifyAccessToken();
        Task<bool> IsTokenValid();
    }

}