using System;
using System.Collections;
using System.Collections.Specialized;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace LogIn
{

    [XmlRoot(Namespace = "", IsNullable = false)]
    public class ServicesConfig
    {

        [XmlAttribute]
        public int DownloadTimeOut = 10000;

        [XmlAttribute]
        public bool ShowTestLinks = false;

        [XmlAttribute]
        public bool UseLocalList = false;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public EnvironmentConfig[] EnvironmentConfig { get; set; }
        public EnvironmentConfig GetEnvironmentConfig(string environment)
        {

            foreach (EnvironmentConfig ec in this.EnvironmentConfig)
            {
                string env = ec.FullName;
                if (String.Compare(env, environment, true) == 0)
                    return ec;
            }
            return null;
        }

    }

    public class EnvironmentConfig
    {

        [XmlIgnore]
        public string FullName
        {
            get
            {
                return string.Format("{0} ({1})", Name, AppId);
            }
        }

        public string DnsSuffix;    // comma separated

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public ServiceLocation[] ServiceLocation;

        [XmlAttribute]
        public string Name;

        [XmlAttribute]
        public string AppId;

        private HybridDictionary mUrlList = new HybridDictionary();
        private HybridDictionary mUrlIdx = new HybridDictionary();

        public void TryNextUrl(string serviceName)
        {
            ArrayList urls = (ArrayList)mUrlList[serviceName];
            int current = GetUrlIndex(serviceName);
            try
            {
                mUrlIdx[serviceName] = (current + 1) % urls.Count;
                // TODO we may want to save this index in registry
            }
            catch
            {
            }

        }

        public int GetUrlIndex(string serviceName)
        {
            ArrayList urls = (ArrayList)mUrlList[serviceName];
            if (mUrlIdx.Contains(serviceName))
                return ((int)mUrlIdx[serviceName]) % urls.Count;
            return 0;
        }

        public string GetUrl(string serviceName)
        {
            ArrayList urls = (ArrayList)mUrlList[serviceName];
            if (urls == null)
            {
                urls = new ArrayList();
                foreach (ServiceLocation sl in this.ServiceLocation)
                {
                    if (String.Compare(sl.ServiceName, serviceName, true) == 0)
                    {
                        foreach (string url in sl.Url)
                            urls.Add(url);
                    }
                }
                mUrlList[serviceName] = urls;
            }
            int idx = GetUrlIndex(serviceName);
            return (string)urls[idx];
        }

    }

    /// <remarks/>
    public class ServiceLocation
    {

        /// <remarks/>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string[] Url;

        /// <remarks/>
        [XmlAttribute]
        public string ServiceName;
    }


}