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
        public void CorrectClassExtensionName()
        {
            string expected = "Extension";
            string actual = ad.Namespaces[0].Classes[0].Name;
            Assert.AreEqual(expected,actual);
        }
        
        [Test]
        public void CorrectClassTestsFieldsCount()
        {
            int expected = 4;
            int actual = ad.Namespaces[0].Classes[1].Members[0].Items.Count;
            Assert.AreEqual(expected,actual);
        }
        
        [Test]
        public void CorrectClassTestsPropertiesCount()
        {
            int expected = 1;
            int actual = ad.Namespaces[0].Classes[1].Members[1].Items.Count;
            Assert.AreEqual(expected,actual);
        }
        
        [Test]
        public void CorrectClassTestsMethodsCount()
        {
            int expected = 23;
            int actual = ad.Namespaces[0].Classes[1].Members[2].Items.Count;
            Assert.AreEqual(expected,actual);
        }
        
        [Test]
        public void CorrectClassTestsName()
        {
            string expected = "Tests";
            string actual = ad.Namespaces[0].Classes[1].Name;
            Assert.AreEqual(expected,actual);
        }
        
        [Test]
        public void CorrectClassExtensionFieldsCount()
        {
            int expected = 0;
            int actual = ad.Namespaces[0].Classes[0].Members[0].Items.Count;
            Assert.AreEqual(expected,actual);
        }
        
        [Test]
        public void CorrectClassExtensionPropertiesCount()
        {
            int expected = 0;
            int actual = ad.Namespaces[0].Classes[0].Members[1].Items.Count;
            Assert.AreEqual(expected,actual);
        }
        
        [Test]
        public void CorrectClassExtensionMethodsCount()
        {
            int expected = 6;
            int actual = ad.Namespaces[0].Classes[0].Members[2].Items.Count;
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void ExtensionInfo()
        {
            string expected = ad.Namespaces[0].Classes[1].Members[2].Items[22];
            string actual = "Extension:Int32 EM(NUnitTest.Tests, Int32)";
            Assert.AreEqual(expected,actual );
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