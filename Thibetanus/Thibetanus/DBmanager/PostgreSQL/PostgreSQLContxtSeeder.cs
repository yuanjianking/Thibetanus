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
                new Manager { Code = "CZM0000000001", Name = "袁舰", Role="Master"},
                new Manager { Code = "CZM0000000002", Name = "熊大", Role="Manager"},
                new Manager { Code = "CZM0000000003", Name = "熊二", Role="Manager"}
            };

            var salons = new List<Salon>
            {
                new Salon { Code = "MY0000000001", Name = "袁舰母婴工作室", LocationCode="SY", Location = locations[4], ManagerCode = "CZM0000000001", Manager = managers[0]},
                new Salon { Code = "MY0000000002", Name = "熊大母婴工作室", LocationCode="DL", Location = locations[5], ManagerCode = "CZM0000000002", Manager = managers[1]},
                new Salon { Code = "MY0000000003", Name = "熊二母婴工作室", LocationCode="DL", Location = locations[5], ManagerCode = "CZM0000000003", Manager = managers[2]}
            };

            context.Locations.AddRange(locations);
            context.Managers.AddRange(managers);
            context.Salons.AddRange(salons);


            context.SaveChanges();
        }
    }
}
