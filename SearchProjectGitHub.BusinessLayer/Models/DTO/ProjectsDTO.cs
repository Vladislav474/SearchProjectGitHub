namespace SearchProjectGitHub.BusinessLayer.Models.DTO;

/// <summary>
/// Модель с информацией о проекте.
/// </summary>
/// <param name="ProjectName">Имя проекта.</param>
/// <param name="Author">Автор.</param>
/// <param name="Stargazers">Количество звезд.</param>
/// <param name="Watchers">Количество просмотров.</param>
/// <param name="LinkRepo">Ссылка на репозиторий.</param>
public record ProjectsDTO(
    string ProjectName,
    string Author,
    int Stargazers,
    int Watchers,
    string LinkRepo);
