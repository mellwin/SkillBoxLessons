using WebUI.Models;

namespace WebUI.Services
{
    public class PhoneContactService
    {
        private readonly HttpClient _httpClient;

        public PhoneContactService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("WebApiClient");
        }

        public async Task<List<PhoneContact>> GetAllContactsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<PhoneContact>>("PhoneContacts");
            return response ?? new List<PhoneContact>();
        }

        public async Task<PhoneContact> GetContactByIdAsync(Guid id)
        {
            var response = await _httpClient.GetFromJsonAsync<PhoneContact>($"PhoneContacts/{id}");
            return response ?? new PhoneContact();
        }

        public async Task AddContactAsync(PhoneContact contact)
        {
            await _httpClient.PostAsJsonAsync("PhoneContacts", contact);
        }

        public async Task UpdateContactAsync(PhoneContact contact)
        {
            await _httpClient.PutAsJsonAsync($"PhoneContacts/{contact.Id}", contact);
        }

        public async Task DeleteContactAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"PhoneContacts/{id}");
        }
    }
}
