using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Model.Entities.Identity;
using Model.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Store
{
    public class RoleStore:RoleStore<Role,string,UserRole>,IQueryableRoleStore<Role>
    {
        public RoleStore():base(BaseServices.GetDbContext())
        {
            DisposeContext = true;
        }

        public RoleStore(DbContext context) : base(context)
        {

        }
    }
}
