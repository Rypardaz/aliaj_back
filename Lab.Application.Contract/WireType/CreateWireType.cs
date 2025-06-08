using PhoenixFramework.Application.Command;
using System.ComponentModel.DataAnnotations;

namespace Ex.Application.Contracts.WireType
{
    public class CreateWireType : ICommand
    {
        [Required]
        public Guid WireTypeGroupGuid { get; set; }
        public string Code { get; set; }
        [Required]
        public required string Name { get; set; }

        public decimal? WireSize { get; set; }
    }
}