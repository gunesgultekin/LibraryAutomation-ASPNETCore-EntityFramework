using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public class Roles
    {
        public int id { get; set; }
        public string name { get; set; }
        public virtual List<Users>? usersList { get; set; }
    }
}
