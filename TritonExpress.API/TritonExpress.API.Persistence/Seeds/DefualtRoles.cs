using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonExpress.API.Domain.Entities;

namespace TritonExpress.API.Persistence.Seeds
{
    public static class DefualtRoles
    {
        public static List<Microsoft.AspNetCore.Identity.IdentityRole> IdentityRoleList()
        {
            return new List<Microsoft.AspNetCore.Identity.IdentityRole>() 
            {
                new Microsoft.AspNetCore.Identity.IdentityRole{Id = "1",Name = "Admin"},
                new Microsoft.AspNetCore.Identity.IdentityRole{Id = "2",Name = "User"},

            };
        }
    }
}
