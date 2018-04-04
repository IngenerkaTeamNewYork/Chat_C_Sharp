using System;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    class GetPut
    {
        private static void Base(String exe, String param1, String param2)
        {
            Process myProcess = Process.Start("cmd", "/C start /B " + exe + " " + param1 + " " + param2);
            do
            {
                if (!myProcess.HasExited)
                {
                    // Refresh the current process property values.
                    myProcess.Refresh();
                }
            }
            while (!myProcess.WaitForExit(10000));
        }
        public static void Get(String filenameserv, String filenamelocal=null)
        {
            if (filenamelocal == null)
            {
                filenamelocal = filenameserv;
            }
            Base("get.exe", filenameserv, filenamelocal);
        }
        public static void Put(String filenamelocal, String filenameserv=null)
        {
            if (filenameserv == null)
            {
                filenameserv = filenamelocal;
            }
            Base("put.exe", filenamelocal, filenameserv);
        }
    }
}
