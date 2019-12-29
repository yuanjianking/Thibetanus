using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Thibetanus.Models.SubPage.Service
{
    public class ServiceModel
    {
        private string _code;
        private string _groupCode;
        private string _name;
        private string _price;
        private string _coverpath = "../../images/recommend_img_05.png";
        private string _message = "我们追求的是没有最长只有更长！";
        private string _detailMessage = "我们追求的是没有最长只有更长！";

        public int Id { get; set; }
        public string Code { get => _code; set => _code = value; }
        public string GroupCode { get => _groupCode; set => _groupCode = value; }
        public string Name { get => _name; set => _name = value; }
        public string Price { get => _price; set => _price = value; }
        public string Coverpath { get => _coverpath; set => _coverpath = value; }
        public string Message { get => _message; set => _message = value; }
        public string DetailMessage { get => _detailMessage; set => _detailMessage = value; }
    }
}
