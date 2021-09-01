using System;
using System.Collections.Generic;

#nullable disable

namespace TZASPART
{
    public partial class User
    {
        public int Id { get; set; }
        public string Fio { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}
