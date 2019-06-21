using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ExtensionFix
{
  class ExtensionFixer
  {
    public void Main(String aFileName)
    {

    }

    //
    // Checks if the string contains path to a file with proper extension
    //
    public static bool IsValidFile(String aStr)
    {
      // Check if its an existing file
      if(File.Exists(aStr))
      {
        // TODO
        return true;
      }
      return false;
    }


    //
    // Tries to convert file
    //
    public static bool ProcessFile(string aFileName)
    {
      return true;
    }

    //
    // Tries to convert files in the list
    // Returns number of files converted
    //
    public static int ProcessFiles(string[] aFiles)
    {
      int cnt = 0;
      foreach (string tmpFile in aFiles)
      {
        if (ExtensionFixer.IsValidFile(tmpFile))
        {
          if (ExtensionFixer.ProcessFile(tmpFile))
          { cnt++; }
        }
      }
      return cnt;
    }
  }
}
