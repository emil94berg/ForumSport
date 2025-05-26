using System.Text.Json;
using System.Text.Json.Serialization;

namespace ForumSport.DAL
{
    public class PostAPIManager
    {
        private static Uri BaseAddress = new Uri("https://localhost:44361/");

        public static async Task<List<Models.Post>> GetPostsAsync()
        {
            List<Models.Post> posts = new List<Models.Post>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseAddress;
                HttpResponseMessage response = await client.GetAsync("api/PostDto");
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    posts = JsonSerializer.Deserialize<List<Models.Post>>(responseString);
                }
                return posts;
            }

        }






    }
}
