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
            Assert.AreEqual(true, IsAlarm(5,8,8,10,1,8));
        }
        [Flags]
        enum DaysOfTheWeek
        {
            None=0,
            Monday = 1 << 0,
            Tuesday = 1 << 1,
            Wednesday = 1 << 2,
            Thursday = 1 << 3,
            Friday = 1 << 4,
            Saturday = 1 << 5,
            Sunday = 1 << 6 
        }
        bool IsAlarm(byte alarmOneDays,int alarmOneHour,byte alarmTwoDays,int alarmTwoHour,byte givenDay,int givenHour)
        {
            bool alarm = false;
            if ((alarmOneDays & givenDay) == givenDay && alarmOneHour == givenHour)
            {
                return alarm = true;
            }
            else if ((alarmTwoDays & givenDay) == givenDay && alarmTwoHour == givenHour)
            {
                return alarm = true;
            }
            else return alarm = false;           
        }
    }
    

}
