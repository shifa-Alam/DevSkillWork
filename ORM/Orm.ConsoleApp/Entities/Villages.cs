using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orm.ConsoleApp.Entities
{
    public class Villages : BaseEntity
    {
        public override int Id { get; set; }
        public string Name { get; set; }
        public List<Houses> houses { get; set; }
        
    }
}
