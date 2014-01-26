using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace fbLauncher
{

    class BotInstance
    {
        const String ChromePath = "D:\\fbBot\\ChromePortable\\";
        const String ExtensionPath="D:\\fbBot\\plugin";

        public String ChromeInstance { get; set; }
        public String UserAgent { get; set; }
        public String ProxyString { get; set; }
        public DateTime NextClick { get; set; }

        public BotInstance(String _ChromeInstance, String _UserAgent, String _ProxyString, DateTime _NextClick)
        {
            ChromeInstance = _ChromeInstance;
            UserAgent = _UserAgent;
            ProxyString = _ProxyString;
            NextClick = _NextClick;
        }
        public BotInstance(String _Line)
        {
            String[] splitline = _Line.Split('|');
            ChromeInstance = splitline[0];
            UserAgent = splitline[1];
            ProxyString = splitline[2];
            NextClick = DateTime.Parse(splitline[3]);
        }
        public override string ToString()
        {
            return ChromeInstance + "|" + UserAgent + "|" + ProxyString + "|" + NextClick;
        }
        public Boolean Run()
        {
            Process p;
            p = new Process();
            p.StartInfo.FileName = ChromePath + ChromeInstance + "\\GoogleChromePortable.exe";
            p.StartInfo.Arguments = "--proxy-bypass-list=\"127.0.0.1\" " + "--load-extension=\"" + ExtensionPath + "\" --user-agent=\"" + UserAgent + "\" --proxy-server=\"" + ProxyString + "\" " + "\"http://freebitco.in/?r=233824\"";
            p.Start();
            return true;
        }
        public Boolean SimpleRun()
        {
            Process p;
            p = new Process();
            p.StartInfo.FileName = ChromePath + ChromeInstance + "\\GoogleChromePortable.exe";
            p.StartInfo.Arguments = "--user-agent=\"" + UserAgent + "\" --proxy-server=\"" + ProxyString + "\" " + "\"http://freebitco.in/?r=233824\"";
            p.Start();
            return true;
        }
    }
}
