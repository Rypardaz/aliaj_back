using System.ComponentModel.DataAnnotations;
using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.TaskMaster;

public class CreateTaskMaster : ICommand
{
    [Required]
    public required string Name { get; set; }
}