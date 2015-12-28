using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controls
{
    class DataForBinding
    {
        public string indexName{get;set;}
        public string indexValue { get; set; }
        public DataForBinding(string name, string value)
        {
           indexName = name;
           indexValue = value;
        }

        public override string ToString()
        {
            return indexName + ", " + indexValue ;
        }

       /* public string IndexName
        {
            get
            {
                return indexName;
            }
            set 
            {
                indexName = value;
            }
        }*/
    }
}
