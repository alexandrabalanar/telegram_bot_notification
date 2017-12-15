using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using revcom_bot;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            bool check;
            string level ="11";
            Validation valid = new Validation();
            check = valid.ValidLevel(level);
            Assert.AreEqual(false, check); 
        }

        [TestMethod]
        public void TestMethod2()
        {
            bool check;
            string level = "-1";
            Validation valid = new Validation();
            check = valid.ValidLevel(level);
            Assert.AreEqual(false, check);
        }

        [TestMethod]
        public void TestMethod3()
        {
            bool check;
            string level = "1";
            Validation valid = new Validation();
            check = valid.ValidLevel(level);
            Assert.AreEqual(true, check);
        }

        [TestMethod]
        public void TestMethod4()
        {
            bool check;
            string nlevel = "10";
            Validation valid = new Validation();
            check = valid.ValidLevel(nlevel);
            Assert.AreEqual(true, check);
        }


        [TestMethod]
        public void TestMethod5()
        {
            bool check;
            string name = "";
            Validation valid = new Validation();
            check = valid.ValidName(name);
            Assert.AreEqual(false, check);
        }


        [TestMethod]
        public void TestMethod6()
        {
            bool check;
            string name = " ";
            Validation valid = new Validation();
            check = valid.ValidName(name);
            Assert.AreEqual(false, check);
        }

        [TestMethod]
        public void TestMethod7()
        {
            bool check;
            string name = "meow";
            Validation valid = new Validation();
            check = valid.ValidName(name);
            Assert.AreEqual(true, check);
        }


   
    }
}
