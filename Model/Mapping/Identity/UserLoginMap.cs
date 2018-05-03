using Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Mapping.Identity
{
    public partial class UserLoginMap:BaseMap<UserLogin>
    {
        public UserLoginMap()
        {
            this.ToTable("UserLogin");
            this.HasKey(l => new { l.UserId, l.ProviderKey, l.LoginProvider });
        }
    }
}
