using PhoenixFramework.Application.Command;
using System;
using System.Collections.Generic;

namespace UserManagement.Application.Contracts.Commands.User
{
    public class CreateUser : ICommand
    {
        public List<Guid> RoleGuids { get; set; }
        public string Username { get; set; }
        public string NationalCode { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string Mobile { get; set; }
        public string? Email { get; set; }
        public string Fullname { get; set; }
        public string EmployeeCode { get; set; }
    }
}