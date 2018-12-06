using System;
using System.Collections;
using System.Collections.Generic;
using Westeros.Ranking.ApiClient;
using Westeros.Ranking.ApiClient.Contracts;

namespace Westeros.Ranking.Service
{
    class Program
    {
        static void Main()
        {
            StarkApiClient client = new StarkApiClient("http://localhost:3142/");
            KomentarzDto k = new KomentarzDto
            {
                Data = new DateTime(1111, 12, 12, 12, 12, 12),
                Nick = "OreDa",
                Tekst = "ASD",
                resourceId = 1,
                resourceName = "Dieta"
            };
            //client.AddNewKomentarz(k);
            IEnumerable<KomentarzDto> lista;
            lista = client.AllKomentarze();
            foreach (KomentarzDto komentarzDto in lista)
            {
                Console.WriteLine(komentarzDto.ToString());
            }
            Console.Read();
        }
    }
}