using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DockerLearning.Scripts
{
    public class GithubDataRetriever
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static async Task<string> GetData()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("http://githubservicecontainer/githubdata");

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    return responseData;
                }
                else
                {
                    Console.WriteLine($"Failed to retrieve data. Status code: {response.StatusCode}");
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP request error: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        // Dispose HttpClient when it's no longer needed
        public static void DisposeHttpClient()
        {
            _httpClient.Dispose();
        }
    }
}
