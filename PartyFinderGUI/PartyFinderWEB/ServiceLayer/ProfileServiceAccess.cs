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
    public class ProfileServiceAccess
    {

        static readonly string restUrl = "https://localhost:44377/api/profile";
        readonly HttpClient _httpClient;

        public ProfileServiceAccess()
        {
            _httpClient = new HttpClient();
        }
        // Method to retrieve Profile(s)
        public async Task<List<ProfileViewModel>> GetProfiles(int id = -1)
        {
            List<ProfileViewModel> ProfileFromService = null;

            // api/profiles/{id}
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

                        ProfileViewModel foundProfile = JsonConvert.DeserializeObject<ProfileViewModel>(content);
                        if (foundProfile != null)
                        {
                            ProfileFromService = new List<ProfileViewModel>() { foundProfile };
                        }
                    }
                    else
                    {
                        ProfileFromService = JsonConvert.DeserializeObject<List<ProfileViewModel>>(content);
                    }
                }
                else
                {
                     if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                     {
                        ProfileFromService = new List<ProfileViewModel>();
                     }
                     else
                     {
                        ProfileFromService = null;
                     }
                 
                }
            }
            catch
            {
                ProfileFromService = null;
            }
            return ProfileFromService;
        }

        public async Task<int> SaveProfile(ProfileViewModel profileToSave)
        {
            int insertedProfileId;
            //
            string useRestUrl = restUrl;
            var uri = new Uri(string.Format(useRestUrl, string.Empty));
            //
            try
            {
                var json = JsonConvert.SerializeObject(profileToSave);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _httpClient.PostAsync(uri, content);
                string resultingIdString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    Int32.TryParse(resultingIdString, out insertedProfileId);
                }
                else
                {
                    insertedProfileId = -2;
                }
            }
            catch
            {
                insertedProfileId = -3;
            }
            return insertedProfileId;
        }

        public async Task<int> DeleteProfile(ProfileViewModel profileToDelete)
        {

            string useRestUrl = restUrl;
            bool isValid = (profileToDelete.Id > 0);
            if (isValid)
            {
                useRestUrl += $"/{profileToDelete.Id}";
            }
            var uri = new Uri(string.Format(useRestUrl));

            try
            {
                var json = JsonConvert.SerializeObject(profileToDelete);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _httpClient.DeleteAsync(uri);

            }
            catch
            {
               profileToDelete.Id = -1;
            }
            return profileToDelete.Id;
        }


    }

}


       

    

