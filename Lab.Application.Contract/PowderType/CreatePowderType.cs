using PhoenixFramework.Application.Command;
using System.ComponentModel.DataAnnotations;

namespace Ex.Application.Contracts.PowderType
{
    public class CreatePowderType : ICommand
    {
        [Required]
        public Guid PowderTypeGroupGuid { get; set; }
        [Required]
        public required string Name { get; set; }
    }
}
