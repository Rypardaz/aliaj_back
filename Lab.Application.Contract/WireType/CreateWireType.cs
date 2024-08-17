using PhoenixFramework.Application.Command;
using System.ComponentModel.DataAnnotations;

namespace Ex.Application.Contracts.WireType
{
    public class CreateWireType : ICommand
    {
        [Required]
        public Guid WireTypeGroupGuid { get; set; }
        [Required]
        public required string Name { get; set; }

        public decimal? WireSize { get; set; }

        public Guid? SourceGuid { get; set; }
    }
}