using Microsoft.AspNetCore.Mvc;
using SearchProjectGitHub.BusinessLayer.Models.DTO;
using SearchProjectGitHub.Web.Contracts;
using SearchProjectGitHub.Web.Models.ApiModels;

namespace SearchProjectGitHubWeb.Web.ApiControllers;

[Route("api/[controller]")]
[ApiController]
public class FindController : ControllerBase
{
    private readonly IFindProjectService _findProjectService;
    public FindController(IFindProjectService findProjectService)
    {
        _findProjectService = findProjectService ?? throw new NotImplementedException(nameof(findProjectService));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSearchResultId(Guid searchResultId)
    {
        await _findProjectService.DeleteProjectsAsync(searchResultId);

        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult> FindProjects([FromBody] FindProjectsApiModel findProjectsApiModel)
    {
        await _findProjectService.FindProjectsAsync(findProjectsApiModel.SearchString);

        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<GetProjectsApiModelResult>> GetProjects(string searchString, int pageNumber)
    {
        var projectsResultDTO = await _findProjectService.GetProjectsAsync(searchString, pageNumber);

        GetProjectsApiModelResult result = new (
            projectsResultDTO.Projects
                .Select(p => 
                    new ProjectApiResult(
                        p.ProjectName,
                        p.Author,
                        p.Stargazers,
                        p.Watchers,
                        p.LinkRepo))
                .ToArray(), 
            projectsResultDTO.CountPages);;

        return Ok(result);
    }
}
