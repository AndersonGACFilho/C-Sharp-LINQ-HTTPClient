using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using C_Sharp_LINQ_HTTPClient.Models;

namespace C_Sharp_LINQ_HTTPClient.Models;

internal class MusicasPreferidas
{
    public string? Nome { get; set; }
    public List<Musica> Musicas { get;}

    public MusicasPreferidas(string nome)
    {
        Nome = nome;
        Musicas = new List<Musica>();
    }

    public void AdicionarMusica(Musica musica)
    {
        Musicas.Add(musica);
    }

    public void ExibirMusicas()
    {
        Console.WriteLine($"Músicas preferidas de {Nome}:");
        Musicas.ForEach(musica => Console.WriteLine($"- {musica.Nome} de {musica.Artista}"));
        Console.WriteLine();
    }

    public string GerarJson()
    {
        string json = JsonSerializer.Serialize(new
        {
            nome = Nome,
            musicas = Musicas
        });

        string nomeArquivo = Nome!.Replace(" ", "_");

        File.WriteAllText($"MusicasPreferidas_{nomeArquivo}.json", json);

        Console.WriteLine($"Arquivo MusicasPreferidas_{nomeArquivo}.json gerado com sucesso! \r\n" +
                          $"{Path.GetFullPath($"MusicasPreferidas_{nomeArquivo}.json")}");
        return nomeArquivo;
    }
}
