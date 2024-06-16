using DomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class Cast : Base
    {
        public string MovieId { get; set; }
        public string Name { get; set; }
        public PartEnum Part { get; set; }
    }
}
