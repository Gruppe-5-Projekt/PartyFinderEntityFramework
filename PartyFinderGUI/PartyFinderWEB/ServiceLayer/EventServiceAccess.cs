using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using PartyFinderWEB.Models;

namespace PartyFinderWEB.ServiceLayer
{
    public class EventServiceAccess
    {

        static readonly string restUrl = "https://localhost:44377/api/event";
        readonly HttpClient _httpClient;

        public EventServiceAccess()
        {
            _httpClient = new HttpClient();
        }
        // Method to retrieve Event(s)
        public async Task<List<EventViewModel>> GetEvents(int id = -1)
        {
            List<EventViewModel> EventFromService = null;

            // api/events/{id}
            string useRestUrl = restUrl;
            bool hasValidId = (id > 0);
            if (hasValidId)
            {
                useRestUrl += id;
            }
            var uri = new Uri(string.Format(useRestUrl));
            //
            try
            {
                var response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (hasValidId)
                    {

                        EventViewModel foundEvent = JsonConvert.DeserializeObject<EventViewModel>(content);
                        if (foundEvent != null)
                        {
                            EventFromService = new List<EventViewModel>() { foundEvent };
                        }
                    }
                    else
                    {
                        EventFromService = JsonConvert.DeserializeObject<List<EventViewModel>>(content);
                    }
                }
                else
                {
                     if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                     {
                        EventFromService = new List<EventViewModel>();
                     }
                     else
                     {
                        EventFromService = null;
                     }
                 
                }
            }
            catch
            {
                EventFromService = null;
            }
            return EventFromService;
        }

        public async Task<int> SaveEvent(EventViewModel eventToSave)
        {
            int insertedEventId;
            //
            string useRestUrl = restUrl;
            var uri = new Uri(string.Format(useRestUrl, string.Empty));
            //
            try
            {
                var json = JsonConvert.SerializeObject(eventToSave);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _httpClient.PostAsync(uri, content);
                string resultingIdString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    Int32.TryParse(resultingIdString, out insertedEventId);
                }
                else
                {
                    insertedEventId = -2;
                }
            }
            catch
            {
                insertedEventId = -3;
            }
            return insertedEventId;
        }

        public async Task<int> DeleteEvent(EventViewModel eventToDelete)
        {

            string useRestUrl = restUrl;
            bool isValid = (eventToDelete.Id > 0);
            if (isValid)
            {
                useRestUrl += $"/{eventToDelete.Id}";
            }
            var uri = new Uri(string.Format(useRestUrl));

            try
            {
                var json = JsonConvert.SerializeObject(eventToDelete);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _httpClient.DeleteAsync(uri);

            }
            catch
            {
               eventToDelete.Id = -1;
            }
            return eventToDelete.Id;
        }

    }

}


       

    

