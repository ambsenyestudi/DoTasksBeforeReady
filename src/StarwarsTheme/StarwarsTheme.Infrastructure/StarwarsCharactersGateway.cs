using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StarwarsTheme.Infrastructure.Characters.Models;
using StarwarsTheme.Infrastructure.Films.Models;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace StarwarsTheme.Infrastructure
{
    public class StarwarsCharactersGateway : IStarwarsCharactersGateway
    {
        private readonly HttpClient httpClient;
        private readonly StarwarsGatewaySettings settings;

        public StarwarsCharactersGateway(HttpClient httpClient, IOptions<StarwarsGatewaySettings> options)
        {
            settings = options.Value;
            this.httpClient = httpClient;
            this.httpClient.BaseAddress = new Uri(settings.BaseAddress);
        }
        public async Task<StarwarsCharacterResponse> GetAllCharactersAsync(CancellationToken cancellationToken)
        {
            var json = await Get(settings.CharactersEndpoint, cancellationToken);
            return JsonConvert.DeserializeObject<StarwarsCharacterResponse>(json);
        }

        public async Task<StarwarsFilmResponse> GetAllFilmsAsync(CancellationToken cancellationToken)
        {
            var json = await Get(settings.FilmsEndpoint, cancellationToken);
            return JsonConvert.DeserializeObject<StarwarsFilmResponse>(json);
        }

        private async Task<string> Get(string method, CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAsync(method, cancellationToken);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
