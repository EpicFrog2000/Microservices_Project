using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace GitHubService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GitHubDataController : ControllerBase
    {
        private readonly ILogger<GitHubDataController> _logger;
        private readonly string _filePath;

        public GitHubDataController(ILogger<GitHubDataController> logger, string filePath = "GitHubData.json")
        {
            _logger = logger;
            _filePath = Path.Combine(Directory.GetCurrentDirectory(), filePath);
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            try
            {
                if (!System.IO.File.Exists(_filePath))
                {
                    Console.WriteLine($"GitHubData file not found at path: {_filePath}");
                    return NotFound();
                }

                string fileContent = System.IO.File.ReadAllText(_filePath);
                return fileContent;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading GitHubData file: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("update")]
        public async Task<ActionResult> UpdateJSONAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Awesome-Octocat-App");
                try
                {
                    HttpResponseMessage response = await client.GetAsync("https://api.github.com/users/EpicFrog2000/repos");

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        await System.IO.File.WriteAllTextAsync(_filePath, jsonData).ConfigureAwait(false);
                        Console.WriteLine($"Success! Data saved to {_filePath}");
                        return Ok();
                    }
                    else
                    {
                        Console.WriteLine($"Failed to retrieve user repositories. Status code: {response.StatusCode}");
                        return BadRequest();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return BadRequest();
                }
            }
        }
    }
}
