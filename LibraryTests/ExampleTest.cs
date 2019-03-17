using NUnit.Framework;
using System;
using FixedPointLibrary;

namespace LibraryTests
{
    [TestFixture()]
    public class ExampleTest
    {
        [Test()]
        public void TestCase()
        {
            var c = new MyClass();

            Assert.True(c != null);
        }
    }
}
