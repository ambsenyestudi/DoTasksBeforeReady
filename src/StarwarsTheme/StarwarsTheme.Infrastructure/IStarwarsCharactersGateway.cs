using StarwarsTheme.Infrastructure.Characters.Models;
using StarwarsTheme.Infrastructure.Films.Models;
using System.Threading;
using System.Threading.Tasks;

namespace StarwarsTheme.Infrastructure
{
    public interface IStarwarsCharactersGateway
    {
        Task<StarwarsCharacterResponse> GetAllCharactersAsync(CancellationToken cancellationToken);
        Task<StarwarsFilmResponse> GetAllFilmsAsync(CancellationToken cancellationToken);
    }
}