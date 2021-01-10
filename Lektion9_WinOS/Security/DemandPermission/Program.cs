using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security;
using System.Security.Permissions;

namespace DemandPermission
{
   class Program
   {
      static void Main(string[] args)
      {
         var my = new MyClass();
         my.Save("Goodbye Earth");
         my.Save("Hello Mars");
      }
   }

   public class MyClass
   {
      private StreamWriter mStream;
      private string mFileName = @"C:\Temp\MyFile.txt";

      public MyClass()
      {
         // The StreamWriter demands permission here only:
         mStream = new StreamWriter(mFileName);
      }

      public void Save(string text)
      {
         // Must demand permission here:
         IPermission permission;
         permission = new FileIOPermission(FileIOPermissionAccess.Write, mFileName);
         permission.Demand();
         mStream.WriteLine(text);
      }
   }
}
