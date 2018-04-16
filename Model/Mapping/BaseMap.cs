using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Mapping
{
    public class BaseMap<T> : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<T> where T:class
    {
        protected BaseMap()
        {
            PostInitialize();
        }

        protected virtual void PostInitialize()
        {

        }
    }
}
