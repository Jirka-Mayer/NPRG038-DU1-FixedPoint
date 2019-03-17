using NUnit.Framework;
using System;
using Cuni.Arithmetics.FixedPoint;

namespace LibraryTests
{
    [TestFixture()]
    public class FixedTests
    {
        [Test()]
        public void ItCanBeConstructedAndPrinted()
        {
            Assert.AreEqual("5", new Fixed<Q24_8>(5).ToString());
            Assert.AreEqual("42", new Fixed<Q24_8>(42).ToString());
            Assert.AreEqual("-8", new Fixed<Q24_8>(-8).ToString());
            Assert.AreEqual("0", new Fixed<Q24_8>(0).ToString());
            Assert.AreEqual("-1", new Fixed<Q24_8>(-1).ToString());
        }
    }
}
