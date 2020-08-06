using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Users : BaseEntity
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public byte[] PassHash { get; set; }
        public byte[] PassSalt { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
    }
}
