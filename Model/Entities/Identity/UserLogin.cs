using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Model.Entities.Identity
{
 
    public class UserLogin : IdentityUserLogin<string>
    {
        public virtual User User { get; set; }
    }
}
