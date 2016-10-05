using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.Entity;
using System.Data.Entity;

namespace WebSite.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
   public class Orders:DbContext
    {
        public Orders():base("Name=Orders")
            {

            }

        public DbSet<Models.Order> orders { get; set; }
    }
}
