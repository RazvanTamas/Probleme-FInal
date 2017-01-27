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
        public void TestMethod1()
        {
        }

        public RepairCase[] SortCasesAccordingToPriority(RepairCase[] repairCases)
        {
            for(int i = 0; i < repairCases.Length; i++)
            {
                int x = 0;
            }
            return repairCases;
        }
    }
}
