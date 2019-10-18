using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.Initiate;

namespace Thibetanus.MasterData
{
    class MasterdataManager
    {
        public void Load()
        {
            MasterDataInitiater initiater = new MasterDataInitiater();

            (new LocationMaster()).Subscribe(initiater);
            (new ManagerMaster()).Subscribe(initiater);

            initiater.LoadData();
        }
    }
}
