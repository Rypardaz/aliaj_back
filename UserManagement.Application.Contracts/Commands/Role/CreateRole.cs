using System.Collections.Generic;

namespace UserManagement.Application.Contracts.Commands.Role
{
    public class CreateRole
    {
        public string Title { get; set; }
        public List<int> Permissions { get; set; }
    }
}