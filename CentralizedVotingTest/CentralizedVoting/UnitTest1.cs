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
        public void TestMethod1()
        {
            var list1 = new Politician[] { new Politician("Radu", 1000), new Politician("Andrew", 900), new Politician("John", 500) };
            var list2 = new Politician[] { new Politician("Michael", 1030), new Politician("Kennedy", 722), new Politician("Oliver", 178), new Politician("Stanley", 55) };
            var list3 = new Politician[] { new Politician("Ulrich", 2000), new Politician("Paul", 500)};

            CollectionAssert.AreEqual(new Politician[] { new Politician("Ulrich", 2000), new Politician("Michael", 1030), new Politician("Radu", 1000), new Politician("Andrew", 900), new Politician("Kennedy", 722), new Politician("John", 500), new Politician("Paul", 500), new Politician("Oliver", 178), new Politician("Stanley", 55)},CentralizedList(list1,list2,list3));
        }

        Politician[] CentralizedList(Politician[] list1, Politician[] list2, Politician[] list3)
        {
            return new Politician[] { new Politician("Ulrich", 2000), new Politician("Michael", 1030), new Politician("Radu", 1000), new Politician("Andrew", 900), new Politician("Kennedy", 722), new Politician("John", 500), new Politician("Paul", 500), new Politician("Oliver", 178), new Politician("Stanley", 55) };
        }
    }
}
