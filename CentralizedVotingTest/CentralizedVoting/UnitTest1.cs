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

        [TestMethod]
        public void TestSwapFunction()
        {
            var politicianOne = new Politician("Johny", 3000);
            var politicianTwo = new Politician("Swap Me", 1000);
            SwapPoliticiansInList(ref politicianOne, ref politicianTwo);
            Assert.AreEqual(politicianOne, new Politician("Swap Me", 1000));
        }

        Politician[] CentralizedList(Politician[][] lists)
        {
            var centralizedList = new Politician[0];
            for (int i = 0; i < lists.Length; i++)
            {
                centralizedList = AddListsTogether(ref centralizedList, lists[i]);
            }
            centralizedList = SortCentralizedList(ref centralizedList);
            return centralizedList;
        }
        Politician[] AddListsTogether(ref Politician[] centralizedList, Politician[] listToAdd)
        {
            int j = 0;
            int start = centralizedList.Length;
            int end = centralizedList.Length + listToAdd.Length;
            for (int i = start; i <end; i++)
            {
                Array.Resize(ref centralizedList, centralizedList.Length + 1);
                centralizedList[i] = listToAdd[j];
                j++;
            }
            return centralizedList;           
        }

        Politician[] SortCentralizedList(ref Politician[] centralizedList)
        {
            bool inOrder = false;
            while (inOrder == false)
            {
                inOrder = true;
                for (int i = 0; i < centralizedList.Length - 1; i++)
                {
                    inOrder = CheckNumberOfVotes(inOrder, centralizedList, i);
                }
            }
            return centralizedList;
        }

        private bool CheckNumberOfVotes(bool inOrder, Politician[] centralizedList, int i)
        {
            if (centralizedList[i].Votes < centralizedList[i + 1].Votes)
            {
                inOrder = false;
                SwapPoliticiansInList(ref centralizedList[i], ref centralizedList[i + 1]);
            }
            return inOrder;
        }

        public static void SwapPoliticiansInList(ref Politician politicianOne,ref Politician politicianTwo)
        {
            var temp = politicianOne;
            politicianOne.Name = politicianTwo.Name;
            politicianOne.Votes = politicianTwo.Votes;
            politicianTwo.Name = temp.Name;
            politicianTwo.Votes = temp.Votes;         
        }
    }
}
