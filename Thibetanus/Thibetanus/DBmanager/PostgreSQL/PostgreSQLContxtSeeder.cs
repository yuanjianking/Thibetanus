using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.DBModels.PostgreSQL;

namespace Thibetanus.DBmanager.PostgreSQL
{
    class PostgreSQLContxtSeeder
    {
        public static void Seed(PostgreSQLContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var locations = new List<Location>
            {
                new Location { Code = "CZ", Province = "江苏省", City="常州市"},
                new Location { Code = "NT", Province = "江苏省", City="南通市"},
                new Location { Code = "WX", Province = "江苏省", City="无锡市"},
                new Location { Code = "WZ", Province = "浙江省", City="温州市"},
                new Location { Code = "SY", Province = "辽宁省", City="沈阳市"},
                new Location { Code = "DL", Province = "辽宁省", City="大连市"},
                new Location { Code = "QD", Province = "山东省", City="青岛市"},
                new Location { Code = "HF", Province = "安徽省", City="合肥市"},
                new Location { Code = "WH", Province = "湖北省", City="武汉市"},
                new Location { Code = "XA", Province = "陕西省", City="西安市"}
            };

            var managers = new List<Manager>
            {
                new Manager { Code = "CZM0000000001", Name = "袁舰"},
                new Manager { Code = "CZM0000000002", Name = "熊大"},
                new Manager { Code = "CZM0000000003", Name = "熊二"}
            };

            var salons = new List<Salon>
            {
                new Salon { Code = "MY0000000001", Name = "袁舰母婴工作室", LocationCode="SY",  ManagerCode = "CZM0000000001"},
                new Salon { Code = "MY0000000002", Name = "熊大母婴工作室", LocationCode="DL",  ManagerCode = "CZM0000000002"},
                new Salon { Code = "MY0000000003", Name = "熊二母婴工作室", LocationCode="DL",  ManagerCode = "CZM0000000003"}
            };

            var serviceGroups = new List<ServiceGroup>
            {
                new ServiceGroup { Code = "CR", GroupName="催乳", ShowIndex="5"},
                new ServiceGroup { Code = "CHXF", GroupName="产后修复", ShowIndex="3"},
                new ServiceGroup { Code = "SZJK", GroupName="生殖健康", ShowIndex="7"},
                new ServiceGroup { Code = "CHTXHF", GroupName="体型恢复", ShowIndex="4"},
                new ServiceGroup { Code = "ZYLL", GroupName="中医理疗", ShowIndex="6"},
                new ServiceGroup { Code = "XETN", GroupName="小儿推拿", ShowIndex="1"},
                new ServiceGroup { Code = "MYHL", GroupName="母婴护理", ShowIndex="2"},
            };

            var services = new List<Service>
            {
                new Service { Code = "CR00000001", GroupCode=serviceGroups[0].Code, Name = "开奶", Price="101"  },
                new Service { Code = "CR00000002", GroupCode=serviceGroups[0].Code, Name = "通乳", Price="102"  },
                new Service { Code = "CR00000003", GroupCode=serviceGroups[0].Code, Name = "回奶", Price="103"  },
                new Service { Code = "CR00000004", GroupCode=serviceGroups[0].Code, Name = "急性乳腺炎", Price="104"  },
                new Service { Code = "CHXF000001", GroupCode=serviceGroups[1].Code, Name = "妊娠纹修复", Price="105"  },
                new Service { Code = "CHXF000002", GroupCode=serviceGroups[1].Code, Name = "骨盆修复", Price="106"  },
                new Service { Code = "CHXF000003", GroupCode=serviceGroups[1].Code, Name = "盆底肌修复", Price="107"  },
                new Service { Code = "CHXF000004", GroupCode=serviceGroups[1].Code, Name = "肩颈调理", Price="108"  },
                new Service { Code = "CHXF000005", GroupCode=serviceGroups[1].Code, Name = "暖宫", Price="109"  },
                new Service { Code = "CHXF000006", GroupCode=serviceGroups[1].Code, Name = "满月发汗", Price="110"  },
                new Service { Code = "CHXF000007", GroupCode=serviceGroups[1].Code, Name = "胸型优化", Price="111"  },
                new Service { Code = "CHXF000008", GroupCode=serviceGroups[1].Code, Name = "头疗", Price="112"  },
                new Service { Code = "CHXF000009", GroupCode=serviceGroups[1].Code, Name = "腹直肌分离修复", Price="113"  },
                new Service { Code = "SZJK0000001", GroupCode=serviceGroups[2].Code, Name = "一指私密", Price="114"  },
                new Service { Code = "CHTXHF0001", GroupCode=serviceGroups[3].Code, Name = "瘦四肢", Price="115"  },
                new Service { Code = "CHTXHF0002", GroupCode=serviceGroups[3].Code, Name = "提臀", Price="116"  },
                new Service { Code = "CHTXHF0003", GroupCode=serviceGroups[3].Code, Name = "大肚腩", Price="117"  },
                new Service { Code = "ZYLL0000001", GroupCode=serviceGroups[4].Code, Name = "拔罐", Price="118"  },
                new Service { Code = "ZYLL0000002", GroupCode=serviceGroups[4].Code, Name = "艾灸", Price="119"  },
                new Service { Code = "ZYLL0000003", GroupCode=serviceGroups[4].Code, Name = "刮痧", Price="120"  },
                new Service { Code = "XETN000001", GroupCode=serviceGroups[5].Code, Name = "洗澡", Price="20"  },
                new Service { Code = "XETN000002", GroupCode=serviceGroups[5].Code, Name = "药浴", Price="98"  },
                new Service { Code = "XETN000003", GroupCode=serviceGroups[5].Code, Name = "推拿", Price="68"  },
                new Service { Code = "XETN000004", GroupCode=serviceGroups[5].Code, Name = "艾灸", Price="68"  },
                new Service { Code = "XETN000005", GroupCode=serviceGroups[5].Code, Name = "洗澡+抚触", Price="38"  },
                new Service { Code = "XETN000006", GroupCode=serviceGroups[5].Code, Name = "洗澡+推拿", Price="78"  },
                new Service { Code = "XETN000007", GroupCode=serviceGroups[5].Code, Name = "药浴+推拿", Price="138"  },
                new Service { Code = "XETN000008", GroupCode=serviceGroups[5].Code, Name = "推拿+艾灸", Price="138"  },
                new Service { Code = "MYHL000001", GroupCode=serviceGroups[6].Code, Name = "育婴", Price="122"  },
                new Service { Code = "MYHL000002", GroupCode=serviceGroups[6].Code, Name = "月嫂", Price="123"  },

            };

            var salonservices = new List<SalonService>
            {
                new SalonService{ SalonCode="MY0000000001",ServiceCode="CR00000001", Service=services[0] },
                new SalonService{ SalonCode="MY0000000001",ServiceCode="CR00000002", Service=services[1] },

            };

            var staffServiceTimes = new List<StaffServiceTime>
            {
                new StaffServiceTime{ Code="ST01", StartTime="08:00", EndTime="09:00" },
                new StaffServiceTime{ Code="ST02", StartTime="09:30", EndTime="10:30" },
                new StaffServiceTime{ Code="ST03", StartTime="11:00", EndTime="12:00" },
                new StaffServiceTime{ Code="ST04", StartTime="12:30", EndTime="13:30" },
                new StaffServiceTime{ Code="ST05", StartTime="14:00", EndTime="15:00" },
                new StaffServiceTime{ Code="ST06", StartTime="15:30", EndTime="16:30" },
                new StaffServiceTime{ Code="ST07", StartTime="17:00", EndTime="18:00" }
            };
            var staffs = new List<Staff>
            {
                new Staff{ Code="E0000000001",Name="地鼠1号", SalonCode="MY0000000001", Salon=salons[0], },
                new Staff{ Code="E0000000002",Name="地鼠2号", SalonCode="MY0000000002", Salon=salons[1], },

            };

            var staffOrders = new List<StaffOrder>
            {
            };

            var assets = new List<Assets>
            {
             
            };
            var customs = new List<Custom>
            {

            };


            var orders = new List<Order>
            {

            };




            var staffBookTimes = new List<StaffBookTime>
            {

            };

            context.Locations.AddRange(locations);
            context.Managers.AddRange(managers);
            context.Salons.AddRange(salons);
            context.ServiceGroups.AddRange(serviceGroups);
            context.Services.AddRange(services);
            context.SalonServices.AddRange(salonservices);
            context.StaffServiceTimes.AddRange(staffServiceTimes);
            context.StaffBookTimes.AddRange(staffBookTimes);
            context.Staffs.AddRange(staffs);
            context.StaffOrders.AddRange(staffOrders);
            context.Assets.AddRange(assets);
            context.Customs.AddRange(customs);
            context.Orders.AddRange(orders);           
            context.SaveChanges();
        }
    }
}
