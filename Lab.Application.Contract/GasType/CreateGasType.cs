using PhoenixFramework.Application.Command;
using System.ComponentModel.DataAnnotations;

namespace Ex.Application.Contracts.GasType
{
    public class CreateGasType : ICommand
    {
        [Required]
        public Guid GasTypeGroupGuid { get; set; }
        [Required]
        public required string Name { get; set; }
    }
}
