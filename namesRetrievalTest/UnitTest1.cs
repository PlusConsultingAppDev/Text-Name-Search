using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using namesRetrieval.classes;

namespace namesRetrievalTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestNameRetrieval()
        {
            var name1 = new EmpNames("Connor", "Gary", "Smith");
            
            // Test 1
            var fandl1 = "Connor Smith";
            var fmil1 = "Connor G Smith";
            var fmipl1 = "Connor G. Smith";
            var fml1 = "Connor Gary Smith";

            Assert.AreEqual(fandl1, name1.GetFirstLastName());
            Assert.AreEqual(fmil1, name1.GetFirstMidInitLastName());
            Assert.AreEqual(fmipl1, name1.GetFirstMidInitPtLastName());
            Assert.AreEqual(fml1, name1.GetFirstMiddleLastName());

            // Test 2
            var name2 = new EmpNames("Seth", "David", "Greenly");

            var fandl2 = "Seth Greenly";
            var fmil2 = "Seth D Greenly";
            var fmipl2 = "Seth D. Greenly";
            var fml2 = "Seth David Greenly";

            Assert.AreEqual(fandl2, name2.GetFirstLastName());
            Assert.AreEqual(fmil2, name2.GetFirstMidInitLastName());
            Assert.AreEqual(fmipl2, name2.GetFirstMidInitPtLastName());
            Assert.AreEqual(fml2, name2.GetFirstMiddleLastName());

            // Test 3
            var name3 = new EmpNames("David", "Warren", "Black");

            var fandl3 = "David Black";
            var fmil3 = "David W Black";
            var fmipl3 = "David W. Black";
            var fml3 = "David Warren Black";

            Assert.AreEqual(fandl3, name3.GetFirstLastName());
            Assert.AreEqual(fmil3, name3.GetFirstMidInitLastName());
            Assert.AreEqual(fmipl3, name3.GetFirstMidInitPtLastName());
            Assert.AreEqual(fml3, name3.GetFirstMiddleLastName());

        }
    }
}
