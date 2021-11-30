using Newtonsoft.Json;
using PartyFinderWEB.Models;
using System.Text;

namespace PartyFinderWEB.ServiceLayer
{
    public class MatchServiceAccess
    {
        static readonly string restUrl = "https://localhost:44377/api/match";
        readonly HttpClient _httpClient;

        public MatchServiceAccess()
        {
            _httpClient = new HttpClient();
        }

        /*public async Task<List<MatchViewModel>> GetEvents(int id = -1)
        {
            List<MatchViewModel> EventFromService = null;

            // api/events/{specificevent}
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
                            EventFromService = new List<MatchViewModel>() { foundEvent };
                        }
                    }
                    else
                    {
                        EventFromService = JsonConvert.DeserializeObject<List<MatchViewModel>>(content);
                    }
                }
                else
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        EventFromService = new List<MatchViewModel>();
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
        }*/

        public async Task<MatchViewModel> GetEvent(string specificEvent)
        {
            MatchViewModel EventFromService = null;

            // api/events/{specificevent}
            string useRestUrl = restUrl;
            bool hasValidString = (specificEvent != null);
            if (hasValidString)
            {
                useRestUrl += specificEvent;
            }
            var uri = new Uri(string.Format(useRestUrl));
            try
            {
                var response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (hasValidString)
                    {

                        MatchViewModel foundEvent = JsonConvert.DeserializeObject<MatchViewModel>(content);
                    }
                }
                else
                {
                    EventFromService = null;
                }
            }
            catch
            {
                EventFromService = null;
            }
            return EventFromService;
        }

        public async Task<int> LikeOrDislike(MatchViewModel matchToSave)
        {
            int insertedMatchId;
            //
            string useRestUrl = restUrl;
            var uri = new Uri(string.Format(useRestUrl, string.Empty));
            //
            try
            {
                var json = JsonConvert.SerializeObject(matchToSave);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _httpClient.PostAsync(uri, content);
                string resultingIdString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    Int32.TryParse(resultingIdString, out insertedMatchId);
                }
                else
                {
                    insertedMatchId = -2;
                }
            }
            catch
            {
                insertedMatchId = -3;
            }
            return insertedMatchId;
        }
    }
}
