using PhoenixFramework.Application.Command;
using System.ComponentModel.DataAnnotations;

namespace Ex.Application.Contracts.PowderTypeGroup
{
    public class CreatePowderTypeGroup : ICommand
    {
        [Required]
        public required string Name { get; set; }
    }

}
