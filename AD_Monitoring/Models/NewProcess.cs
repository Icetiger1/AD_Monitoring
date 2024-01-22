using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_Monitoring.Models
{
    public class NewProcess
    {
        private Process myprocess = new();

        public void Start()
        {
            this.myprocess.Start();
        }

        public void Close()
        {
            this.myprocess.Close();
        }

        public void WaitForExit()
        {
            this.myprocess.WaitForExit();
        }

        public void SetAguments(string fileName, string compName)
        {
            this.myprocess.StartInfo.Verb = "runas";
            this.myprocess.StartInfo.FileName = (fileName);
            this.myprocess.StartInfo.Arguments = $"{compName}";
            //("/v:" + compName);

        }

        public void SetAguments(string fileName, string agument, string compName)
        {
            this.myprocess.StartInfo.Verb = "runas";
            this.myprocess.StartInfo.FileName = (fileName);
            this.myprocess.StartInfo.Arguments = $"{agument} {compName}";
            //("/v:" + compName);

        }

        public void SetAguments(string fileName, string agument, string agument2, string compName)
        {
            this.myprocess.StartInfo.Verb = "runas";
            this.myprocess.StartInfo.FileName = (fileName);
            this.myprocess.StartInfo.Arguments = $"{agument} {compName} {agument2}";
        }

        public void SetStyle(bool createNoWindow, ProcessWindowStyle ProcessWS, bool useShellExecute)
        {
            this.myprocess.StartInfo.CreateNoWindow = createNoWindow;
            this.myprocess.StartInfo.WindowStyle = ProcessWS;
            this.myprocess.StartInfo.UseShellExecute = false;
        }
        public void SetStandardOutput(bool status)
        {
            this.myprocess.StartInfo.RedirectStandardOutput = true;
        }

        public void SetStandardOutputEncoding(Encoding encoding)
        {
            this.myprocess.StartInfo.StandardOutputEncoding = encoding;
        }

        public string ResultProcess()
        {
            string? output = myprocess.StandardOutput.ReadToEnd();

            return output;
        }
    }
}
