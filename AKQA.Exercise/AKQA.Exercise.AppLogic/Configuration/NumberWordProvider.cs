using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Configuration;
using System.Xml;
using System.Web;

namespace AKQA.Exercise.AppLogic.Configuration
{
    public class NumberWordProvider
    {
        private string _configurationSectionName;
        private NameValueCollection _settings;
        public string ConfigFilePath { get; set; }

        public NumberWordProvider()
        {
            _configurationSectionName = "NumWordsConvert";
            var s = ConfigurationManager.GetSection(_configurationSectionName);
            _settings = (NameValueCollection)s;
            ConfigFilePath = GetConfigFilePath();
        }

        public NumberWordConfig BuildConfiguration()
        {
            if (string.IsNullOrWhiteSpace(ConfigFilePath) || !File.Exists(ConfigFilePath))
                return null;

            var numberWordXml = new XmlDocument();
            numberWordXml.Load(ConfigFilePath);

            var path = "/NumbWords/Node";
            var xnList = numberWordXml.SelectNodes(path);
            var mappings = new Dictionary<int, string>();

            foreach (XmlNode xn in xnList)
            {
                var numberStr = xn.Attributes["number"].Value;
                var word = xn.Attributes["word"].Value;
                mappings.Add(Int32.Parse(numberStr), word);
            }

            return new NumberWordConfig()
            {
                NumberWords = mappings
            };
        }

        public string GetEntry(string key)
        {
            if (_settings[key] != null)
                return _settings[key];
            else
                throw new ConfigurationErrorsException("Key " + key +
                    " is not defined in configuration section " + 
                    _configurationSectionName);
        }

        private string GetConfigFilePath()
        {
            var path = GetEntry("NumWordsConvertPath");
            if (HttpContext.Current == null)
                return string.Empty;

            return HttpContext.Current.Server.MapPath(@"~/" + path);
        }
    }
}
