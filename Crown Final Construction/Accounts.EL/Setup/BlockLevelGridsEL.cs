using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class BlockLevelGridsEL : BlocksLevelsEL
    {
        public Int64 IdGrid { get; set; }
        public string GridCode { get; set; }
        public string GridName { get; set; }
    }
}
