using Model.Entities;
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
        public long  InsertForFacebook(Customer cus)
        {
            var customer = _db.Customers.FirstOrDefault(c => c.Email == cus.Email);
            if (customer == null)
            {
                _db.Customers.Add(cus);
                _db.SaveChanges();
                return cus.ID.Length;
            }
            else
            {
                return customer.ID.Length;
            }
        }
    }
}
