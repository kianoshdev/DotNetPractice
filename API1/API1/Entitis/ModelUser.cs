using System;
using System.Globalization;

namespace API1.Entitis
{
    public class ModelUser
    {
        public int ID { get; set; }
        public string BirthDay { get; set; }

        public int GetAge()
        { 
            DateTime BirthDay = Convert.ToDateTime(this.BirthDay);
            DateTime Now = DateTime.Now; 

             PersianCalendar pc = new PersianCalendar();
             int BirthDayYear = pc.GetYear(BirthDay);
             int NowYear = pc.GetYear(Now);    
             return NowYear - BirthDayYear;  
        }
    }
}
