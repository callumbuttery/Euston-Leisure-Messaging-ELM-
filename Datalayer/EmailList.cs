using BusinessList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer
{
    public class EmailList
    {
        public List<Emails> list = new List<Emails>();

        public void add(Emails newEmail)
        {
            list.Add(newEmail);
        }

    }
}
