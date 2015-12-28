using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controls
{
    class LockPage
    {
        public static bool canchange = true;
        public static LockPage lockPage = new LockPage();

        private LockPage()
        { }

        public static LockPage getLockPageInst()
        {
            return lockPage;
        }

        public bool Canchange
        {
            get
            {
                return canchange;

            }
            set
            {
                canchange = value;
            }
        }
    }
}
