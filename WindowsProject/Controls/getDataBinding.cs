using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Controls
{
    class getDataBinding
    {
        private List<DataForBinding> dataBindingList;
        public getDataBinding()
        {
            dataBindingList = new List<DataForBinding>();
        }

        public void addDataBind(DataForBinding data)
        {
            dataBindingList.Add(data);
        }

        public List<DataForBinding> getDataList()
        {
            return dataBindingList;
        }
    
    }
}
