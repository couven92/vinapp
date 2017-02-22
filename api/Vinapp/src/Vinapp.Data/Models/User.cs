using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Vinapp.Data.Models
{
    public class User : IdentityUser
    {
        public int UserId { get; set; }

        public DateTime RowUpdated { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
