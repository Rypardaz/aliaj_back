using PhoenixFramework.Application.Command;
using System.ComponentModel.DataAnnotations;

namespace Ex.Application.Contracts.GasTypeGroup
{
    public class CreateGasTypeGroup : ICommand
    {
        [Required]
        public required string Name { get; set; }
    }
}
