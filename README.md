# consumer-disney-api-id-net-console

Aplicação console em **C# (.NET 9)** que consome o endpoint da [Disney API](https://disneyapi.dev/docs/):

```
https://api.disneyapi.dev/character/423
```

O parâmetro `_id` representa um dos personagens da Disney. O `_id = 423` retorna o **Big Bad Wolf**.

## Atividade

- **a)** Aplicação console em C# que consome o endpoint → projeto `ConsumerDisneyIdApi`
- **b)** Imprime na tela do console os dados retornados pela API (Nome, Imagem, etc.)
- **c)** Repositório no GitHub: `consumer-disney-api-id-net-console`

## Como executar

```bash
cd ConsumerDisneyIdApi
dotnet run            # usa o _id padrão 423
dotnet run -- 308     # consulta outro _id
```

## Saída esperada

```
Nome:
Big Bad Wolf

Imagem:
https://static.wikia.nocookie.net/disney/images/7/73/The_Big_Bad_Wolf.png
...
```

Ao final, o retorno completo da API também é exibido no formato JSON.

## Tecnologias

- .NET 9 / C#
- `HttpClient` para requisição HTTP
- `System.Text.Json` para desserialização
