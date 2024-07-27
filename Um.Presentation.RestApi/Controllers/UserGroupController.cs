﻿using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Contracts.Commands.Role;
using UserManagement.Application.Contracts.Contracts;

namespace Um.Presentation.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupController : ControllerBase
    {
        private readonly IRoleApplication _roleApplication;

        public UserGroupController(IRoleApplication roleApplication)
        {
            _roleApplication = roleApplication;
        }

        [HttpPost("Create")]
        public void Post(CreateRole command)
        {
            _roleApplication.Create(command);
        }

        [HttpGet("GetList")]
        public List<RoleViewModel> List()
        {
            return _roleApplication.List();
        }

        [HttpGet("GetBy/{guid:guid}")]
        public EditRole GetBy(Guid guid)
        {
            return _roleApplication.GetDetails(guid);
        }

        [HttpGet("GetForCombo")]
        public IActionResult GetForCombo()
        {
            return new JsonResult(_roleApplication.GetForCombo());
        }

        [HttpPost("Edit")]
        public void Edit(EditRole command)
        {
            _roleApplication.Edit(command);
        }

        [HttpDelete("{guid:guid}")]
        public void Delete(Guid guid)
        {
            _roleApplication.Delete(guid);
        }
    }
}