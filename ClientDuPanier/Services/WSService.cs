using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TDEvalutaion.Models.EntityFramework;

namespace TP2Client.Services
{
    public class WSService
    {
        private readonly HttpClient HttpClient;

        public WSService(string url)
        {
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri("https://localhost:7086/api/");
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<List<Fruit>> GetSerieAsync(string nomControleur)
        {
            try
            {
                return await HttpClient.GetFromJsonAsync<List<Fruit>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<Fruit> GetASerieAsync(Fruit serie)
        {
            var response = await HttpClient.GetAsync("fruits/" + serie.IdFruit);

            if (response.IsSuccessStatusCode)
            {
                var serieFromResponse = await response.Content.ReadAsAsync<Fruit>();
                return serieFromResponse;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> PostSerieAsync(Fruit serie)
        {
            var response = await HttpClient.PostAsJsonAsync("series", serie);
            var test = response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> PutSerieAsync(Fruit serie)
        {
            var response = await HttpClient.PutAsJsonAsync("series/" + serie.IdFruit, serie);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteSerieAsync(Fruit serie)
        {
            var response = await HttpClient.DeleteAsync("series/" + serie.IdFruit);
            return response.IsSuccessStatusCode;
        }








    }
}