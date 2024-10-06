using System.Text.Json.Serialization;

namespace SearchProjectGitHub.BusinessLayer.Models.DTO;

/// <summary>
/// Результат сериализации ответа с информацией о проектах.
/// </summary>
public class SearchProjectsJsonResult
{
    [JsonPropertyName("items")]
    public Project[] Projects { get; set; }
}

public class Project
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("stargazers_count")]
    public int StargazersCount { get; set; }

    [JsonPropertyName("watchers_count")]
    public int WatchersCount { get; set; }

    [JsonPropertyName("html_url")]
    public string LinkRepo { get; set; }

    [JsonPropertyName("owner")]
    public AuthorProject Author { get; set; }
}

public class AuthorProject
{
    [JsonPropertyName("login")]
    public string Name { get; set; }
}
