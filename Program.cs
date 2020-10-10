using System;
using System.IO;

namespace curaSettingParser
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args?.Length == 0 || !File.Exists(args[0])) return;
            try
            {
                var settingsTag = ";SETTING_3 ";
                var indexOffset = settingsTag.Length;
                var sr = new StreamReader(args[0]);
                var settingStr = "";

                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if (string.IsNullOrEmpty(line) || !line.StartsWith(settingsTag)) continue;
                    settingStr += line.Substring(indexOffset);
                }
                if (string.IsNullOrEmpty(settingStr)) return;
                var cleanedLine = settingStr.Replace("\\\\n", "\r\n");
                Console.WriteLine(cleanedLine);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
