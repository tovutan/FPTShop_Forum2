using Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services.Web
{
    public class UserServices:BaseServices
    {
        private static volatile UserServices _userServices;
        public static UserServices GetInstance()
        {
            if (_userServices == null)
            {
                lock (typeof(UserServices))
                {
                    _userServices = new UserServices();
                }
            }
            return _userServices;
        }

        // lấy ra danh sách những user ko bị xóa
        private IQueryable<User> _DefaultListUser
        {
            get
                {
                return _db.Users.Where(u => !u.IsDeleted);
            }
          
        }

        // lấy ra User theo Email 
        public User GetUserByEmail(string email)
        {
            var _return = _DefaultListUser.FirstOrDefault(u => u.Email == email);
            return _return;
        }

        // lấy theo Id
        public User GetUser(int id)
        {
            var _return = _db.Users.FirstOrDefault(u => u.Id == id);
            return _return;
        }

       

    }
}
