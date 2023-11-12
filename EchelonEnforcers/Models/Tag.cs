using System.Reflection.Metadata.Ecma335;

namespace EchelonEnforcers.Models.Domain
{
    public class Tag
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }


        public ICollection<News> News { get; set; }
    }
}
