using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using SearchProjectGitHub.BusinessLayer.Contracts;
using SearchProjectGitHub.Infrastructure.Configurations;

namespace SearchProjectGitHub.BusinessLayer.Implementations;

public class GitHubService : IGitHubSerivce
{
    private const string SEARCH_PARAMETER_NAME = "q";

    private readonly GitHubSettings _gitHubSettings;
    public GitHubService(IOptions<GitHubSettings> gitHubSettingsOption)
    {
        _gitHubSettings = gitHubSettingsOption.Value ?? throw new NotImplementedException(nameof(gitHubSettingsOption));
    }

    public async Task<string> SearchProjectsAsync(string searchString)
        => await _gitHubSettings.Url
            .SetQueryParam(SEARCH_PARAMETER_NAME, searchString)
            .WithHeaders(new { User_Agent = "MyApp" })
            .GetStringAsync();
}
