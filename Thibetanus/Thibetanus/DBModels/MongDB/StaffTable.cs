using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thibetanus.DBModels.MongDB
{
    class StaffTable
    {
        /// <summary>
        /// 指定的表
        /// </summary>
        public static readonly string TBName = "Staff";

        [BsonElement(elementName: "_id")]
        public ObjectId Id { get; set; }
        [BsonElement(elementName: "code")]
        public string Code { get; set; }
        [BsonElement(elementName: "name")]
        public string Name { get; set; }
        [BsonElement(elementName: "salon")]
        public string Salon { get; set; }
        [BsonElement(elementName: "role")]
        public string Role { get; set; }
        [BsonElement(elementName: "skill")]
        public List<SkillTable> Skill { get; set; }
    }
}
