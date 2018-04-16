using Microsoft.AspNet.Identity.EntityFramework;
using Model.Entities.Identity;
using System;

namespace Model.Entities.Identity
{

    public class Role : IdentityRole<string, UserRole>
    {
        public Role() : base()
        {
            Id = Guid.NewGuid().ToString();
        }

        public Role(string roleName) : this()
        {
            Name = roleName;
        }
    }

    public class RoleType
    {
        public const string Admin = "Admin";
        public const string Manager = "Manager";
        public const string User = "User";
    }
}
