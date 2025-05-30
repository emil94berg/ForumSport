using System.Text.Json;

namespace ForumSport.DAL
{
    public class ChatManagerAPI
    {
        private static Uri BaseAddress = new Uri("https://localhost:44361/");

        public static async Task PostChatAsync(Models.Chat chat)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseAddress;
                var json = JsonSerializer.Serialize(chat);
                StringContent HttpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("api/ChatDto", HttpContent);
            }
        }
    }
}
