using Microsoft.EntityFrameworkCore;
using SearchProjectGitHub.BusinessLayer.Contracts;
using SearchProjectGitHub.BusinessLayer.Implementations;
using SearchProjectGitHub.DataAccess;
using SearchProjectGitHub.Infrastructure.Configurations;
using SearchProjectGitHub.Web.Contracts;
using SearchProjectGitHub.Web.Implementations;

namespace SearchProjectGitHub.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IFindProjectService, FindProjectService>();
        serviceCollection.AddScoped<IGitHubSerivce, GitHubService>();
    }

    public static void AddDbContext(this IServiceCollection serviceCollection, ConfigurationManager configurationManager)
    {
        serviceCollection.AddDbContext<AppDbContext>(opt =>
            opt.UseNpgsql(configurationManager.GetConnectionString("SearchProjectGitHubDb")));
    }

    public static void AddConfig(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<GitHubSettings>(
            config.GetSection(GitHubSettings.SECTION));
    }
}
