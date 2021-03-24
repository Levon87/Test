using Application.Exceptions;
using Application.Order;
using AutoMapper;
using EFData;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Client.FindClient
{
	public class FindClientHandler : IRequestHandler<FindClientQuery, ClientViewModel>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public FindClientHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ClientViewModel> Handle(FindClientQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new RestException(HttpStatusCode.BadRequest, new { Email = "Query is empty" });
            }

            var client = _context.Clients.FirstOrDefault(x => x.Phone == request.PhoneNumber);

            if (client == null)
            {
                throw new RestException(HttpStatusCode.BadRequest, new { Email = "Not found client" });
            }

            var clientViewModel = _mapper.Map<Domain.Entities.Client, ClientViewModel>(client);
            var orders = _context.Orders.Where(x => x.Client.Id == client.Id).ToList();
            var orderViewModel = new List<OrderViewModel>();

            if (orders.Any())
            {
                orderViewModel = _mapper.Map<List<Domain.Entities.Order>, List<OrderViewModel>>(orders);
            }

            clientViewModel.Orders = orderViewModel;
           
            return clientViewModel;
        }
    }
}
