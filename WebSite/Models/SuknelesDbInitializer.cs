using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WebSite.Models
{
    class SuknelesDbInitializer:DropCreateDatabaseAlways<SuknelesDbContext>
    {
        protected override void Seed(SuknelesDbContext context)
        {
            context.Sukneles.Add(new Suknele { name = "shit", age = 10, id = 1, genger = Genger.female, price = 120 });

            base.Seed(context);
        }
    }
}
