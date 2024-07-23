namespace MyApp.Models
{
    public class Post
    {
     public int Id { get; set; }
        public string PostId { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedTime { get; set; }
        public int FbId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Applied { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; } = default!;
    }
}
