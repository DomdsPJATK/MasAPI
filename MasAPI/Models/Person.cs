using System;
using System.Net.Sockets;

namespace MasAPI.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        public Address Address { get; set; }
        public int AddressId { get; set; }
    }
}