﻿using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orm.ConsoleApp.Entities
{
    public class Houses:BaseEntity
    {
        public override int Id { get; set; }
        public string Name { get; set; }
        public List<Rooms> Rooms { get; set; }
        public int VillageId { get; set; }

    }
}
