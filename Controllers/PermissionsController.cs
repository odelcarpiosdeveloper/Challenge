using WebApiChallengeCQRS.Commands;
using WebApiChallengeCQRS.Models;
using WebApiChallengeCQRS.Queries;
using WebApiChallengeCQRS.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApiChallengeCQRS.KafkaServices;

namespace WebApiChallengeCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        ProducerService producer = new ProducerService();
        string input = string.Empty;
        Guid gId = Guid.NewGuid();
        public readonly string[] operation = { "Request", "Modify", "Get" };

        private readonly IMediator mediator;

        public PermissionsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Permissions>> GetStudentListAsync()
        {
            var permissions = await mediator.Send(new GetPermissionsListQuery());
            var message = $"Id: {gId}; operation : {operation[2]}; date : {DateTime.Now.ToString()}" ?? input;
            producer.SendMessage(message);
            return permissions;
        }

        [HttpGet("permissionId")]
        public async Task<Permissions> GetPermissionsByIdAsync(int permissionId)
        {
            var permissions = await mediator.Send(new GetPermissionsByIdQuery() { Id = permissionId });
            var message = $"Id: {gId}; operation : {operation[2]}; date : {DateTime.Now.ToString()}" ?? input;
            producer.SendMessage(message);
            return permissions;
        }

        [HttpPost]
        public async Task<Permissions> AddStudentAsync(Permissions permissions)
        {
            var permission = await mediator.Send(new CreatePermissionsCommand(
                permissions.EmployeeForename,
                permissions.EmployeeSurname,
                permissions.PermissionType,
                permissions.PermissionDate));
            var message = $"Id: {gId}; operation : {operation[0]}; date : {DateTime.Now.ToString()}" ?? input;
            producer.SendMessage(message);
            return permission;
        }

        [HttpPut]
        public async Task<int> UpdateStudentAsync(Permissions permissions)
        {
            var permissionsUpdated = await mediator.Send(new UpdatePermissionsCommand(
               permissions.Id,
               permissions.EmployeeForename,
               permissions.EmployeeSurname,
               permissions.PermissionType,
               permissions.PermissionDate));
            var message = $"Id: {gId}; operation : {operation[1]}; date : {DateTime.Now.ToString()}" ?? input;
            producer.SendMessage(message);
            return permissionsUpdated;
        }
    }
}
