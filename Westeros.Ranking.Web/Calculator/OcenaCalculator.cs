using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Westeros.Ranking.Data.Model;

namespace Westeros.Ranking.Web.Calculator
{
    public class OcenaCalculator
    {

        public IList<Oceny> OcenyDoPrzepisu(Oceny[] o, int id)
        {
            IList<Oceny> ret=new List<Oceny>();
            foreach (Oceny ocena in o)
            {
                if (ocena.id==id)
                {
                    ret.Add(ocena);
                }
            }

            return ret;
        }

        public IList<Oceny> ocenyRosnaco(Oceny[] o)
        {
            IList<Oceny>ret=new List<Oceny>(o);
            ret.OrderBy(x => x.Ocena).ToList();
            return ret;
        }

        public IList<Oceny> ocenymalejaco(Oceny[] o)
        {
            IList<Oceny>ret=new List<Oceny>(o);
            ret.OrderByDescending(x => x.Ocena);
            return ret;
        }

    }
}
