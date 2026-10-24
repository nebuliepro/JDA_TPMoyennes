using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    static class Outils
    {
        public static float Tronquer(float valeur)
        {
            decimal d = (decimal)valeur;
            return (float)(Math.Truncate(d * 100m) / 100m);
        }
    }
}
