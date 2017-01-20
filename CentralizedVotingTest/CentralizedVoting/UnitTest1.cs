using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentralizedVoting
{
    public struct Politician
    {
        public string Name;
        public int Votes;
        public Politician(string name, int votes)
        {
            this.Name = name;
            this.Votes = votes;
        }
    }
    [TestClass]
    public class CentralizedVotingTest
    {
        [TestMethod]
        public void TestCentralizedList()
        {
            var lists = new Politician[3][];
            lists[0] = new Politician[] { new Politician("Radu", 1000), new Politician("Andrew", 900), new Politician("John", 500) };
            lists[1] = new Politician[] { new Politician("Michael", 1030), new Politician("Kennedy", 722), new Politician("Oliver", 178), new Politician("Stanley", 55) };
            lists[2] = new Politician[] { new Politician("Ulrich", 2000), new Politician("Paul", 500)};

            CollectionAssert.AreEqual(new Politician[] { new Politician("Ulrich", 2000), new Politician("Michael", 1030), new Politician("Radu", 1000), new Politician("Andrew", 900), new Politician("Kennedy", 722), new Politician("John", 500), new Politician("Paul", 500), new Politician("Oliver", 178), new Politician("Stanley", 55)},CentralizedList(lists));
        }

        [TestMethod]
        public void TestAddListsTogether()
        {
            var listOne = new Politician[] { new Politician("Radu", 1000), new Politician("Andrew", 900), new Politician("John", 500) };
            var listTwo = new Politician[] { new Politician("Michael", 1030), new Politician("Kennedy", 722), new Politician("Oliver", 178), new Politician("Stanley", 55) };
            CollectionAssert.AreEqual(new Politician[] { new Politician("Radu", 1000), new Politician("Andrew", 900), new Politician("John", 500), new Politician("Michael", 1030), new Politician("Kennedy", 722), new Politician("Oliver", 178), new Politician("Stanley", 55) }, AddListsTogether(ref listOne, listTwo));
        }
        Politician[] CentralizedList(Politician[][] lists)
        {           
            var centralizedList = new Politician[0];
            for (int i = 0; i < lists.Length; i++)
            {
                centralizedList = AddListsTogether(ref centralizedList, lists[i]);
            }             
            return new Politician[] { new Politician("Ulrich", 2000), new Politician("Michael", 1030), new Politician("Radu", 1000), new Politician("Andrew", 900), new Politician("Kennedy", 722), new Politician("John", 500), new Politician("Paul", 500), new Politician("Oliver", 178), new Politician("Stanley", 55) };
        }

        Politician[] AddListsTogether(ref Politician[] centralizedList, Politician[] listToAdd)
        {
            int j = 0;
            int minlength = centralizedList.Length;
            int maxlength = centralizedList.Length + listToAdd.Length;
            for (int i = minlength; i <maxlength; i++)
            {
                Array.Resize(ref centralizedList, centralizedList.Length + 1);
                centralizedList[i] = listToAdd[j];
                j++;
            }
            return centralizedList;
            
        }
    }
}
