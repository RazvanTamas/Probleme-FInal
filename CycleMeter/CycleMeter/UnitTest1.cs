using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//Un ciclometru e un mecanism simplu care numără rotațiile unei roți de bicicletă.
//În urma unei curse ai datele înregistrate de ciclometrele bicicliștilor participanți.
//Ciclometrul fiecărui participant a înregistrat numărul de rotații făcute în fiecare secundă.
//Dacă cunoști pentru fiecare bicicletă diametrul roților:
//Calculează distanța totală parcursă de toți bicicliștii
//Găsește secunda și numele biciclistului care a atins viteza maximă
//Găsește biciclistul care a avut cea mai bună viteză medie
namespace CycleMeter
{
    public struct Bicyclist
    {
        public string name;
        public decimal diameter;
        public decimal[] cycleMeter;
        public Bicyclist(string name,decimal diameter,decimal[] cycleMeter)
        {
            this.name = name;
            this.diameter = diameter;
            this.cycleMeter = cycleMeter;
        }         
    }
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var bicyclist = new Bicyclist[] { new Bicyclist("john", 22, new decimal[] { 100, 50, 200 }), new Bicyclist("Paul", 28, new decimal[] { 200, 300, 50 }), new Bicyclist("Razvan", 26, new decimal[] { 400, 500, 300 }) };
            Assert.AreEqual("Razvan", FindBicyclistWithHighestSpeedAverage(bicyclist)); 
        }

        string FindBicyclistWithHighestSpeedAverage(Bicyclist[] bicyclist)
        {
            string bicyclistWithHighestSpeedAverage = bicyclist[0].name;
            decimal maxAverageSpeed = 0;
            for (int i = 0; i < bicyclist.Length; i++)
            {
                if (CalculateAverageSpeed(CalculateAverageRotations(bicyclist[i].cycleMeter), bicyclist[i].diameter) > maxAverageSpeed)
                {
                    maxAverageSpeed = CalculateAverageSpeed(CalculateAverageRotations(bicyclist[i].cycleMeter), bicyclist[i].diameter);
                    bicyclistWithHighestSpeedAverage = bicyclist[i].name;
                }                               
            }
            return bicyclistWithHighestSpeedAverage;
        }

        decimal CalculateAverageSpeed(decimal averageRotations, decimal diameter)
        {
            decimal speed = 0;
            speed = (decimal)3.14 * diameter * averageRotations / 3600;
            return speed;
        }
        decimal CalculateAverageRotations(decimal[] rotations)
        {
            decimal totalRotations = 0;
            for (int j = 0; j < rotations.Length; j++)
                totalRotations += rotations[j];
            decimal averageRotations = totalRotations / rotations.Length;
            return averageRotations;
        }
    }

   
}
