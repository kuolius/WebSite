using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WebSite.Models
{
    public class SuknelesInitializer : DropCreateDatabaseAlways<SuknelesDb>
    {
        protected override void Seed(SuknelesDb context)
        {
            context.Sukneles.Add(new Suknele { name = "shlegoit", age = 10, id = 1, genger = Genger.female, price = 13 });
            context.Sukneles.Add(new Suknele { name = "lego", age = 10, id = 1, genger = Genger.female, price = 59 });
            context.Sukneles.Add(new Suknele { name = "ninlegoja", age = 10, id = 1, genger = Genger.female, price = 1.50m });
            context.Sukneles.Add(new Suknele { name = "Rektlego", age = 10, id = 1, genger = Genger.female, price = 0.20m });
            context.Sukneles.Add(new Suknele { name = "legoninja", age = 10, id = 1, genger = Genger.female, price = 2 });

            base.Seed(context);
        }
    }
}

