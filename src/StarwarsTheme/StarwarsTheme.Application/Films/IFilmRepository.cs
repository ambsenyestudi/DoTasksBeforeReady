using StarwarsTheme.Domain;
using StarwarsTheme.Domain.Films;
using System.Threading;
using System.Threading.Tasks;

namespace StarwarsTheme.Application.Films
{
    public interface IFilmRepository
    {
        LastUpdated LastUpdated { get; }
        Task UpdateRepositoryAsync(CancellationToken cancellationToken);
        FilmCollection GetAll();
    }
}
