using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EchelonEnforcers.Models
{
    [Table("Competitions")]
    public class CompetitionsModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        public string Details { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
        
        public DateTimeOffset PublishedDate { get; set; }

        public string Author { get; set; }

        public CompetitionsModel()
        {
            DateTime = DateTime.Now;
        }
    }
}
