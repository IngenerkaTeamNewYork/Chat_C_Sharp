using System;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    class GetPut
    {
        private static void Base(String exe, String param1, String param2)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd",  // Путь к приложению
                UseShellExecute = false,
                CreateNoWindow = true,
                Arguments = "/S /C start /B " + exe + " " + param1 + " " + param2
            };
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