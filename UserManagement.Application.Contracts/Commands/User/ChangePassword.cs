﻿namespace UserManagement.Application.Contracts.Commands.User
{
    public class ChangePassword
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
}
