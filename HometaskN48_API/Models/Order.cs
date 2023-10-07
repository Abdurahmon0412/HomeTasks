using FileBaseContext.Abstractions.Models.Entity;
using FileBaseContext.Abstractions.Models.FileSet;

namespace HometaskN48_API.Models
{
    public class Order : IFileSetEntity<Guid>
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; } 
        public Guid UserId { get; set; }
    }
}
