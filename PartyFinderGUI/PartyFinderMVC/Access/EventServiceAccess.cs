using PartyFinderMVC.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PartyFinderMVC.Models;

namespace PartyFinderMVC.Access
{

    public class EventServiceAccess
    {

        static readonly string restUrl = "http://localhost:44377/api/event";
        readonly HttpClient _httpClient;

        public EventServiceAccess()
        {
            _httpClient = new HttpClient();
        }

        // Method to retrieve Event(s)
        public async Task<List<EventViewModel>> GetEvent(int id = -1)
        {
            List<EventViewModel> EventFromService = null;

            // api/event/{id}
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
    }
}

    

