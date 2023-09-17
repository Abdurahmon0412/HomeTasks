namespace Lesson38_Bogus.Models
{
    public class BlogPost
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }

        public override string ToString()
        {
            return $"{Title} {Content} {PublishDate}";
        }
    }
}
