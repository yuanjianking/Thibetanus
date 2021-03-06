﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Thibetanus.Common.Models;
using Thibetanus.Models;
using Windows.Storage;

namespace Thibetanus.Common.Helper
{
    class MenuHelper
    {
        [Flags]
        public enum MenuType
        {
            MainMaster,
            MainManager,
            StaffSub,
            SalonSub,
            ServiceSub,
            Assets,
            Custom
        }

        private static MenuHelper me = null;
        private XmlDocument doc = new XmlDocument();
        private MenuHelper()
        {  
            if (Thread.CurrentThread.CurrentCulture.Name == "en-US")
            {
                doc.Load("Resources/MenusEn.xml");
            }
            else
            {
                doc.Load("Resources/Menus.xml");
            }
        }

        public static MenuHelper GetXmlHelper()
        {
            if (me == null)
            {
                me = new MenuHelper();
            }
            return me;
        }
        public List<MenuModel> GetMenus(MenuType type)
        {
            List<MenuModel> menus = new List<MenuModel>();
            try {
                XmlNode xn = doc.SelectSingleNode(GetPath(type));
                XmlNodeList xnl = xn.ChildNodes;
                foreach (XmlNode xn1 in xnl)
                {
                    XmlElement xe = (XmlElement)xn1;
                    String Label = xe.GetAttribute("Label").ToString();
                    String Link = xe.GetAttribute("Link").ToString();
                    menus.Add(new MenuModel(Label, Type.GetType(Link)));
                }
            }
            catch 
            {

            }
            return menus;
        }

        private String GetPath(MenuType type)
        {
            String path = null;
            switch (type)
            {
                case MenuType.MainMaster:
                    path = "root/MainMenu/Master";
                    break;
                case MenuType.MainManager:
                    path = "root/MainMenu/Manager";
                    break;
                case MenuType.StaffSub:
                    path = "root/SubMenu/StaffSub";
                    break;
                case MenuType.SalonSub:
                    path = "root/SubMenu/SalonSub";
                    break;
                case MenuType.ServiceSub:
                    path = "root/SubMenu/ServiceSub";
                    break;
                case MenuType.Assets:
                    path = "root/SubMenu/AssetsSub";
                    break;
                case MenuType.Custom:
                    path = "root/SubMenu/CustomSub";
                    break;
                default:
                    break;
            }
            return path;
        }
    }
}
