using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using StarwarsTheme.Application.Characters;
using StarwarsTheme.Application.Films;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StarwarsTheme.PriorToReadyTasks
{
    public class InMemoryRepositoriesDataFetchingTask : IStartupTask
    {
        private readonly IServiceProvider serviceProvider;

        public InMemoryRepositoriesDataFetchingTask(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public async Task ExecuteAsync(CancellationToken cancellationToken = default)
        {
            var featureManager = serviceProvider.GetRequiredService<IFeatureManager>();
            if (await featureManager.IsEnabledAsync("PriorToReadyDataFetchingFeature"))
            {
                var characterRepo = serviceProvider.GetRequiredService<ICharacterRepository>();
                await characterRepo.UpdateRepositoryAsync(cancellationToken);
                var filmRepo = serviceProvider.GetRequiredService<IFilmRepository>();
                await filmRepo.UpdateRepositoryAsync(cancellationToken);
            }
            
        }
    }
}
