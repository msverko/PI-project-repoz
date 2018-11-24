using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repoz
{
    class BizLogic
    {
        public string GetAccLevelString(string role)
        {
            switch (role)
            {
                case "Developer":
                    return "2";
                case "Commissioning eng.":
                    return "3";
                case "Project manager":
                    return "9";
                default:
                    return "1";
            }
        }
    }
}
