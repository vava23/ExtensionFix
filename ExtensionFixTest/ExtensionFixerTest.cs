using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExtensionFix;

namespace ExtensionFixTest
{
  [TestClass]
  public class ExtensionFixerTest
  {
    private const string VALID_FILE = "..\\..\\testdata\\ПОВЕСТКА  от 30.11.2017._docx";
    private const string WRONG_FILE = "..\\..\\testdata\\Wrong File.txt";

    [TestMethod]
    public void TestIsValidFile()
    {
      // Valid file
      Assert.AreEqual(ExtensionFixer.IsValidFile(VALID_FILE), true);
      // Non-valid file
      Assert.AreEqual(ExtensionFixer.IsValidFile(WRONG_FILE), false);
      return;
    }
    [TestMethod]
    public void TestProcessFile()
    {
      return;
    }
    [TestMethod]
    public void TestProcessFiles()
    {
      return;
    }
  }
}
