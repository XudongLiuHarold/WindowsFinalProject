using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM25onWinPhone.Entity
{
    class CiteStationAir
    {
        public string statusCode { get; set; }
        public string message { get; set; }
        public List<data> data { get; set; }

    }
}
