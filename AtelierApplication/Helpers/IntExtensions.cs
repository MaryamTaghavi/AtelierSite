using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Application.Helpers
{
   public static class IntExtensions
    {
        public static bool IsEven(this int num)
        {
            if (num % 2 == 0)
                return true;
            else
                return false;
        }
    }
}
