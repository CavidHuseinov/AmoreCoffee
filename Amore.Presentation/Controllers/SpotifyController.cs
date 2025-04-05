using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Services.Interfaces;
using Amore.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

[Route("api/spotify")]
[ApiController]
public class SpotifyController : ControllerBase
{
    private readonly ISpotifyService _spotifyService;
    private readonly ILogger<SpotifyController> _logger;

    public SpotifyController(ISpotifyService spotifyService, ILogger<SpotifyController> logger)
    {
        _spotifyService = spotifyService;
        _logger = logger;
    }

    [HttpGet("playlist/{id}")]
    public async Task<IActionResult> GetPlaylist(string id)
    {
        try
        {
            var playlist = await _spotifyService.GetPlaylistAsync(id);
            if (playlist == null)
            {
                return NotFound(new { message = "Playlist bulunamadı" });
            }
            return Ok(playlist);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching playlist");
            return StatusCode(500, new { message = "Daxili server xətası", error = ex.Message });
        }
    }

    [HttpGet("token")]
    public async Task<ActionResult<SpotifyAuthResponse>> GetToken()
    {
        try
        {
            var tokenResponse = await _spotifyService.GetSpotifyAccessToken();
            return Ok(tokenResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving Spotify token");
            return StatusCode(500, new { message = "Internal server error", error = ex.Message });
        }
    }
}


