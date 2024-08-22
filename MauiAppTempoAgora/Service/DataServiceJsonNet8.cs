using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiAppTempoAgora.Models;
using System.Text.Json;
using System.Diagnostics;

namespace MauiAppTempoAgora.Service
{
    public class DataServiceJsonNet8
    {
        public static async Task<Tempo?> GetPrevisaoDoTempo(string cidade)
        {

            string appId = "8763025d495d7733b344a1faab4ef14e";

            string url = $"http://api.openweathermap.org/data/2.5/weather?q={cidade}&units=metric&appid={appId}";

            Tempo? tempo = null;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    Debug.WriteLine("--------------------------------------------------------------------");
                    Debug.WriteLine(json);
                    Debug.WriteLine("--------------------------------------------------------------------");

                    tempo = JsonSerializer.Deserialize<Tempo>(json);
                }
            }

            return tempo;
        }
    }
}
