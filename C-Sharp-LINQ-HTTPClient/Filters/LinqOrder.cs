using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Sharp_LINQ_HTTPClient.Models;

namespace C_Sharp_LINQ_HTTPClient.Filters;
internal class LinqOrder
{
    public static void ExibirArtistasOrdenados(List<Musica> musicas)
    {
        var artistas = musicas.OrderBy(musica => musica.Artista).ToList()
            .Select(musica=> musica.Artista).Distinct().ToList();

        Console.WriteLine("\n\rArtistas:");
        artistas.ForEach(artista => Console.WriteLine($"- {artista}"));
    }
}
