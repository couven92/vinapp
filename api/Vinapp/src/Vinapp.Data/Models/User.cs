using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Vinapp.Data.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime RowUpdated { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
