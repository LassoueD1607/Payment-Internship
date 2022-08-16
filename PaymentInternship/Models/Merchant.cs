using System.ComponentModel.DataAnnotations;

namespace PaymentInternship.Models
{
    public class Merchant
    {
        public string IdMerchant { get; set; }
    }
    class PostHttpClient
    {
        private readonly HttpClient _httpClient;
        public PostHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Merchant>> AllPosts()
        {
            return await _httpClient.GetFromJsonAsync<List<Merchant>>("Merchant");
        }
    }
}
