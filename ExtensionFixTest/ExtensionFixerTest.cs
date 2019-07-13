using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using ExtensionFix;

namespace ExtensionFixTest
{
  [TestClass]
  public class ExtensionFixerTest
  {
    private const string PROPER_FILE_1 = "..\\..\\testdata\\ПОВЕСТКА  от 30.11.2017._docx";
    private const string PROPER_FILE_1_FIXED = "..\\..\\testdata\\temp\\ПОВЕСТКА  от 30.11.2017.docx";
    private const string PROPER_FILE_2 = "..\\..\\testdata\\Новгор.-доп._docx";
    private const string PROPER_FILE_2_FIXED = "..\\..\\testdata\\temp\\Новгор.-доп.docx";
    private const string HEALTHY_FILE = "..\\..\\testdata\\Wrong File.txt";

    private string GetTempDir()
    {
      // Simply create the directory without any precautions
      const string TMP_DIR = "..\\..\\testdata\\temp";
      if (!(Directory.Exists(TMP_DIR)))
        Directory.CreateDirectory(TMP_DIR);
      return TMP_DIR;
    }

    private string CopyFileToDir(string aFile, string aDir)
    {
      string dst = aDir + "\\" + Path.GetFileName(aFile);
      File.Copy(aFile, dst, true);
      return dst;
    }

    [TestMethod]
    public void TestIsValidFile()
    {
      // Valid file
      Assert.AreEqual(ExtensionFixer.IsValidFile(PROPER_FILE_1), true);
      // Non-valid file
      Assert.AreEqual(ExtensionFixer.IsValidFile(HEALTHY_FILE), false);
      return;
    }
    private void DoTestAFile(string aFile, string aExpectedResult)
    {
      // Copy the file to temp directory
      aFile = CopyFileToDir(aFile, GetTempDir());
      // Try to fix it
      string result = ExtensionFixer.FixAFile(aFile);
      // Check that the file exists
      if (aExpectedResult != "")
        Assert.IsTrue(File.Exists(result));
      // Check the result vs expected
      Assert.AreEqual(result, aExpectedResult);
      // Delete the result file and temp src file
      if (File.Exists(result))
        File.Delete(result);
      File.Delete(aFile);
      return;
    }

    [TestMethod]
    public void TestFixAFile()
    {
      // Run test on proper file, check
      DoTestAFile(PROPER_FILE_1, PROPER_FILE_1_FIXED);
      // Run test on healthy file, check
      DoTestAFile(HEALTHY_FILE, "");
      return;
    }
    [TestMethod]
    public void TestFixFiles()
    {
      const int NUM_FILES_TO_FIX = 2;
      // Generate a list of files, both proper and not 
      string[] files = new string[3]
      {
        PROPER_FILE_1,
        PROPER_FILE_2,
        HEALTHY_FILE
      };
      // Copy the files to temp directory
      string tempDir = GetTempDir();
      for (int i = 0; i < files.Length; i++)
      {
        files[i] = CopyFileToDir(files[i], tempDir);
      }
      // Perform the fix
      string[] result = ExtensionFixer.FixFiles(files);
      // Delete the result files and temp src files
      foreach (string tmpFile in result)
      {
        File.Delete(tmpFile);
      }
      foreach (string tmpFile in files)
      {
        File.Delete(tmpFile);
      }
      // Check just the result quantity
      Assert.AreEqual(result.Length, NUM_FILES_TO_FIX);
      return;
    }
  }
}
