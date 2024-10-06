using SearchProjectGitHub.BusinessLayer.Models.DTO;
using SearchProjectGitHub.Web.Models.ApiModels;

namespace SearchProjectGitHub.Web.Contracts;

/// <summary>
/// Сервис для работы с проектами GutHub.
/// </summary>
public interface IFindProjectService
{
    Task FindProjectsAsync(string searchString);
    Task<GetProjectsResultDTO> GetProjectsAsync(string searchString, int pageNumber = 1);
    Task DeleteProjectsAsync(Guid searchResultId);
}
