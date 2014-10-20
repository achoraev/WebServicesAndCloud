namespace MusicStore.ConsoleClient.DataClients
{
    using MusicStore.ConsoleClient.Models;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;

    public class SongsDataClient
    {
        private const string JsonContentType = "application/json";
        private const string XmlContentType = "application/xml";
        private const string ControllerUrl = "api/Songs/";
        
        private static readonly MediaTypeWithQualityHeaderValue JsonMediaType =
            new MediaTypeWithQualityHeaderValue(JsonContentType);
        private static readonly MediaTypeWithQualityHeaderValue XmlMediaType =
            new MediaTypeWithQualityHeaderValue(XmlContentType);

        private readonly HttpClient client;

        public SongsDataClient(HttpClient client)
        {
            this.client = client;
        }

        public IEnumerable<SongModel> GetAll()
        {
            var response = this.client.GetAsync(ControllerUrl + "All/").Result;

            if (response.IsSuccessStatusCode)
            {
                var songs = response.Content.ReadAsAsync<IEnumerable<SongModel>>().Result;
                return songs;
            }

            throw new HttpRequestException(string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase));
        }

        public void Create(string title, string genre, int year)
        {
            var song = new SongModel()
            {
                Title = title,
                Genre = genre,
                Year = year
            };

            HttpResponseMessage response = null;

            if (this.client.DefaultRequestHeaders.Accept.Contains(JsonMediaType))
            {
                response = this.client.PostAsJsonAsync<SongModel>(ControllerUrl + "Create/", song).Result;
            }
            else
            {
                response = this.client.PostAsXmlAsync<SongModel>(ControllerUrl + "Create/", song).Result;
            }

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase));
            }
        }

        public void Update(int id, string title, string genre, int year)
        {
            var song = new SongModel()
            {
                Title = title,
                Genre = genre,
                Year = year
            };

            HttpResponseMessage response = null;

            if (this.client.DefaultRequestHeaders.Accept.Contains(JsonMediaType))
            {
                response = this.client.PutAsJsonAsync<SongModel>(ControllerUrl + "Update/" + id, song).Result;
            }
            else
            {
                response = this.client.PutAsXmlAsync<SongModel>(ControllerUrl + "Update/" + id, song).Result;
            }

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase));
            }
        }

        public bool Delete(int id)
        {
            var response = this.client.DeleteAsync(ControllerUrl + "Delete/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}