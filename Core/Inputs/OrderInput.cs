using System.Collections.Generic;
using Core.Entities;

namespace Core.Inputs
{
    public class OrderInput
    {
        public IReadOnlyList<Movies> Movies { get; set; }
        public string email { get; set; }
    }
}
