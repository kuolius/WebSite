using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSite.Models
{
   public enum Genger { male,female}

   public class Suknele
    {
        public int id { get; set; }
        public string name { get; set; }
        public Genger genger { get; set; }
        public decimal price { get; set; }
        public int age { get; set; }  

    }
}
