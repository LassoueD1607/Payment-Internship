using PaymentInternship.Models;

namespace E_commerce.Models
{
    public class Response
    {
        public string ResponseMessage { get; set; } 
    }
    class PostHttpResponse
    {
        private readonly HttpClient _httpClient;
        public PostHttpResponse(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Response>> AllPosts()
        {
            return await _httpClient.GetFromJsonAsync<List<Response>>("Response");
        }
        public async Task<List<GenerateTransactionId>> AllTransactions()
        {
            return await _httpClient.GetFromJsonAsync<List<GenerateTransactionId>>("GenerateTransactionId");
        }
    }
}
