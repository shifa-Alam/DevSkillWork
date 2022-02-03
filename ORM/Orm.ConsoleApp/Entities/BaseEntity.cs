using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orm.ConsoleApp.Entities
{
    public abstract class BaseEntity
    {
        public abstract int Id { get; set; }
    }
}
