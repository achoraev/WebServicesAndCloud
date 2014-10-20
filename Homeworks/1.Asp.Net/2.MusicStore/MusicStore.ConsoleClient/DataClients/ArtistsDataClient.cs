namespace MusicStore.ConsoleClient.DataClients
{
    using MusicStore.ConsoleClient.Models;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;

    public class ArtistsDataClient
    {
        private const string JsonContentType = "application/json";
        private const string XmlContentType = "application/xml";
        private const string ControllerUrl = "api/Artists/";

        private static readonly MediaTypeWithQualityHeaderValue JsonMediaType =
            new MediaTypeWithQualityHeaderValue(JsonContentType);
        private static readonly MediaTypeWithQualityHeaderValue XmlMediaType =
            new MediaTypeWithQualityHeaderValue(XmlContentType);

        private readonly HttpClient client;

        public ArtistsDataClient(HttpClient client)
        {
            this.client = client;
        }

        public IEnumerable<ArtistModel> GetAll()
        {
            var response = this.client.GetAsync(ControllerUrl + "All/").Result;

            if (response.IsSuccessStatusCode)
            {
                var artists = response.Content.ReadAsAsync<IEnumerable<ArtistModel>>().Result;
                return artists;
            }

            throw new HttpRequestException(string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase));
        }

        public void Create(string name, string country, DateTime? birthDate)
        {
            var artist = new ArtistModel() 
            {
                Name = name,
                Country = country,
                BirthDate = birthDate
            };

            HttpResponseMessage response = null;
            if (this.client.DefaultRequestHeaders.Accept.Contains(JsonMediaType))
            {
                response = this.client.PostAsJsonAsync<ArtistModel>(ControllerUrl + "Create/", artist).Result;
            }
            else
            {
                response = this.client.PostAsXmlAsync<ArtistModel>(ControllerUrl + "Create/", artist).Result;
            }

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase));
            }
        }

        public void Update(int id, string name, string country, DateTime? birthDate)
        {
            var artist = new ArtistModel()
            {
                Name = name,
                Country = country,
                BirthDate = birthDate
            };

            HttpResponseMessage response = null;

            if (this.client.DefaultRequestHeaders.Accept.Contains(JsonMediaType))
            {
                response = this.client.PutAsJsonAsync<ArtistModel>(ControllerUrl + "Update/" + id, artist).Result;
            }
            else
            {
                response = this.client.PutAsXmlAsync<ArtistModel>(ControllerUrl + "Update/" + id, artist).Result;
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