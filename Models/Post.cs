namespace ForumSport.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public string? ImgString { get; set; }
        public DateTime PostDate { get; set; } = DateTime.Now;
        //public bool Reported { get; set; } = false;

        public virtual SubCategory? SubCategory { get; set; }
        public int SubCategoryId { get; set; }


        public virtual ApplicationUser? User { get; set; }
        public string UserId { get; set; }

    }
}
