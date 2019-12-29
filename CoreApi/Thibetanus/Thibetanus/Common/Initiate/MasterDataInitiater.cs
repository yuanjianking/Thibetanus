using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thibetanus.Common.Initiate
{
    public class MasterDataInitiater
    {   
        public event InitiateEventHandler InitiateEvent;
        public event Action<object, InitiateEventArgs> ActionEvent;

        public void LoadData()
        {
            InitiateEvent?.Invoke(this, new InitiateEventArgs());
            ActionEvent?.Invoke(this, new InitiateEventArgs());
        }        
    }
}
