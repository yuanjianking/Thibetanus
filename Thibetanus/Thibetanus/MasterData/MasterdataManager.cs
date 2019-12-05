using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.Initiate;
using Thibetanus.Controls.Salon;

namespace Thibetanus.MasterData
{
    class MasterdataManager
    {
        public void Load()
        {
            MasterDataInitiater initiater = new MasterDataInitiater();

            (new LocationControl()).Subscribe(initiater);
            (new ManagerControl()).Subscribe(initiater);

            initiater.LoadData();
        }
    }
}
