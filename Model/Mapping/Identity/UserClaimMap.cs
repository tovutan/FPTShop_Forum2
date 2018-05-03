using Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Mapping.Identity
{
    public partial class UserClaimMap:BaseMap<UserClaim>
    {
        public UserClaimMap()
        {
            this.ToTable("UserClaim");
            this.HasKey(uc => uc.Id);
        }
    }
}
