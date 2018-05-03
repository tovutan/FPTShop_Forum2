using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services
{
    public class BaseServices
    {
        private static ApplicationDbContext _dbContext;
        public static ApplicationDbContext GetDbContext()
        {
            if (_dbContext == null)
            {
                lock (typeof(ApplicationDbContext))
                {
                    _dbContext = new ApplicationDbContext();
                }
            }
            return _dbContext;
        }

        protected internal ApplicationDbContext _db => GetDbContext();
    }
}
