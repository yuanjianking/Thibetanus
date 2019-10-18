using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.BaseControl;
using Thibetanus.Common.Helper;
using Thibetanus.DBmanager;
using Thibetanus.DBmanager.PostgreSQL;
using Thibetanus.Models.SubPage.Salon;

namespace Thibetanus.Controls.Salon
{
    class SalonControl : BaseControl
    {    
        public void Save(ObservableCollection<SalonEditModel> models)
        {            
            DBConnect connect = new DBFactory().GetPostgreSQLDBConnect();
            try
            {
                connect.StartConnect();
                Hashtable LocationTable = new Hashtable ();
                Hashtable ManagerTable = new Hashtable();

                foreach (SalonEditModel model in models)
                {
                    DBModels.PostgreSQL.Salon salon = new DBModels.PostgreSQL.Salon();
                    ModelHelper.CopyModel(salon, model);

                    if (LocationTable[model.Location.Id] != null)
                    {
                        salon.Location = LocationTable[model.Location.Id] as DBModels.PostgreSQL.Location;
                    }
                    else
                    {
                        DBModels.PostgreSQL.Location Location = new DBModels.PostgreSQL.Location();
                        ModelHelper.CopyModel(Location, model.Location);
                        LocationTable.Add(Location.Id, Location);
                    }

                    if (ManagerTable[model.Manager.Id] != null)
                    {
                        salon.Manager = ManagerTable[model.Manager.Id] as DBModels.PostgreSQL.Manager;
                    }
                    else
                    { 
                        DBModels.PostgreSQL.Manager Manager = new DBModels.PostgreSQL.Manager();                       
                        ModelHelper.CopyModel(Manager, model.Manager);
                        ManagerTable.Add(Manager.Id, Manager);
                    }

                    if (!model.NewData)
                    {
                        connect.Modify(salon);
                    }
                    else
                    {
                        connect.Add(salon);
                    }
                }
               connect.SaveChange();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            finally { 
                connect.CloseConnect();
            }
        }

        public ObservableCollection<SalonEditModel> GetAllSalonInfos()
        {
            var models = new ObservableCollection<SalonEditModel>();
            DBConnect connect = new DBFactory().GetPostgreSQLDBConnect();
            var list = connect.FindAll<DBModels.PostgreSQL.Salon,int>(m => m.Id);

            foreach (var item in list)
            {
                SalonEditModel model = new SalonEditModel();
                ModelHelper.CopyModel(model, item);
                models.Add(model);
            }

            return models;
        }
    }
}
