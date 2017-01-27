using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RepairCenter
{
    public struct RepairCase
    {
        public string caseName;
        public string priority;
        public RepairCase(string caseName,string priority)
        {
            this.caseName = caseName;
            this.priority = priority;
        }

    }
    [TestClass]
    public class RepairCenterTest
    {
        [TestMethod]
        public void TestSortCasesAccordintToPriority()
        {
            var cases = new RepairCase[] { new RepairCase("phone", "Medium"), new RepairCase("tv", "High"), new RepairCase("iPhone", "Low"), new RepairCase("Boombox", "Medium") };
            CollectionAssert.AreEqual(new RepairCase[] { new RepairCase("iPhone", "Low"), new RepairCase("phone", "Medium"), new RepairCase("Boombox", "Medium"), new RepairCase("tv", "High") }, SortCasesAccordingToPriorityUsingSelection(cases));
        }

        [TestMethod]
        public void TestSwapFunction()
        {
            var casesToSwap = new RepairCase[] { new RepairCase("ItemOne", "Low"), new RepairCase("ItemTwo", "High") };
            CollectionAssert.AreEqual(new RepairCase[] { new RepairCase("ItemTwo", "High"), new RepairCase("ItemOne", "Low") }, SwapCasesAccordingToPriority(ref casesToSwap, 0, 1));
        }

        [TestMethod]
        public void TestReturnCasePriorityInIngeger()
        {
            Assert.AreEqual(2, ReturnCasePriorityInInteger(new RepairCase("Phone", "Medium")));
        }

        public RepairCase[] SortCasesAccordingToPriorityUsingSelection(RepairCase[] repairCases)
        {
            int k;
            for(int i = 0; i < repairCases.Length; i++)
            {
                k = i;
                k = GetPositionOfTheNextLowestValue(repairCases, k, i);
                if (k != i)
                    SwapCasesAccordingToPriority(ref repairCases, i, k);
            }
            return repairCases;
        }

        private int GetPositionOfTheNextLowestValue(RepairCase[] repairCases, int k, int i)
        {
            for (int j = i + 1; j < repairCases.Length; j++)
                if (ReturnCasePriorityInInteger(repairCases[j]) < ReturnCasePriorityInInteger(repairCases[k]))
                    k = j;
            return k;
        }

        public int ReturnCasePriorityInInteger(RepairCase repairCase)
        {
            int i = 1;
            if (repairCase.priority == "Medium")
                i = 2;
            if (repairCase.priority == "High")
                i = 3;
            return i;
        }

        public RepairCase[] SwapCasesAccordingToPriority(ref RepairCase[] repairCases,int i,int j)
        {
            var temp = repairCases[i];
            repairCases[i].caseName = repairCases[j].caseName;
            repairCases[i].priority = repairCases[j].priority;
            repairCases[j].caseName = temp.caseName;
            repairCases[j].priority = temp.priority;
            return repairCases;
        }
    }
}
