namespace MusicStore.ConsoleClient.DataClients
{
    using MusicStore.ConsoleClient.Models;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;

    public class AlbumsDataClient
    {
        private const string JsonContentType = "application/json";
        private const string XmlContentType = "application/xml";
        private const string ControllerUrl = "api/Albums/";

        private static readonly MediaTypeWithQualityHeaderValue JsonMediaType =
           new MediaTypeWithQualityHeaderValue(JsonContentType);
        private static readonly MediaTypeWithQualityHeaderValue XmlMediaType =
            new MediaTypeWithQualityHeaderValue(XmlContentType);

        private readonly HttpClient client;

        public AlbumsDataClient(HttpClient client)
        {
            this.client = client;
        }

        public IEnumerable<AlbumModel> GetAll()
        {
            var response = this.client.GetAsync(ControllerUrl + "All/").Result;

            if (response.IsSuccessStatusCode)
            {
                var albums = response.Content.ReadAsAsync<IEnumerable<AlbumModel>>().Result;
                return albums;
            }

            throw new HttpRequestException(string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase));
        }

        public void Create(string title, int year, string producer)
        {
            var album = new AlbumModel()
            {
                Title = title,
                Year = year,
                Producer = producer
            };

            HttpResponseMessage response = null;

            if (this.client.DefaultRequestHeaders.Accept.Contains(JsonMediaType))
            {
                response = this.client.PostAsJsonAsync<AlbumModel>(ControllerUrl + "Create/", album).Result;
            }
            else
            {
                response = this.client.PostAsXmlAsync<AlbumModel>(ControllerUrl + "Create/", album).Result;
            }

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase));
            }
        }

        public void Update(int id, string title, string producer, int year)
        {
            var album = new AlbumModel()
            {
                Title = title,
                Year = year,
                Producer = producer
            };

            HttpResponseMessage response = null;

            if (this.client.DefaultRequestHeaders.Accept.Contains(JsonMediaType))
            {
                response = this.client.PutAsJsonAsync<AlbumModel>(ControllerUrl + "Update/" + id, album).Result;
            }
            else
            {
                response = this.client.PutAsXmlAsync<AlbumModel>(ControllerUrl + "Update/" + id, album).Result;
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