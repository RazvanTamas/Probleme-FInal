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

        public RepairCase[] SortCasesAccordingToPriorityUsingSelection(RepairCase[] repairCases)
        {
            int k;
            for(int i = 0; i < repairCases.Length; i++)
            {
                k = i;
                for (int j = i + 1; j < repairCases.Length; j++)
                {
                    if (ReturnCasePriorityInInteger(repairCases[j]) < ReturnCasePriorityInInteger(repairCases[k]))
                        k = j;              
                }
                if (k != i)
                    SwapCasesAccordingToPriority(ref repairCases, i, k);
            }
            return repairCases;
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
