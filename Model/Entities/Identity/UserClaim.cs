using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Model.Entities.Identity
{

    public class UserClaim : IdentityUserClaim<int>
    {
        public virtual User User { get; set; }
    }
}
