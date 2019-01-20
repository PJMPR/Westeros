using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Westeros.Ranking.Data.Model;

namespace Westeros.Ranking.Web.Calculator
{
    public class OcenaCalculator
    {

        public static IList<Oceny> OcenyDoPrzepisu(Oceny[] o, int id)
        {
            IList<Oceny> ret=new List<Oceny>();
            foreach (Oceny ocena in o)
            {
                if (ocena.resourceId==id && ocena.resourceName=="przepis")
                {
                    ret.Add(ocena);
                }
            }

            return ret;
        }

        public static IList<Oceny> OcenyDoDiety(Oceny[] o, int id)
        {
            IList<Oceny> ret = new List<Oceny>();
            foreach (Oceny ocena in o)
            {
                if (ocena.resourceId == id && ocena.resourceName=="dieta")
                {
                    ret.Add(ocena);
                }
            }

            return ret;
        }

        public static IList<Oceny> ocenyRosnaco(Oceny[] o)
        {
            IList<Oceny>ret=new List<Oceny>(o);
            ret = ret.OrderBy(x => x.Ocena).ToList();
            return ret;
        }

        public static IList<Oceny> ocenyMalejaco(Oceny[] o)
        {
            IList<Oceny>ret=new List<Oceny>(o);
            ret = ret.OrderByDescending(x => x.Ocena).ToList();
            return ret;
        }

        public static IList<int> policzIloscOcen(Oceny[] o)
        {
            IList<int>ret = new List<int>();
            ret.Add(0);//1
            ret.Add(0);//2
            ret.Add(0);//3
            ret.Add(0);//4
            ret.Add(0);//5
            foreach (var oceny in o)
            {
                ret[oceny.Ocena-1]++;
            }

            return ret;
        }

    }
}
