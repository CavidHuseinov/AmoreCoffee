using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Spotify;
using Amore.Business.Services.Interfaces;
using Amore.Core.Entities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using SpotifyAPI.Web;

namespace Amore.Service.Services
{
    public class SpotifyService : ISpotifyService
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly IMemoryCache _cache;
        private readonly TimeSpan TokenBufferTime = TimeSpan.FromSeconds(30);

        public SpotifyService(IOptions<SpotifyOptionss> spotifyOptions, IMemoryCache cache)
        {
            _clientId = spotifyOptions.Value.ClientId;
            _clientSecret = spotifyOptions.Value.ClientSecret;
            _cache = cache;
        }

        public async Task<bool> IsTokenValid()
        {
            return _cache.TryGetValue("SpotifyAccessToken", out SpotifyAuthResponse cachedToken) &&
                   DateTime.UtcNow < DateTime.UtcNow.AddSeconds(cachedToken.ExpiresIn - TokenBufferTime.TotalSeconds);
        }

        private async Task EnsureValidToken()
        {
            if (!await IsTokenValid())
            {
                var authResponse = await GetSpotifyAccessToken();
                _cache.Set("SpotifyAccessToken", authResponse, DateTime.UtcNow.AddSeconds(authResponse.ExpiresIn - TokenBufferTime.TotalSeconds));
            }
        }

        public async Task<SpotifyAuthResponse> GetSpotifyAccessToken()
        {
            if (_cache.TryGetValue("SpotifyAccessToken", out SpotifyAuthResponse cachedToken))
            {
                return cachedToken;
            }

            using (var client = new HttpClient())
            {
                var credentials = $"{_clientId}:{_clientSecret}";
                var base64Credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));

                var request = new HttpRequestMessage(HttpMethod.Post, "https://accounts.spotify.com/api/token");
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64Credentials);
                request.Content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "client_credentials")
                });

                var response = await client.SendAsync(request);
                var responseString = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Spotify Access Token alınamadı! Hata: {responseString}");
                }

                var json = JObject.Parse(responseString);
                var authResponse = new SpotifyAuthResponse
                {
                    AccessToken = json["access_token"].ToString(),
                    TokenType = json["token_type"].ToString(),
                    ExpiresIn = (int)json["expires_in"],
                    Scope = json.ContainsKey("scope") ? json["scope"].ToString() : ""
                };

                _cache.Set("SpotifyAccessToken", authResponse, DateTime.UtcNow.AddSeconds(authResponse.ExpiresIn - TokenBufferTime.TotalSeconds));
                return authResponse;
            }
        }

        public async Task<CustomPlaylistDto> GetPlaylistAsync(string playlistId)
        {
            await EnsureValidToken();

            var cachedToken = _cache.Get<SpotifyAuthResponse>("SpotifyAccessToken");
            var config = SpotifyClientConfig.CreateDefault().WithToken(cachedToken.AccessToken);
            var client = new SpotifyClient(config);

            var playlist = await client.Playlists.Get(playlistId);

            return new CustomPlaylistDto
            {
                Id = playlist.Id,
                Name = playlist.Name,
                Description = playlist.Description,
                Owner = playlist.Owner?.DisplayName ?? "Unknown Owner",
                TrackNames = playlist.Tracks.Items
                                .Where(track => track.Track is FullTrack)
                                .Select(track => ((FullTrack)track.Track).Name)
                                .ToList(),
                TrackUris = playlist.Tracks.Items
                                .Where(track => track.Track is FullTrack)
                                .Select(track => ((FullTrack)track.Track).Uri)
                                .ToList(),
                Href = $"http://localhost:5000/api/spotify/playlist/{playlist.Id}"
            };
        }
    }
}

