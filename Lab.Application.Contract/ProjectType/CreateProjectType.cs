using PhoenixFramework.Application.Command;
using System.ComponentModel.DataAnnotations;

namespace Ex.Application.Contracts.ProjectType
{
    public class CreateProjectType : ICommand
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public Guid SalonGuid { get; set; }
    }
}
