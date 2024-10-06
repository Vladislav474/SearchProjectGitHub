using System.Text.Json.Serialization;

namespace SearchProjectGitHub.Web.Models.ApiModels;

/// <summary>
/// Модель для поиска проектов на GitHub.
/// </summary>
public class FindProjectsApiModel
{
    [JsonRequired]
    public string SearchString { get; set; }
}
