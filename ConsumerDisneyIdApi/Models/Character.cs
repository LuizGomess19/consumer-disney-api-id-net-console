using System.Text.Json.Serialization;

namespace ConsumerDisneyIdApi.Models;

/// <summary>
/// Representa um personagem da Disney retornado pelo endpoint /character/{_id}.
/// </summary>
public class Character
{
    [JsonPropertyName("_id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("imageUrl")]
    public string? ImageUrl { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("films")]
    public List<string> Films { get; set; } = new();

    [JsonPropertyName("shortFilms")]
    public List<string> ShortFilms { get; set; } = new();

    [JsonPropertyName("tvShows")]
    public List<string> TvShows { get; set; } = new();

    [JsonPropertyName("videoGames")]
    public List<string> VideoGames { get; set; } = new();

    [JsonPropertyName("parkAttractions")]
    public List<string> ParkAttractions { get; set; } = new();

    [JsonPropertyName("allies")]
    public List<string> Allies { get; set; } = new();

    [JsonPropertyName("enemies")]
    public List<string> Enemies { get; set; } = new();
}
