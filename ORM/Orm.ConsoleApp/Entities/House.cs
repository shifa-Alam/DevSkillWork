using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orm.ConsoleApp.Entities
{
    public class House:BaseEntity
    {
        public List<Room> Rooms { get; set; }

    }
}
