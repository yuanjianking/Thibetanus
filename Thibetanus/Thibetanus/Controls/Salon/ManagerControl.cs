using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.Exceptions;
using Thibetanus.Common.Helper;
using Thibetanus.Common.Initiate;
using Thibetanus.Common.Log;
using Thibetanus.Common.UserControls;
using Thibetanus.DBmanager;
using Thibetanus.DBmanager.PostgreSQL;
using Thibetanus.Models.SubPage.Salon;

namespace Thibetanus.Controls.Salon
{
    class ManagerControl
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
            var manager = _managers.Where(model => model.Code == code);
            return manager.FirstOrDefault();
        }

        public ManagerModel GetDataByName(string name)
        {
            Load();
            var manager = _managers.Where(model=> model.Name == name);
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
                using (DBConnect connect = new DBFactory().GetPostgreSQLDBConnect().StartConnect())
                {
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

        public int Save()
        {
            using (DBConnect connect = new DBFactory().GetPostgreSQLDBConnect().BeginTransaction())
            {
                try
                {
                    int res = 0;
                    var list = connect.FindAll<DBModels.PostgreSQL.Manager, int>(m => m.Id);
                    var data = list.Where(w => !_managers.Select(s => s.Id).Contains(w.Id));
                    res += connect.Delete(data);

                    foreach (var model in _managers)
                    {
                        DBModels.PostgreSQL.Manager manager = new DBModels.PostgreSQL.Manager();
                        ModelHelper.CopyModel(manager, model);

                        Func<DBModels.PostgreSQL.Manager, bool> func = m =>
                        {
                            if (m.Id == model.Id)
                            {
                                if (m.Code == model.Code && m.Name == model.Name)
                                {
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }

                            }
                            return false;
                        };

                        if (model.Id < 1)
                        {
                            manager.CreateTime = DateTime.Now.ToLongDateString();
                            res += connect.Add(manager);
                        }
                        else if (list.Where(func).Count() > 0)
                        {
                            manager.UpdateTime = DateTime.Now.ToLongDateString();
                            res += connect.Modify(manager);
                        }
                    }
                    connect.Commite();
                    return res;
                }
                catch (Exception ex)
                {
                    connect.Rollback();
                    AppLog.Error(typeof(ManagerControl), ex.ToString());
                    throw new AppException("DBException");
                }
            }
        }
    }
}
