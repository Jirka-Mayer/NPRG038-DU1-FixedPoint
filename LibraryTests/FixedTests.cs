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

        [Test]
        public void ItCanDivide()
        {
            Assert.AreEqual(
                new Fixed<Q24_8>(1).Representation,
                new Fixed<Q24_8>(5).Divide(new Fixed<Q24_8>(5)).Representation
            );

            Assert.AreEqual(
                new Fixed<Q24_8>(2).Representation,
                new Fixed<Q24_8>(10).Divide(new Fixed<Q24_8>(5)).Representation
            );

            Assert.AreEqual(
                new Fixed<Q24_8>(-1).Representation,
                new Fixed<Q24_8>(1).Divide(new Fixed<Q24_8>(-1)).Representation
            );

            Assert.AreEqual(
                new Fixed<Q24_8>(-1).Representation,
                new Fixed<Q24_8>(-1).Divide(new Fixed<Q24_8>(1)).Representation
            );

            Assert.AreEqual(
                new Fixed<Q24_8>(0).Representation,
                new Fixed<Q24_8>(0).Divide(new Fixed<Q24_8>(42)).Representation
            );
        }

        [Test]
        public void ItCanPrintDecimal()
        {
            Assert.AreEqual(
                "0.25",
                new Fixed<Q24_8>(1)
                .Divide(new Fixed<Q24_8>(4))
                .ToString()
            );

            Assert.AreEqual(
                "256",
                new Fixed<Q24_8>(1024)
                .Divide(new Fixed<Q24_8>(4))
                .ToString()
            );
        }

        [Test]
        public void ItCanMultiply()
        {
            Assert.AreEqual(
                new Fixed<Q24_8>(5).Representation,
                new Fixed<Q24_8>(1).Multiply(new Fixed<Q24_8>(5)).Representation
            );

            Assert.AreEqual(
                new Fixed<Q24_8>(10).Representation,
                new Fixed<Q24_8>(2).Multiply(new Fixed<Q24_8>(5)).Representation
            );

            Assert.AreEqual(
                new Fixed<Q24_8>(1).Representation,
                new Fixed<Q24_8>(-1).Multiply(new Fixed<Q24_8>(-1)).Representation
            );

            Assert.AreEqual(
                new Fixed<Q24_8>(-1).Representation,
                new Fixed<Q24_8>(-1).Multiply(new Fixed<Q24_8>(1)).Representation
            );

            Assert.AreEqual(
                new Fixed<Q24_8>(0).Representation,
                new Fixed<Q24_8>(0).Multiply(new Fixed<Q24_8>(42)).Representation
            );
        }

        [Test]
        public void ItCanAddAndSubtract()
        {
            Assert.AreEqual(
                new Fixed<Q24_8>(6).Representation,
                new Fixed<Q24_8>(1).Add(new Fixed<Q24_8>(5)).Representation
            );

            Assert.AreEqual(
                new Fixed<Q24_8>(7).Representation,
                new Fixed<Q24_8>(2).Add(new Fixed<Q24_8>(5)).Representation
            );

            Assert.AreEqual(
                new Fixed<Q24_8>(0).Representation,
                new Fixed<Q24_8>(-1).Subtract(new Fixed<Q24_8>(-1)).Representation
            );

            Assert.AreEqual(
                new Fixed<Q24_8>(-2).Representation,
                new Fixed<Q24_8>(-1).Subtract(new Fixed<Q24_8>(1)).Representation
            );

            Assert.AreEqual(
                new Fixed<Q24_8>(-42).Representation,
                new Fixed<Q24_8>(0).Subtract(new Fixed<Q24_8>(42)).Representation
            );
        }
    }
}
