using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thibetanus.DBModels.MongDB
{
    class SkillTable
    {
        /// <summary>
        /// 指定的表
        /// </summary>
        public static readonly string TBName = "Skill";

        [BsonElement(elementName: "_id")]
        public ObjectId Id { get; set; }
        [BsonElement(elementName: "code")]
        public string Code { get; set; }
        [BsonElement(elementName: "group")]
        public string Group { get; set; }
        [BsonElement(elementName: "name")]
        public string Name { get; set; }
    }
}
