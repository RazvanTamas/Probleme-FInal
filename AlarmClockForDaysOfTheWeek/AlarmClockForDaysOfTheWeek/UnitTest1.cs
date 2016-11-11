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
            Assert.AreEqual(true,IsAlarmAtDayAndHour(new int[] { 10,10,10,8,8,7,7},"Saturday",7));
        }
        [Flags]
        enum DaysOfTheWeek
        {
            None=0,
            Monday = 1,
            Tuesday = 2,
            Wednesday = 3,
            Thursday = 4,
            Friday = 5,
            Saturday = 6,
            Sunday = 7 
        }      
        bool IsAlarmAtDayAndHour(int[] alarmHourForEachDay,string dayToCheck,int hourToCheck)
        {
            DaysOfTheWeek dayNumber;
            Enum.TryParse<DaysOfTheWeek>(dayToCheck, out dayNumber);
            if (alarmHourForEachDay[(int)dayNumber-1] == hourToCheck) return true;
            else return false;                      
        }
    }
    

}
