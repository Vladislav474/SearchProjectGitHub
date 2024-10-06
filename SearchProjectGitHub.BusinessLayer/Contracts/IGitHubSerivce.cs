namespace SearchProjectGitHub.BusinessLayer.Contracts;

/// <summary>
/// Сервис работы с API GitHub
/// </summary>
public interface IGitHubSerivce
{
    /// <summary>
    /// Поиск проектов на GitHub.
    /// </summary>
    /// <param name="searchString">Строка для поиска.</param>
    /// <returns>JSON с результатом запроса.</returns>
    Task<string> SearchProjectsAsync(string searchString);
}
