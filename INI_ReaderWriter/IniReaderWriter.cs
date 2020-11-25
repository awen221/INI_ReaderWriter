using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Ini;

namespace INI_ReaderWriter
{
    abstract public class IniReaderWriter
    {
        string colon => ":";
        IniConfigurationProvider iniProvider { set; get; }
        abstract protected string iniPath { get; }

        public IniReaderWriter()
        {
            IniConfigurationSource source = new IniConfigurationSource
            {
                Path = iniPath,
            };
            iniProvider = (IniConfigurationProvider)source.Build(new ConfigurationBuilder());
            iniProvider.Load();
        }

        public bool TryGet(string section, string key, out string value)
        {
            key = section + colon + key;
            return iniProvider.TryGet(key, out value);
        }

        public void Set(string section, string key, string value)
        {
            key = section + colon + key;
            iniProvider.Set(key, value);
        }
    }
}
