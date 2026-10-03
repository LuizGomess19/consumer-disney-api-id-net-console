using System.Text.Json;
using ConsumerDisneyIdApi.Models;

namespace ConsumerDisneyIdApi;

/// <summary>
/// Aplicação console que consome o endpoint da Disney API:
/// https://api.disneyapi.dev/character/{_id}
/// Por padrão usa o _id = 423 (Big Bad Wolf). Um outro _id pode ser passado como argumento:
///   dotnet run -- 308
/// </summary>
internal class Program
{
    private const string BaseUrl = "https://api.disneyapi.dev/character/";
    private const int DefaultId = 423;

    private static async Task<int> Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int id = DefaultId;
        if (args.Length > 0 && !int.TryParse(args[0], out id))
        {
            Console.WriteLine($"_id inválido: '{args[0]}'. Informe um número inteiro.");
            return 1;
        }

        string url = $"{BaseUrl}{id}";

        using var client = new HttpClient { Timeout = TimeSpan.FromSeconds(30) };

        try
        {
            Console.WriteLine($"Consultando: {url}");
            Console.WriteLine(new string('-', 60));

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<DisneyResponse>(json);
            Character? character = result?.Data;

            if (character is null || string.IsNullOrWhiteSpace(character.Name))
            {
                Console.WriteLine($"Nenhum personagem encontrado para o _id = {id}.");
                return 1;
            }

            // b) Imprime os dados retornados da API na tela do console
            Console.WriteLine("Nome:");
            Console.WriteLine(character.Name);
            Console.WriteLine();
            Console.WriteLine("Imagem:");
            Console.WriteLine(character.ImageUrl);
            Console.WriteLine();

            PrintList("Filmes", character.Films);
            PrintList("Curtas", character.ShortFilms);
            PrintList("Séries de TV", character.TvShows);
            PrintList("Video games", character.VideoGames);
            PrintList("Atrações em parques", character.ParkAttractions);
            PrintList("Aliados", character.Allies);
            PrintList("Inimigos", character.Enemies);

            // Retorno da API no formato JSON
            Console.WriteLine(new string('-', 60));
            Console.WriteLine("Retorno da API no formato JSON:");
            using var doc = JsonDocument.Parse(json);
            Console.WriteLine(JsonSerializer.Serialize(doc.RootElement,
                new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                }));

            return 0;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Erro na requisição HTTP: {ex.Message}");
        }
        catch (TaskCanceledException)
        {
            Console.WriteLine("A requisição excedeu o tempo limite.");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Erro ao ler o JSON retornado: {ex.Message}");
        }

        return 1;
    }

    private static void PrintList(string title, List<string> items)
    {
        Console.WriteLine($"{title} ({items.Count}):");
        if (items.Count == 0)
        {
            Console.WriteLine("  - (nenhum)");
        }
        else
        {
            foreach (var item in items)
                Console.WriteLine($"  - {item}");
        }
        Console.WriteLine();
    }
}
