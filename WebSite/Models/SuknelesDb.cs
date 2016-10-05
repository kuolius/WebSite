using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MySql.Data.Entity;

namespace WebSite.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class SuknelesDb:DbContext
    {
        public SuknelesDb():base("name=SuknelesDb")
        {

        }

        public DbSet<Suknele> Sukneles { get; set; }
    }

   
}
