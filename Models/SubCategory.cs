namespace ForumSport.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
