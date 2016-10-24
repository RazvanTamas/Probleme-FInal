using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//O alarmă poate fi setată să se declanșeze la o anumită oră în una sau în mai multe zile din săptămână.
//De exemplu, se poate configura ca alarma să se declanșeze la ora 6 de luni până vineri și să se declanșeze la ora 8 sâmbătă și duminică.
//Scrie o funcție care decide pe baza acestor setări dacă trebuie declanșată alarma într-o anumită zi la o anumită oră.

namespace AlarmClockForDaysOfTheWeek
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(true, IsAlarm(8, "Saturday"));
        }
        [Flags]
        enum DaysOfTheWeek
        {
            Monday = 1,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday 
        }
        int AlarmClock(string alarmDay)
        {
            DaysOfTheWeek alarmDayNumber;
            int alarmHour = 0;

            if (Enum.TryParse<DaysOfTheWeek>(alarmDay,out alarmDayNumber))
            {
                return alarmHour = ((int)alarmDayNumber < (int)DaysOfTheWeek.Saturday) ? 6 : 8;
            }
            return 0;
        }
        public bool IsAlarm(int currentHour,string currentDay)
        {
            return (currentHour == AlarmClock(currentDay));
        }
    
    }
    

}
