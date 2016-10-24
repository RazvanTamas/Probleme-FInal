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
        public void TestFindBicyclistWithHighestSpeedAverage()
        {
            var bicyclist = new Bicyclist[] { new Bicyclist("john", 22, new decimal[] { 100, 50, 200 }), new Bicyclist("Paul", 28, new decimal[] { 200, 300, 50 }), new Bicyclist("Razvan", 26, new decimal[] { 400, 500, 300 }) };
            Assert.AreEqual("Razvan", FindBicyclistWithHighestSpeedAverage(bicyclist));
        }

        [TestMethod]
        public void TestFindNameAndSecondForHighestSpeed()
        {
            var bicyclist = new Bicyclist[] { new Bicyclist("john", 22, new decimal[] { 100, 30, 200 }), new Bicyclist("Paul", 28, new decimal[] { 200, 300,70 }), new Bicyclist("Razvan", 26, new decimal[] { 400, 500, 300 }) };
            Assert.AreEqual("Razvan 2", FindNameAndSecondForHighestSpeed(bicyclist));
        }

        [TestMethod]
        public void TestCalculateTotalDistanceMadeByAllBicyclists()
        {
            var bicyclist = new Bicyclist[] { new Bicyclist("john", 22, new decimal[] { 100, 30, 200 }), new Bicyclist("Paul", 28, new decimal[] { 200, 300, 70 }), new Bicyclist("Razvan", 26, new decimal[] { 400, 500, 300 }) };
            Assert.AreEqual(1.7087880m, CalculateTotalDistanceMadeByAllBicyclists(bicyclist));
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
            decimal speed = (decimal)3.14 * (diameter / 100000) * averageRotations * 3600;
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

        decimal CalculateSpeedAtSecond(decimal rotation, decimal diameter)
        {
            decimal speed = (decimal)3.14 * (diameter / 100000) * rotation * 3600;
            return speed;
        }

        string FindNameAndSecondForHighestSpeed(Bicyclist[] bicyclist)
        {
            string nameAndSecond = "";
            decimal maxSpeed = FindHighestSpeed(bicyclist);
            for (int i = 0; i < bicyclist.Length; i++)
            {
                for (int j = 0; j < bicyclist[i].cycleMeter.Length; j++)
                {
                    if (CalculateSpeedAtSecond(bicyclist[i].cycleMeter[j], bicyclist[i].diameter) == maxSpeed)
                    {
                        string name = bicyclist[i].name;
                        name += " ";
                        string second = Convert.ToString(j + 1);
                        nameAndSecond = string.Concat(name, second);
                    }
                }
            }
            return nameAndSecond;
        }

        decimal FindHighestSpeed(Bicyclist[] bicyclist)
        {
            decimal maxSpeed = 0;
            for (int i = 0; i < bicyclist.Length; i++)
            {
                for (int j = 0; j < bicyclist[i].cycleMeter.Length; j++)
                {
                    maxSpeed = (maxSpeed < CalculateSpeedAtSecond(bicyclist[i].cycleMeter[j], bicyclist[i].diameter)) ? CalculateSpeedAtSecond(bicyclist[i].cycleMeter[j], bicyclist[i].diameter) : maxSpeed;
                }
            }
            return maxSpeed;
        }

        decimal CalculateTotalDistanceMadeByAllBicyclists(Bicyclist[] bicyclist)
        {
            decimal totalDistance = 0;
            for (int i = 0; i < bicyclist.Length; i++)
            {
                totalDistance += CalculateAverageSpeed(CalculateAverageRotations(bicyclist[i].cycleMeter), bicyclist[i].diameter) * bicyclist[i].cycleMeter.Length / 3600;
            }
            return totalDistance;
        }

    }     
}
