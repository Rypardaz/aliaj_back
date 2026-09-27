using System.ComponentModel.DataAnnotations;
using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.Personnel;

public class CreatePersonnel : ICommand
{
    [Required]
    public required string Code { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Family { get; set; }

    public string? NationalCode { get; set; }
    public Guid SalonGuid { get; set; }
}