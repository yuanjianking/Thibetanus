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

            var users = new List<User>
            {
                new User { Name = "Tom" },
                new User { Name = "Mary" }
            };

            var orders = new List<Order>
            {
                new Order { User = users[0], Item = "cloth", Description = "handsome"},
                new Order {User = users[1], Item = "hat", Description = "red"},
                new Order {User = users[1], Item = "boot", Description = "black"}
            };


            //var skills = new List<Skill>
            //{
            //    new Skill { Code="XETN000001",Group="小儿推拿",Name="洗澡" },
            //    new Skill { Code="XETN000002",Group="小儿推拿",Name="药浴" },
            //    new Skill { Code="XETN000003",Group="小儿推拿",Name="推拿" },
            //    new Skill { Code="XETN000004",Group="小儿推拿",Name="洗澡+抚触" },
            //    new Skill { Code="XETN000005",Group="小儿推拿",Name="洗澡+推拿" },
            //    new Skill { Code="XETN000006",Group="小儿推拿",Name="药浴+推拿" },
            //    new Skill { Code="XETN000007",Group="小儿推拿",Name="艾灸" },
            //    new Skill { Code="XETN000008",Group="小儿推拿",Name="推拿+艾灸" }

            //};


            context.Users.AddRange(users);
            context.Orders.AddRange(orders);

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

            var servcie = new List<Servcie>
            {
                new Servcie { Code = "CR00000001", Group="催乳", Name = "开奶", Price="101"  },
                new Servcie { Code = "CR00000002", Group="催乳", Name = "通乳", Price="102"  },
                new Servcie { Code = "CR00000003", Group="催乳", Name = "回奶", Price="103"  },
                new Servcie { Code = "CR00000004", Group="催乳", Name = "急性乳腺炎", Price="104"  },
                new Servcie { Code = "CHXF000001", Group="产后修复", Name = "妊娠纹修复", Price="105"  },
                new Servcie { Code = "CHXF000002", Group="产后修复", Name = "骨盆修复", Price="106"  },
                new Servcie { Code = "CHXF000003", Group="产后修复", Name = "盆底肌修复", Price="107"  },
                new Servcie { Code = "CHXF000004", Group="产后修复", Name = "肩颈调理", Price="108"  },
                new Servcie { Code = "CHXF000005", Group="产后修复", Name = "暖宫", Price="109"  },
                new Servcie { Code = "CHXF000006", Group="产后修复", Name = "满月发汗", Price="110"  },
                new Servcie { Code = "CHXF000007", Group="产后修复", Name = "胸型优化", Price="111"  },
                new Servcie { Code = "CHXF000008", Group="产后修复", Name = "头疗", Price="112"  },
                new Servcie { Code = "CHXF000009", Group="产后修复", Name = "腹直肌分离修复", Price="113"  },
                new Servcie { Code = "SZJK000001", Group="生殖健康", Name = "一指私密", Price="114"  },
                new Servcie { Code = "CHTXHF0001", Group="产后体型恢复", Name = "瘦四肢", Price="115"  },
                new Servcie { Code = "CHTXHF0002", Group="产后体型恢复", Name = "提臀", Price="116"  },
                new Servcie { Code = "CHTXHF0003", Group="产后体型恢复", Name = "大肚腩", Price="117"  },
                new Servcie { Code = "ZYLL000001", Group="中医理疗", Name = "拔罐", Price="118"  },
                new Servcie { Code = "ZYLL000002", Group="中医理疗", Name = "艾灸", Price="119"  },
                new Servcie { Code = "ZYLL000003", Group="中医理疗", Name = "刮痧", Price="120"  },
                new Servcie { Code = "XETN000001", Group="小儿推拿", Name = "洗澡", Price="20"  },
                new Servcie { Code = "XETN000002", Group="小儿推拿", Name = "药浴", Price="98"  },
                new Servcie { Code = "XETN000003", Group="小儿推拿", Name = "推拿", Price="68"  },
                new Servcie { Code = "XETN000004", Group="小儿推拿", Name = "艾灸", Price="68"  },
                new Servcie { Code = "XETN000004", Group="小儿推拿", Name = "洗澡+抚触", Price="38"  },
                new Servcie { Code = "XETN000004", Group="小儿推拿", Name = "洗澡+推拿", Price="78"  },
                new Servcie { Code = "XETN000004", Group="小儿推拿", Name = "药浴+推拿", Price="138"  },
                new Servcie { Code = "XETN000004", Group="小儿推拿", Name = "推拿+艾灸", Price="138"  },
                new Servcie { Code = "MYHL000001", Group="母婴护理", Name = "育婴", Price="122"  },
                new Servcie { Code = "MYHL000002", Group="母婴护理", Name = "月嫂", Price="123"  },

            };
            context.Locations.AddRange(locations);
            context.Managers.AddRange(managers);
            context.Salons.AddRange(salons);
            context.Services.AddRange(servcie);

            context.SaveChanges();
        }
    }
}
