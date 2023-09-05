using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Sharp_LINQ_HTTPClient.Models;

namespace C_Sharp_LINQ_HTTPClient.Filters;
internal class LinqFilter
{
    public static void FiltarTodosGenerosMusicais(List<Musica> musicas)
    {
        var generos = musicas.Select(musica => musica.Genero).Distinct().ToList();
        Console.WriteLine("\r\nGêneros musicais:");
        generos.ForEach(genero => Console.WriteLine($"- {genero}"));
        Console.WriteLine();
    }

    public static void FiltrarArtistasGeneroMusical(List<Musica> musicas, string genero)
    {
        var artistas = musicas.Where(musica => musica.Genero.Contains(genero)).ToList()
                        .Select(musica => musica.Artista).Distinct().ToList();

        Console.WriteLine($"\n\rArtistas do gênero {genero}:");
        artistas.ForEach(artista => Console.WriteLine($"- {artista}"));
        Console.WriteLine();
    }

    public static void FiltarMusicasArtista(List<Musica> musicas, string artista)
    {
        var musicasArtista = musicas.Where(musica => musica.Artista!.Equals(artista)).ToList();
        Console.WriteLine($"\n\rMúsicas do artista {artista}:");
        musicasArtista.ForEach(musica => Console.WriteLine($"- {musica.Nome}"));
        Console.WriteLine();
    }

    public static void FiltrarMusicasTonalidade(List<Musica> musicas, string tonalidade)
    {
        var musicasTonalidade = musicas.Where(musica => musica.Tonalidade.Equals(tonalidade)).ToList();
        Console.WriteLine($"\n\rMúsicas na tonalidade {tonalidade}:");
        musicasTonalidade.ForEach(musica => Console.WriteLine($"- {musica.Nome}"));
        Console.WriteLine();

    }
}
