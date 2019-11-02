using BusinessList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer
{
     public class SmsList
    {

        public List<Sms> list = new List<Sms>();

        public void add(Sms newSms)
        {
            list.Add(newSms);
        }

    }
}
