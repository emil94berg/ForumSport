using System.Text.Json.Serialization;

namespace ForumSport.Models
{
    public class Post
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("header")]
        public string Header { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; }
        [JsonPropertyName("imgString")]
        public string? ImgString { get; set; }
        [JsonPropertyName("postDate")]
        public DateTime PostDate { get; set; } = DateTime.Now;
        [JsonPropertyName("reported")]
        public bool Reported { get; set; } = false;



        public virtual SubCategory? SubCategory { get; set; }
        [JsonPropertyName("subCategoryId")]
        public int SubCategoryId { get; set; }


        public virtual ApplicationUser? User { get; set; }
        [JsonPropertyName("userId")]
        public string UserId { get; set; }

    }
}
