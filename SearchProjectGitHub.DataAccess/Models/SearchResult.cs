namespace SearchProjectGitHub.DataAccess.Models;

/// <summary>
/// Модель с результатом поиска в GitHub
/// </summary>
public class SearchResult
{
    public Guid SearchResultId { get; set; }
    public string SearchString { get; set; } = null!;
    public string ResultJson { get; set; } = null!;
}
