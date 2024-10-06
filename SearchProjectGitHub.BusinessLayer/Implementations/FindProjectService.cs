using Microsoft.EntityFrameworkCore;
using SearchProjectGitHub.BusinessLayer.Contracts;
using SearchProjectGitHub.BusinessLayer.Models.DTO;
using SearchProjectGitHub.DataAccess;
using SearchProjectGitHub.DataAccess.Models;
using SearchProjectGitHub.Web.Contracts;
using SearchProjectGitHub.Web.Models.ApiModels;
using System.Text.Json;

namespace SearchProjectGitHub.Web.Implementations;

public class FindProjectService : IFindProjectService
{
    private const int PAGE_SIZE = 9;

    private readonly AppDbContext _appDbContext;
    private readonly IGitHubSerivce _gitHubSerivce;

    public FindProjectService(AppDbContext appDbContext, IGitHubSerivce gitHubSerivce)
    {
        _appDbContext = appDbContext ?? throw new NotImplementedException(nameof(appDbContext));
        _gitHubSerivce = gitHubSerivce ?? throw new NotImplementedException(nameof(gitHubSerivce));
    }

    public async Task DeleteProjectsAsync(Guid searchResultId)
        => await _appDbContext.SearchResults
            .Where(sr => sr.SearchResultId == searchResultId)
            .ExecuteDeleteAsync();

    public async Task FindProjectsAsync(string searchString)
    {
        string resultJson = await _gitHubSerivce.SearchProjectsAsync(searchString);

        SearchResult newSearchResult = new()
        {
            SearchString = searchString,
            ResultJson = resultJson,
        };

        await _appDbContext.AddAsync(newSearchResult);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<GetProjectsResultDTO> GetProjectsAsync(string searchString, int pageNumber = 1)
    {
        var searchResult = await _appDbContext.SearchResults
            .AsNoTracking()
            .Where(sr => sr.SearchString == searchString)
            .FirstOrDefaultAsync();

        if (searchResult == default)
        {
            return new GetProjectsResultDTO(Array.Empty<ProjectsDTO>(), 0);
        }

        var projectsJson = JsonSerializer.Deserialize<SearchProjectsJsonResult>(searchResult.ResultJson);

        var projects = projectsJson.Projects
            .Skip((pageNumber - 1) * PAGE_SIZE)
            .Take(PAGE_SIZE)
            .Select(
                p => new ProjectsDTO(
                    p.Name,
                    p.Author.Name,
                    p.StargazersCount,
                    p.WatchersCount,
                    p.LinkRepo))
            .ToArray();

        var countPages = projectsJson.Projects.Count() / PAGE_SIZE;

        return new(projects, countPages);
    }
}
