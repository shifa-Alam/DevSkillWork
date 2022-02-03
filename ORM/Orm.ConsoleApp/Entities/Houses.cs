using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orm.ConsoleApp.Entities
{
    public class Houses:BaseEntity
    {
        public List<Rooms> Rooms { get; set; }
        public override int Id { get ; set; }
    }
}
