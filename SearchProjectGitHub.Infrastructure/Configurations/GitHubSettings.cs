namespace SearchProjectGitHub.Infrastructure.Configurations;

public class GitHubSettings
{
    public const string SECTION = "GitHubSettings";
    public string Url { get; set; } = null!;
}
