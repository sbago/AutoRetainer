using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRetainer.Language
{
    internal static class LanguageManager
    {
        public static Dictionary<LanguageType, Language> AllLans = new Dictionary<LanguageType, Language>();

        public static Language Init(LanguageType languageType, string dir = "Language")
        {
            Directory.CreateDirectory(dir);
            var files = Directory.GetFiles(dir, "Lan_*.toml");


            //Init EN
            var defaultLan = new Language();
            SerializeHelper.WriteToFile(Path.Combine(dir, $"Lan_{(defaultLan.LanType).ToString()}.toml"), defaultLan);
            if (files == null || files.Length == 0)
            {
                foreach (var v in Enum.GetValues<LanguageType>())
                {
                    var lan = new Language()
                    {
                        LanType = v
                    };
                    AllLans.Add(v, lan);
                    SerializeHelper.WriteToFile(Path.Combine(dir, $"Lan_{v.ToString()}.toml"), lan);
                }
            }
            else
            {
                AllLans.Clear();

                foreach (var v in files)
                {
                    try
                    {
                        if (v.Contains((defaultLan.LanType).ToString()))
                        {
                            continue;
                        }
                        var lan = SerializeHelper.LoadFrom<Language>(v, out var a);
                        AllLans.Add(lan.LanType, lan);
                    }
                    catch (Exception e)
                    {
                        PluginLog.Error(e.ToString());
                    }
                }
            }


            AllLans[defaultLan.LanType] = defaultLan;
            if (!AllLans.TryGetValue(languageType, out var targetLan))
            {
                PluginLog.Error("Cant found target language!" + languageType.ToString());
                return null;
            }
            return targetLan;

        }

        public static Language GetLan(LanguageType languageType)
        {
            if (!AllLans.TryGetValue(languageType, out var targetLan))
            {
                PluginLog.Error("Cant found target language!" + languageType);
                return null;
            }

            return targetLan;
        }
    }
}
