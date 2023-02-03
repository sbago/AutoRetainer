using System;
using System.IO;
using Tomlet;

namespace AutoRetainer.Language
{
    public static class SerializeHelper
    {
        public static void WriteToFile(string path, object src)
        {
            File.WriteAllText(path, TomletMain.TomlStringFrom(src));
        }

        public static object LoadFrom(string path, Type type)
        {
            var parser = new TomlParser();
            var tomlDocument = parser.Parse(File.ReadAllText(path));
            return TomletMain.To(type, tomlDocument);
        }

        public static T LoadFrom<T>(string path,out string a)
        {
            a = File.ReadAllText(path);
            return TomletMain.To<T>(File.ReadAllText(path));
        }
    }
}