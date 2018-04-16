using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Mapping
{
    public class LogMap:BaseMap<Log>
    {
        public LogMap()
        {
            this.ToTable("Log");

            this.Property(e => e.CreateDate).IsRequired();
            this.HasRequired(e => e.CreateUser).WithMany().HasForeignKey(e => e.CreateBy).WillCascadeOnDelete(false);
        }
    }
}
