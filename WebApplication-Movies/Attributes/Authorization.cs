using System;
using System.ComponentModel;

namespace WebApplication_Movies.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class AuthorizationAttribute : Attribute
    {
        public string Role { get; }

        public AuthorizationAttribute(string role)
        {
            Role = role;
        }
    }
}
