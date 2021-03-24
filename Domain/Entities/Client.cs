using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Client
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}
