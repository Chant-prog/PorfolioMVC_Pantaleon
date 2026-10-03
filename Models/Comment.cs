namespace ModernPortfolio.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public string Name { get; set; } = "";

        public string Message { get; set; } = "";

        public DateTime DatePosted { get; set; } = DateTime.Now;
    }
}