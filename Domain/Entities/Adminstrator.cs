using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Adminstrator:Entity
    {
        public string Name { get; set; }
        public Adminstrator()
        {

        }
        public Adminstrator(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}
