using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.FeatureManagement;
using Microsoft.OpenApi.Models;
using StarwarsTheme.Application.Characters;
using StarwarsTheme.Application.Films;
using StarwarsTheme.Application.Quizing;
using StarwarsTheme.Filters;
using StarwarsTheme.Infrastructure;
using StarwarsTheme.Infrastructure.Characters;
using StarwarsTheme.Infrastructure.Films;
using StarwarsTheme.Infrastructure.Mapping.Profiles;
using StarwarsTheme.Infrastructure.Quizing;
using StarwarsTheme.PriorToReadyTasks;
using System.Reflection;

namespace StarwarsTheme
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(config=> {
                config.Filters.Add(typeof(ExceptionFilter));
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StarwarsTheme", Version = "v1" });
            });
            services.Configure<StarwarsGatewaySettings>(Configuration.GetSection(nameof(StarwarsGatewaySettings)));
            services.AddFeatureManagement();
            services.AddPriorToReadyTasks();

            services
                .AddSingleton<IQuizRepository, InMemoryQuizRepository>()
                .AddTransient<IQuizService, QuizService>()
                .AddTransient<IQuizMappingService, QuizMappingService>()
                .AddSingleton<IFilmRepository, InMemoryFilmRepository>()
                .AddTransient<IFilmService, FilmService>()
                .AddTransient<IFilmMappingService, FilmMappingService>()
                .AddTransient<ICharacterService, CharacterService>()
                .AddTransient<ICharacterMappingService, CharacterMappingService>()
                .AddSingleton<ICharacterRepository, InMemoryCharacterRepository>()
                .AddAutoMapper(Assembly.GetAssembly(typeof(CharacterProfile)))
                .AddHttpClient<IStarwarsCharactersGateway, StarwarsCharactersGateway>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StarwarsTheme v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
