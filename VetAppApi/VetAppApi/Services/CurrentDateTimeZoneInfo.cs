using System;
using System.Security.Cryptography.X509Certificates;

namespace VetAppApi.Services
{
    public class CurrentDateTimeZoneInfo
    {
        private static TimeZoneInfo Central_America_Standard_Time = TimeZoneInfo.FindSystemTimeZoneById("Central America Standard Time");
        public CurrentDateTimeZoneInfo() { 
           
        }

        public DateTime GetCurrentDateTimeZone()
        {
            DateTime currentDateTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, Central_America_Standard_Time);
            return currentDateTime;
        }
    }
}
