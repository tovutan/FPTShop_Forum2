using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Model.Entities.Identity
{

    public class UserClaim : IdentityUserClaim<string>
    {
        public virtual User User { get; set; }
    }
}
