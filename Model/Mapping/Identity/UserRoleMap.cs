using Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Mapping.Identity
{
    public partial class UserRoleMap:BaseMap<UserRole>
    {
        public UserRoleMap()
        {
            this.ToTable("UserRole");
            this.HasKey(u => new { u.UserId, u.RoleId });
        }
    }
}
