using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Credit_Hours_System.Api.Controllers
{
    public class ChatMessage
    {
        public string Message { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ChatBotController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ChatBotController()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer sk-proj-bZuQjE88qKlksRLJrqXOT3BlbkFJ8zCapDgUdCiDa3evgNy7");
        }

        [HttpPost]
        public async Task<ActionResult<string>> SendMessage([FromBody] ChatMessage chatMessage)
        {
            try
            {
                var requestBody = new
                {
                    prompt = chatMessage.Message,
                    max_tokens = 150
                };

                var response = await _httpClient.PostAsJsonAsync("https://api.openai.com/v1/engines/gpt-3.5-turbo/completions", requestBody);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    return BadRequest($"Error: {response.StatusCode}, Content: {errorContent}");
                }

                var responseBody = await response.Content.ReadAsStringAsync();
                var jsonResponse = JsonSerializer.Deserialize<JsonElement>(responseBody);

                return Ok(jsonResponse.GetProperty("choices")[0].GetProperty("text").GetString());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
