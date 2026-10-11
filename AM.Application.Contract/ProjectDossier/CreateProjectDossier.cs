using PhoenixFramework.Application.Command;
using System.ComponentModel.DataAnnotations;

namespace AM.Application.Contracts.ProjectDossier;

public class CreateProjectDossier : ICommand
{
    [Required]
    public string ProjectCode { get; set; }
    [Required]
    public Guid SaleDepartmentGuid { get; set; }
    [Required]
    public Guid TaskMasterGuid { get; set; }
    [Required]
    public Guid ApplicationTypeGuid { get; set; }
    [Required]
    public Guid ProjectTypeGuid { get; set; }
    public string Description { get; set; }
}
