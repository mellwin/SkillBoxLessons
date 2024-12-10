using System.Net.Http;
using System.Text;
using System.Text.Json;
using WpfApp.Models;
using Newtonsoft.Json;

namespace WpfApp
{
    public class ContactsDataApi
    {
        private HttpClient _httpClient { get; set; }

        public ContactsDataApi()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<PhoneContact>> GetContacts()
        {
            string url = @"https://localhost:7251/api/phonecontact";

            var json = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<List<PhoneContact>>(json);

        }

        public async Task AddContact(PhoneContact contact)
        {
            string url = @"https://localhost:7251/api/phonecontact";

            var r = _httpClient.PostAsync(
                requestUri: url,
                content: new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8,
                mediaType: "application/json")
                ).Result;
        }
    }
}
