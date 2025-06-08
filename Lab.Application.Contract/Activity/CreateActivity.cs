using PhoenixFramework.Application.Command;
using System.ComponentModel.DataAnnotations;

namespace Ex.Application.Contracts.Activity
{
    public class CreateActivity : ICommand
    {
        [Required]
        public required string Code { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required int Type { get; set; }

        [Required]
        public required int SubType { get; set; }
        public Guid? SourceGuid { get; set; }

        public bool IsOther { get; set; }
        public bool WithOutPersonnel { get; set; }
        public bool WithOutProject { get; set; }
        public List<Guid> SalonGuids { get; set; }
    }
}