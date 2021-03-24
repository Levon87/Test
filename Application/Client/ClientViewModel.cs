using System;
using System.Collections.Generic;
using System.Text;
using Application.Order;
using Domain.Entities;

namespace Application.Client
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public List<OrderViewModel> Orders { get; set; }
    }
}
