using Microsoft.AspNet.Identity.EntityFramework;
using Model.Entities.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Entities.Identity
{

    public class Role : IdentityRole<int, UserRole>
    {
        public Role() : base()
        {
            Id = Int32.Parse(Guid.NewGuid().ToString());
                 
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
