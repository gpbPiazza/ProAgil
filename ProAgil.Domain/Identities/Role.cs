using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ProAgil.Domain.Identities
{
    public class Role: IdentityRole<int>
    {
			public List<UserRole> UserRoles { get; set; }
    }
}