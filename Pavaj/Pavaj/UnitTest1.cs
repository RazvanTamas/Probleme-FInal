using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pavaj
{
    [TestClass]
    public class Testpavaj
    {


        [TestMethod]
        public void TestPtPiata6x6sipiatra4x4()
        {
            int numar = nrbucatipietre(6, 6, 4);
            Assert.AreEqual(4, numar);

        }
        [TestMethod]
        public void TestPtPiata9x9sipiatra4x4()
        {
            int numar = nrbucatipietre(9, 9, 4);
            Assert.AreEqual(9, numar);

        }
        [TestMethod]
        public void TestPtPiata9x6sipiatra2x2()
        {
            int numar = nrbucatipietre(9, 6, 2);
            Assert.AreEqual(15, numar);

        }
        int nrbucatipietre(double m,double n,double a)
        {
            
            int numar1 =(int) Math.Ceiling(m/a);

            int numar2 = (int)Math.Ceiling(n/a); 

            int numar = numar1 * numar2; 

                 
               
       

            return numar;
        }
    }

}
