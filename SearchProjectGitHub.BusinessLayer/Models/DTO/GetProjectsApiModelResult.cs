using SearchProjectGitHub.BusinessLayer.Models.DTO;

namespace SearchProjectGitHub.Web.Models.ApiModels;

/// <summary>
/// Модель с результатом поиска проектов.
/// </summary>
/// <param name="Projects">Список проектов.</param>
/// <param name="CountPages">Количество страниц для пагинации.</param>
public record GetProjectsResultDTO(IReadOnlyCollection<ProjectsDTO> Projects, int CountPages);
