using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ExtensionFix
{
  public class ExtensionFixer
  {
    // Extensions that can be fixed
    public static readonly string[] EXT_TO_FIX = { "._docx" };
    // Correct extensions corresponding to bad ones, in their order
    public static readonly string[] EXT_CORRECT = { ".docx" };

    public void Main(String aFileName)
    {

    }

    //
    // Checks if the string contains path to a file with proper extension
    //
    public static bool IsValidFile(String aStr)
    {
      // Check if its an existing file
      if (File.Exists(aStr))
      {
        // Check if the extension is in our list of extensions to fix
        string ext = Path.GetExtension(aStr);
        if (EXT_TO_FIX.Contains(ext)) 
          return true;
        else
          return false;
      }
      return false;
    }


    //
    // Tries to convert file
    //
    public static string FixAFile(string aFileName)
    {
      if (IsValidFile(aFileName))
      {

      }
      return "";
    }

    //
    // Tries to convert files in the list
    // Returns number of files converted
    //
    public static string[] FixFiles(string[] aFiles)
    {
      // Create a list to populate it with result files
      List<string> result = new List<string>();
      string tmpResult;
      foreach (string tmpFile in aFiles)
      {
        if (ExtensionFixer.IsValidFile(tmpFile))
        {
          tmpResult = ExtensionFixer.FixAFile(tmpFile);
          if (tmpResult.Length > 0)
          {
            result.Add(tmpResult);
          }
        }
      }
      return result.ToArray();
    }
  }
}
