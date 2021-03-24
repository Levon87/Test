using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Application.Client.FindClient
{
    public class FindClientQuery : IRequest<ClientViewModel>
    {
        public string PhoneNumber { get; set; }
    }
}
