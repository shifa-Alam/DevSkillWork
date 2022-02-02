using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orm.ConsoleApp.Entities
{
    public class Rooms : BaseEntity
    {
        public int HouseId { get; set; }
        public double Rent { get; set; }

    }
}
