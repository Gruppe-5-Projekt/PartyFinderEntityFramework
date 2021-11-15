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
            /*public async Task<List<EventViewModel>> GetEvents(int id = -1)
            {
                return null;
            }*/

            /*public async Task<int> SaveEvent(EventViewModel eventToSave)
            {
            var postTask = _httpClient.PostAsJsonAsync<EventViewModel>(eventToSave);
            postTask.Wait();
            return 0;
        }*/
        }
    }
    

