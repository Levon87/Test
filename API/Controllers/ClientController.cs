using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Client;
using Application.Client.FindClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace API.Controllers
{
    public class ClientController : BaseController
    {
        [HttpGet("findclient")]
        [AllowAnonymous]
        public Task<ClientViewModel> FindClient([FromQuery] FindClientQuery query) => Mediator.Send(query);
    }
}
