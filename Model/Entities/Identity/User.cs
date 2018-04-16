
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Model.Entities.Identity
{

    public class User : IdentityUser<string, UserLogin, UserRole, UserClaim>
    {
        #region Constructor
        public User() : base()
        {
            Id = Guid.NewGuid().ToString();
        }
        public User(string userName) : this()
        {
            UserName = userName;
        }
        #endregion

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie).ConfigureAwait(false);
            // Add custom user claims here
            return userIdentity;
        }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        #region Log
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual string CreateBy { get; set; }
        public virtual User CreateUser { get; set; }

        public virtual string UpdateBy { get; set; }
        public virtual User UpdateUser { get; set; }
        #endregion


        #region User Info
        public string FullName { get; set; }
        public string ImageURL { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        #endregion
    }
}