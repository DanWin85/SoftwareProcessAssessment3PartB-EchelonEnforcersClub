using EchelonEnforcers.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace EchelonEnforcers.Models
{
    public class Competitions
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }

        public string Author { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}
