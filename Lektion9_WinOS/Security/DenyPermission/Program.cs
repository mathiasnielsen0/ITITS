using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security;
using System.Security.Permissions;

namespace DenyPermission
{
   class Program
   {
      static void Main(string[] args)
      {
      }
   }

   public class MyClass
   {
      public void foo()
      {
         string[] drives = Environment.GetLogicalDrives();

         IStackWalk stackWalker;
         stackWalker = new FileIOPermission(FileIOPermissionAccess.Write, drives);

         stackWalker.Deny();

         // QuestableComponent is a class in an not trusted assembly
         //QuestableComponent obj = new QuestableComponent();
         //obj.DoSomething();

         CodeAccessPermission.RevertDeny();

         // Do more work
      }
   }
}
