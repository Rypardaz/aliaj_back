using PhoenixFramework.Application.Command;
using System.ComponentModel.DataAnnotations;

namespace Ex.Application.Contracts.WireTypeGroup
{
    public class CreateWireTypeGroup : ICommand
    {
        [Required]
        public required string Name { get; set; }
    }

}
