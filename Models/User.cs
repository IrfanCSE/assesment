using System;
using System.Collections.Generic;

namespace primetechmvc.Models
{
    public partial class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool? IsActive { get; set; }
    }
}
