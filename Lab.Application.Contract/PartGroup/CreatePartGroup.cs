using PhoenixFramework.Application.Command;
using System.ComponentModel.DataAnnotations;

namespace Ex.Application.Contracts.PartGroup
{
    public class CreatePartGroup : ICommand
    {
        [Required]
        public required string Name { get; set; }

        public Guid SalonGuid { get; set; }
    }
}
