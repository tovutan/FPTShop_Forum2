using Microsoft.AspNet.Identity;
using Model.Entities.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Model.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Store
{
    public class UserStore:UserStore<User,Role,string, UserLogin, UserRole, UserClaim>,IUserStore<User>
    {
        public UserStore():this(BaseServices.GetDbContext())
        {
            DisposeContext = true;
        }

        public UserStore(DbContext context):base(context)
        {

        }
    }
}
