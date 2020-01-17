using System;
using System.IO;
using System.Linq;
using BFCore.Config;

namespace BFWpf.Models.Config
{
    public class ConfigFactory
    {
        public T Create<T>()
        {
            var name = typeof(T).Name;

            if (!(typeof(T) == typeof(CommonConfig) || typeof(T) == typeof(BFCommandConfig)))
            {
                throw new Exception($"{name} is not approved type.");
            }

            var di = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory));

            var file = di.GetFiles($"{name}.json", SearchOption.AllDirectories).FirstOrDefault();

            if (file != null && file.Exists)
            {
                return ConfigManager.Import<T>(file.OpenRead());
            }
            else
            {
                return (T)typeof(T).GetConstructor(Type.EmptyTypes).Invoke(null);
            }
        }
    }
}
