using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Thibetanus.Common.BaseControl;
using Thibetanus.Common.Exceptions;
using Thibetanus.Common.Helper;
using Thibetanus.Common.Log;
using Thibetanus.DbManager;
using Thibetanus.Models.SubPage.Service;
using Thibetanus.Models.SubPage.Staff;

namespace Thibetanus.Controls.Staff
{
    class StaffControl : BaseControl
    {
        private readonly int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        private int GetDays(int year, int month)
        {
            if (month == 2)
            {
                return ((year % 4 == 0) && ((year % 100) != 0)) || (year % 400 == 0) ? 29 : 28;
             }
            else
            {
                return daysInMonth[month - 1];
             }
        }

        private List<string> GetDates()
        {
            var dates = new List<string>();
            var nowdate = DateTime.Now;
            int year = nowdate.Year;
            int month = nowdate.Month;
            int day = nowdate.Day;
            int totalDay = GetDays(year, month);
            if (totalDay - day >= 6)
            {
                for (int i = day; i <= day + 6; i++)
                {
                    string month00 = month < 10 ? '0' + month.ToString() : month.ToString();
                    string date00 = i < 10 ? '0' + i.ToString() : i.ToString();
                    dates.Add(year.ToString() + '年' + month.ToString() + '月' + date00 + '日');
                }
            }
            else
            {
                if (month != 12)
                {
                    //当月
                    for (int i = day; i <= totalDay; i++)
                    {
                        string month00 = month < 10 ? '0' + month.ToString() : month.ToString();
                        dates.Add(year.ToString() + '年' + month.ToString() + '月' + i.ToString() + '日');
                    }
                    //次月      
                    for (int i = 1; i <= 6 - (totalDay - day); i++)
                    {
                        string month00 = month < 10 ? '0' + (month + 1).ToString() : (month + 1).ToString();
                        dates.Add(year.ToString() + '年' + (month + 1).ToString() + "月0" + i.ToString() + '日');
                    }
                }
                else
                {
                    //当月
                    for (int i = day; i <= totalDay; i++)
                    {
                       dates.Add(year.ToString() + '年' + "12月" + i.ToString() + '日');
                    }
                    //次年月
                    for (int i = 1; i <= 6 - (totalDay - day); i++)
                    {                    
                        dates.Add((year + 1).ToString() + '年' + "01月0" + i.ToString() + '日');
                    }
                }
            }


            return dates;
        }

        public StaffControl()
        {
         

        }
        public StaffListModel GetStaffInfosBySalon(string salonCode)
        {
            StaffListModel staffList = new StaffListModel();

            staffList.Dates = GetDates();

            staffList.StaffInfos = new List<StaffInfoModel>();
            using (var context = new ApplicationDbContext())
            { 
                var listStaff = context.Staffs.Where(w => w.SalonCode == salonCode).OrderBy(m => m.Code);

                foreach (var item in listStaff)
                {
                    StaffInfoModel model = new StaffInfoModel();
                    ModelHelper.CopyModel(model, item);
                    model.ServiceTimes = new Dictionary<string, List<StaffServiceTimeModel>>();
                    List<StaffServiceTimeModel> servicestime = new List<StaffServiceTimeModel>();
                    if (!string.IsNullOrEmpty(item.ServiceTimes))
                        servicestime = JsonConvert.DeserializeObject<List<StaffServiceTimeModel>>(item.ServiceTimes);

                    if(servicestime.Count > 0)
                    { 
                        foreach (var date in staffList.Dates)
                        {
                            var booktimes = context.StaffBookTimes.Where(m => m.StaffCode == model.Code && m.Date == date).ToList();
                            var times = servicestime.Where(m => !booktimes.Any(m2 => m2.ServiceTimeCode == m.Code)).ToList();
                            times.ForEach(m => m.AreaTime = m.StartTime + '-' + m.EndTime);
                            model.ServiceTimes.Add(date, times);
                        }
                    }
                    staffList.StaffInfos.Add(model);
                }
            }
            return staffList;
        }
    }
}
