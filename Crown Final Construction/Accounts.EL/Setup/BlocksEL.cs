using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class BlocksEL : VouchersEL
    {
        public Int64 IdBlock { get; set; }
        public string BlockCode { get; set; }
        public string BlockName { get; set; }
    }
}
