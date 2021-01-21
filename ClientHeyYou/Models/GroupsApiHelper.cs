using System.Threading.Tasks;
using RestSharp;

namespace ClientHeyYou.Models
{
    class GroupsApiHelper
    {
        public static async Task<string> GetAll()
        {
            RestClient client = new RestClient("http://localhost:5001/api");
            RestRequest request = new RestRequest($"groups", Method.GET);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }
        public static async Task<string> Get(int id)
        {
            RestClient client = new RestClient("http://localhost:5001/api");
            RestRequest request = new RestRequest($"groups/{id}", Method.GET);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }
        public static async Task Post(string newGroup)
        {
            RestClient client = new RestClient("http://localhost:5001/api");
            RestRequest request = new RestRequest($"groups", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(newGroup);
            var response = await client.ExecuteTaskAsync(request);
        }
        public static async Task Put(int id, string newGroup)
        {
            RestClient client = new RestClient("http://localhost:5001/api");
            RestRequest request = new RestRequest($"groups/{id}", Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(newGroup);
            var response = await client.ExecuteTaskAsync(request);
        }
        public static async Task Delete(int id)
        {
            RestClient client = new RestClient("http://localhost:5001/api");
            RestRequest request = new RestRequest($"groups/{id}", Method.DELETE);
            request.AddHeader("Content-Type", "application/json");
            var response = await client.ExecuteTaskAsync(request);
        }
    }
}