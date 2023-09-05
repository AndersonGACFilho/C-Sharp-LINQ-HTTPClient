
using System.Text.Json;
using C_Sharp_LINQ_HTTPClient.Filters;
using C_Sharp_LINQ_HTTPClient.Models;

using (HttpClient client = new HttpClient())
{
    string resposta;
    try
    {
        resposta =  await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!; 
        Console.WriteLine(musicas.Count);

        musicas[0].ExibirDetalhes();

        //LinqFilter.FiltarTodosGenerosMusicais(musicas);
        //LinqOrder.ExibirArtistasOrdenados(musicas);
        //LinqFilter.FiltrarArtistasGeneroMusical(musicas, "rock");
        //LinqFilter.FiltarMusicasArtista(musicas, "Michael Jackson");


        var musicasPreferidas = new MusicasPreferidas("Andy");

        musicasPreferidas.AdicionarMusica(musicas[0]);
        musicasPreferidas.AdicionarMusica(musicas[1]);
        musicasPreferidas.AdicionarMusica(musicas[2]);
        musicasPreferidas.AdicionarMusica(musicas[3]);
        musicasPreferidas.AdicionarMusica(musicas[4]);
        musicasPreferidas.AdicionarMusica(musicas[5]);

        musicasPreferidas.ExibirMusicas();

        musicasPreferidas.GerarJson();


        LinqFilter.FiltrarMusicasTonalidade(musicas, "C#");
    }
    catch (Exception e)
    {
        Console.WriteLine("Teve um erro: {0}", e.Message);
    }
}
