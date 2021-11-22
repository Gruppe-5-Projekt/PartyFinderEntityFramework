using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartyFinderClient.ModelLayer;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace PartyFinderClient.ServiceLayer
{
    public class EventServiceAccess
    {

        static readonly string restUrl = "https://localhost:7235/api/event";
        readonly HttpClient _httpClient;

        public EventServiceAccess()
        {
            _httpClient = new HttpClient();
        }
        // Method to retrieve Event(s)
        public async Task<List<Event>> GetEvents(int id = -1)
        {
            List<Event> EventFromService = null;

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

                        Event foundEvent = JsonConvert.DeserializeObject<Event>(content);
                        if (foundEvent != null)
                        {
                            EventFromService = new List<Event>() { foundEvent };
                        }
                    }
                    else
                    {
                        EventFromService = JsonConvert.DeserializeObject<List<Event>>(content);
                    }
                }
                else
                {
                     if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                     {
                        EventFromService = new List<Event>();
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

        public async Task<int> SaveEvent(Event eventToSave)
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

        public async Task<int> DeleteEvent(Event eventToDelete)
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


       

    

