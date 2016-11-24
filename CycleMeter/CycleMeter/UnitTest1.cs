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
            Assert.AreEqual("Razvan", ReturnBicyclistsNameWithHighestSpeedAverage(bicyclist));
        }

        [TestMethod]
        public void TestFindNameAndSecondForHighestSpeed()
        {
            var bicyclist = new Bicyclist[] { new Bicyclist("john", 22, new decimal[] { 100, 30, 200 }), new Bicyclist("Paul", 28, new decimal[] { 200, 300,70 }), new Bicyclist("Razvan", 26, new decimal[] { 400, 500, 300 }) };
            Assert.AreEqual("Razvan 2", FindNameOfBicyclistWithTheMaxSpeedAndTheSecondInWichHeAchievesIt(bicyclist));
        }

        [TestMethod]
        public void TestCalculateTotalDistanceMadeByAllBicyclists()
        {
            var bicyclist = new Bicyclist[] { new Bicyclist("john", 22, new decimal[] { 100, 30, 200 }), new Bicyclist("Paul", 28, new decimal[] { 200, 300, 70 }), new Bicyclist("Razvan", 26, new decimal[] { 400, 500, 300 }) };
            Assert.AreEqual(1.7087880m, CalculateTotalDistanceMadeByAllBicyclists(bicyclist));
        }

        decimal CalculateAverageRotations(decimal[] rotations)
        {
            decimal totalRotations = 0;
            for (int j = 0; j < rotations.Length; j++)
                totalRotations += rotations[j];
            decimal averageRotations = totalRotations / rotations.Length;
            return averageRotations;
        }

        decimal CalculateSpeed(decimal rotation, decimal diameter)
        {
            decimal speed = (decimal)3.14 * diameter * rotation;
            speed = ConvertToKmPerHour(speed);
            return speed;
        }

        decimal ConvertToKmPerHour(decimal speed)
        {
            speed = (speed / 100000) * 3600;
            return speed;
        }

        decimal CalculateTotalDistanceMadeByAllBicyclists(Bicyclist[] bicyclist)
        {
            decimal totalDistance = 0;
            decimal totalDistanceInKM = 0;
            for (int i = 0; i < bicyclist.Length; i++)
            {
                int timeInSeconds = bicyclist[i].cycleMeter.Length;
                decimal averageRotations = CalculateAverageRotations(bicyclist[i].cycleMeter);
                totalDistance += CalculateSpeed(averageRotations, bicyclist[i].diameter) * timeInSeconds;
            }
            totalDistanceInKM = totalDistance / 3600;
            return totalDistanceInKM;
        }

        string ReturnBicyclistsNameWithHighestSpeedAverage(Bicyclist[] bicyclist)
        {          
            string nameOfByciclistWithTheHighestAverageSpeed = "";
            decimal maxAverageSpeed = FindMaxAverageSpeed(bicyclist);
            nameOfByciclistWithTheHighestAverageSpeed = FindNameOfCiclystWithTheHighestSpeedAverage(bicyclist, maxAverageSpeed, nameOfByciclistWithTheHighestAverageSpeed);
            return nameOfByciclistWithTheHighestAverageSpeed;
        }

        decimal CalculateAverageSpeedForEachBicyclist(Bicyclist[] bicyclist, int i)
        {
            decimal averageRotations = CalculateAverageRotations(bicyclist[i].cycleMeter);
            decimal averageSpeed = CalculateSpeed(averageRotations, bicyclist[i].diameter);
            return averageSpeed;
        }

        decimal FindMaxAverageSpeed(Bicyclist[] bicyclist)
        {
            decimal maxAverageSpeed = 0;
            for (int i = 0; i < bicyclist.Length; i++)
            {
                decimal averageSpeed = CalculateAverageSpeedForEachBicyclist(bicyclist, i);
                maxAverageSpeed = (averageSpeed > maxAverageSpeed) ? averageSpeed : maxAverageSpeed;
            }

            return maxAverageSpeed;
        }

        string FindNameOfCiclystWithTheHighestSpeedAverage(Bicyclist[] bicyclist, decimal maxAverageSpeed, string nameOfByciclistWithTheHighestAverageSpeed)
        {
            for (int i = 0; i < bicyclist.Length; i++)
            {
                decimal averageSpeedOfBicyclist = CalculateAverageSpeedForEachBicyclist(bicyclist, i);
                nameOfByciclistWithTheHighestAverageSpeed = (averageSpeedOfBicyclist == maxAverageSpeed) ? bicyclist[i].name : nameOfByciclistWithTheHighestAverageSpeed;
            }
            return nameOfByciclistWithTheHighestAverageSpeed;
        }
               
        string FindNameOfBicyclistWithTheMaxSpeedAndTheSecondInWichHeAchievesIt(Bicyclist[] bicyclist)
        {
            string nameAndSecond = "";
            
            for (int i = 0; i < bicyclist.Length; i++)
            {
                nameAndSecond = GoOverSecondsToFindIfSpeedIsMaxSpeed(bicyclist,nameAndSecond, i);
            }
            return nameAndSecond;
        }

        decimal FindMaxSpeed(Bicyclist[] bicyclist)
        {
            decimal maxSpeed = 0;
            for (int i = 0; i < bicyclist.Length; i++)
            {
                maxSpeed = CalculateMaxSpeed(bicyclist, maxSpeed, i);
            }
            return maxSpeed;
        }

        decimal CalculateMaxSpeed(Bicyclist[] bicyclist, decimal maxSpeed, int i)
        {
            for (int j = 0; j < bicyclist[i].cycleMeter.Length; j++)
            {
                decimal speedAtSecond = CalculateSpeed(bicyclist[i].cycleMeter[j], bicyclist[i].diameter);
                maxSpeed = (maxSpeed < speedAtSecond) ? speedAtSecond : maxSpeed;
            }

            return maxSpeed;
        }

        string GoOverSecondsToFindIfSpeedIsMaxSpeed(Bicyclist[] bicyclist,string nameAndSecond, int i)
        {          
            for (int j = 0; j < bicyclist[i].cycleMeter.Length; j++)
            {
                nameAndSecond = CompareCurrentSpeedWithMaxSpeed(bicyclist,nameAndSecond,i, j);
            }

            return nameAndSecond;
        }

        string CompareCurrentSpeedWithMaxSpeed(Bicyclist[] bicyclist,string nameAndSecond, int i, int j)
        {                
            decimal maxSpeed = FindMaxSpeed(bicyclist);
            decimal currentSpeed = CalculateSpeed(bicyclist[i].cycleMeter[j], bicyclist[i].diameter);
            if (currentSpeed == maxSpeed)
            {
                string name = bicyclist[i].name;
                name += " ";
                string second = Convert.ToString(j + 1);
                nameAndSecond = string.Concat(name, second);
            }
            return nameAndSecond;
        }
      

        
     
    }     
}
