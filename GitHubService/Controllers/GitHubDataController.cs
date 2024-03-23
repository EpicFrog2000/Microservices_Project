using Microsoft.AspNetCore.Mvc;

namespace GitHubService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GitHubDataController : ControllerBase
    {
        private readonly ILogger<GitHubDataController> _logger;
        public GitHubDataController(ILogger<GitHubDataController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            string apiUrl = $"https://api.github.com/users/EpicFrog2000/repos";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Awesome-Octocat-App");

                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        return responseData;
                    }
                    else
                    {
                        Console.WriteLine($"Failed to retrieve user repositories. Status code: {response.StatusCode}");
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return null;
                }
            }
        }
    }
}