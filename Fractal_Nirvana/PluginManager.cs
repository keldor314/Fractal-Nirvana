using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

namespace Fractal_Nirvana
{
    class PluginManager<T>
    {
        public static List<Type> Plugins { get; private set; }

        static PluginManager()
        {
            Plugins = new List<Type>();
            LoadPluginsFromDirectory(Environment.CurrentDirectory + "\\Plugins");
        }

        public static void LoadPluginsFromDirectory(string directory)
        {
            foreach (var file in Directory.GetFiles(directory, "*.dll"))
                LoadPluginsFromFile(file);
        }

        public static void LoadPluginsFromFile(string file)
        {
            foreach (var type in Assembly.LoadFrom(file).GetTypes())
            {
                if (type.GetInterface(typeof(T).Name) != null)
                    Plugins.Add(type);
            }
        }

        public static T CreateInstance(Type plugin)
        {
            return (T)Activator.CreateInstance(plugin);
        }
    }
}
