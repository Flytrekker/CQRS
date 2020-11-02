using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiDB.Application.Command;
using MultiDB.Application.Queries;
using MultiDB.Database;
using MultiDB.MSSQLDatabase;
using MultiDB.MySQLDatabase;

namespace MultiDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultiDBController : ControllerBase
    {
        private List<IApplicationDBContext> applicationDBContexts;
        private IMediator _mediator;
        public MultiDBController(IMSSQLApplicationDBContext mssql, IMySQLApplicationDBContext mysql, IMediator mediator)
        {
            applicationDBContexts = new List<IApplicationDBContext>
            {
                mysql,
                mssql
            };
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()  
        {
            var result = await _mediator.Send(new GetProfilesQuery());
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(AddProfileCommand req)
        {
            var result = await _mediator.Send(req);          
            return Ok(result);
        }
    }
}
