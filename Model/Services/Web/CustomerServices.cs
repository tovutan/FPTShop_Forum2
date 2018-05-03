using Model.Entities;
using Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services.Web
{
    public class CustomerServices:BaseServices
    {
        private static volatile CustomerServices _customerServices;
        public static CustomerServices GetInstance()
        {
            if (_customerServices == null)
            {
                lock (typeof(CustomerServices))
                {
                    _customerServices = new CustomerServices();
                }
            }
            return _customerServices;
        }


        // tìm nếu ko có thì add 
        public long  InsertForFacebook(User cus)
        {
            var customer = _db.Users.FirstOrDefault(c => c.Email == cus.Email);
            if (customer == null)
            {
                _db.Users.Add(cus);
                _db.SaveChanges();
                return cus.Id;
            }
            else
            {
                //return customer.ID.Length;
                return customer.Id;
            }
        }
    }
}
