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


            var skills = new List<Skill>
            {
                new Skill { Code="XETN000001",Group="小儿推拿",Name="洗澡" },
                new Skill { Code="XETN000002",Group="小儿推拿",Name="药浴" },
                new Skill { Code="XETN000003",Group="小儿推拿",Name="推拿" },
                new Skill { Code="XETN000004",Group="小儿推拿",Name="洗澡+抚触" },
                new Skill { Code="XETN000005",Group="小儿推拿",Name="洗澡+推拿" },
                new Skill { Code="XETN000006",Group="小儿推拿",Name="药浴+推拿" },
                new Skill { Code="XETN000007",Group="小儿推拿",Name="艾灸" },
                new Skill { Code="XETN000008",Group="小儿推拿",Name="推拿+艾灸" }

            };


            context.Users.AddRange(users);
            context.Orders.AddRange(orders);

            context.SaveChanges();
        }
    }
}
