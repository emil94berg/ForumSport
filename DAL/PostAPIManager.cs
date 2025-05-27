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
        public static async Task<List<Models.Post>> GetPostsForUserAsync(string userId) //8dd98152-7057-4d08-9e8f-6d5dfc5c7d26
        {
            List<Models.Post> userPosts = new List<Models.Post>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseAddress;
                HttpResponseMessage response = await client.GetAsync("api/PostDto/" + userId);
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    userPosts = JsonSerializer.Deserialize<List<Models.Post>>(responseString);
                }
                return userPosts;

               
            }
        }






    }
}
