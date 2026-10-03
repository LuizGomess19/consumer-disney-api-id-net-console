using System.Text.Json.Serialization;

namespace ConsumerDisneyIdApi.Models;

/// <summary>
/// Envelope retornado pela Disney API: { "info": {...}, "data": {...} }
/// </summary>
public class DisneyResponse
{
    [JsonPropertyName("info")]
    public Info? Info { get; set; }

    [JsonPropertyName("data")]
    public Character? Data { get; set; }
}

public class Info
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("totalPages")]
    public int TotalPages { get; set; }

    [JsonPropertyName("previousPage")]
    public string? PreviousPage { get; set; }

    [JsonPropertyName("nextPage")]
    public string? NextPage { get; set; }
}
