namespace EchelonEnforcers.Models
{
    public class NewsModel
    {
        public Guid Id { get; set; }
        public string Heading { get; set; }

        public string Content { get; set; }

        public DateTimeOffset PublishedDate { get; set; }

        public string Author { get; set; }

        public bool Visible { get; set; }

        

    }
}
