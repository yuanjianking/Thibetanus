using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.Helper;
using Thibetanus.Common.Initiate;
using Thibetanus.DBmanager;
using Thibetanus.Models.SubPage;

namespace Thibetanus.MasterData
{
    class ManagerMaster
    {
        private static ObservableCollection<ManagerModel> _managers = null;

        public ObservableCollection<ManagerModel> GetCollection()
        {
            Load();
            return _managers;
        }

        public ManagerModel GetDataByCode(string code)
        {
            Load();
            var manager = _managers.Where(model => model.Code.Equals(code));
            return manager.FirstOrDefault();
        }

        public ManagerModel GetDataByName(string name)
        {
            Load();
            var manager = _managers.Where(model=> model.Name.Equals(name));
            return manager.FirstOrDefault();
        }

        public void LoadData(object sender, InitiateEventArgs e)
        {
            Load();
        }


        public void Subscribe(MasterDataInitiater evenSource)
        {
            evenSource.InitiateEvent += new InitiateEventHandler(LoadData);
            evenSource.ActionEvent += new Action<object, InitiateEventArgs>(LoadData);
        }

        public void UnSubscribe(MasterDataInitiater evenSource)
        {
            evenSource.InitiateEvent -= new InitiateEventHandler(LoadData);
            evenSource.ActionEvent -= new Action<object, InitiateEventArgs>(LoadData);
        }

        private void Load()
        {
            if(_managers == null)
            {
                //数据库检索
                _managers = new ObservableCollection<ManagerModel>();
                DBConnect connect = new DBFactory().GetPostgreSQLDBConnect();
                var list = connect.FindAll<DBModels.PostgreSQL.Manager, int>(m => m.Id);
                foreach (var item in list)
                {
                    ManagerModel model = new ManagerModel();
                    ModelHelper.CopyModel(model, item);
                    _managers.Add(model);
                }
            }
        }
    }
}
