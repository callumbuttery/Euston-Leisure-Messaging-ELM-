using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessList;
using Datalayer;

namespace Datalayer
{
    public class Quarantined_Links
    {
        public List<Links> list = new List<Links>();

        public void add(Links newQuarantinedLinks)
        {
            list.Add(newQuarantinedLinks);
        }



    }

}
