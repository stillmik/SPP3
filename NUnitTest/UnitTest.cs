using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using SppLab3;

namespace NUnitTest
{
    public static class Extension
    {
        public static int EM(this Tests t, int x) => x;
    }
    public class Tests
    {
        private AssemblyData ad;
        private string PATH = @"..\netcoreapp3.1\NUnitTest.dll";
        public string P { get; set; }
        public int x;
        [SetUp]
        public void Setup()
        {
            ad = SppLab3.AssemblyBrowser.GetAssemblyData(PATH);
        }

        [Test]
        public void TestAssemblyBrowser()
        {
            Assert.AreEqual(ad.Name, "NUnitTest");
            Assert.AreEqual(ad.Namespaces.Count, 1);
            Assert.AreEqual(ad.Namespaces[0].Name, "NUnitTest");
            Assert.AreEqual(ad.Namespaces[0].Classes.Count, 2);
            Assert.AreEqual(ad.Namespaces[0].Classes[0].Name, "Extension");

            Assert.AreEqual(ad.Namespaces[0].Classes[0].Members.Count, 3);
            Assert.AreEqual(ad.Namespaces[0].Classes[0].Members[0].Name, "Fields");
            Assert.AreEqual(ad.Namespaces[0].Classes[0].Members[1].Name, "Properties");
            Assert.AreEqual(ad.Namespaces[0].Classes[0].Members[2].Name, "Methods");
            Assert.AreEqual(ad.Namespaces[0].Classes[0].Members[0].Items.Count, 0);
            Assert.AreEqual(ad.Namespaces[0].Classes[0].Members[1].Items.Count, 0);
            Assert.AreEqual(ad.Namespaces[0].Classes[0].Members[2].Items.Count, 6);

            Assert.AreEqual(ad.Namespaces[0].Classes[1].Name, "Tests");
            Assert.AreEqual(ad.Namespaces[0].Classes[1].Members.Count, 3);
            Assert.AreEqual(ad.Namespaces[0].Classes[1].Members[0].Name, "Fields");
            Assert.AreEqual(ad.Namespaces[0].Classes[1].Members[1].Name, "Properties");
            Assert.AreEqual(ad.Namespaces[0].Classes[1].Members[2].Name, "Methods");
            Assert.AreEqual(ad.Namespaces[0].Classes[1].Members[0].Items.Count, 3);
            Assert.AreEqual(ad.Namespaces[0].Classes[1].Members[1].Items.Count, 1);
            Assert.AreEqual(ad.Namespaces[0].Classes[1].Members[2].Items.Count, 11);
            Assert.AreEqual(ad.Namespaces[0].Classes[1].Members[2].Items[10], "Extension:Int32 EM(NUnitTest.Tests, Int32)");
        }

        [Test]
        public void AssemblyIsNotEmpty()
        {   
            int expected = 0;
            int actual = ad.Namespaces.Count;
            Assert.AreNotEqual(expected,actual);
        }

        [Test]
        public void CorrectClassCount()
        {
            int expected = 2;
            int actual = ad.Namespaces[0].Classes.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ClassHasCorrectMembersCount()
        {
            int expected = 3;
            int actual = ad.Namespaces[0].Classes[0].Members.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IncorrectAssemblyPathTest()
        {
            string path = "../WRONG_PATH//Assembly.dll";
            Assert.Throws<FileNotFoundException>(() => SppLab3.AssemblyBrowser.GetAssemblyData(path));
        }
    }
}