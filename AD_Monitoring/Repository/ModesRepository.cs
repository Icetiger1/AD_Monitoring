using AD_Monitoring.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AD_Monitoring.Repository
{
    public class ModesRepository
    {
        private NewProcess myprocess = new();

        public void Mstsc(string cn)
        {
            this.myprocess.SetAguments("mstsc.exe", $"/v:{cn}");
            this.myprocess.Start();
            this.myprocess.Close();
        }

        public void Compmgmt(string cn)
        {
            this.myprocess.SetStyle(true, ProcessWindowStyle.Hidden, false);
            this.myprocess.SetAguments(
                "cmd.exe",
                "/k mmc.exe compmgmt.msc /computer:",
                cn);
            this.myprocess.Start();
            this.myprocess.Close();
        }

        public void CmRcViewer(string cn)
        {
            string path = Application.StartupPath;
            string fileName = @"\ConfMgr 2012 Remote Tools\CmRcViewer.exe";

            this.myprocess.SetAguments(path + fileName, cn);
            this.myprocess.Start();
            this.myprocess.Close();
        }

        public string? PSLogin(string cn)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            string fileName = @"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe";
            string ps = $"Get-WMIObject -Class Win32_ComputerSystem -Computer \"{cn}\"|Select-Object Username";

            this.myprocess.SetAguments(fileName, ps);
            this.myprocess.SetStyle(true, ProcessWindowStyle.Hidden, false);
            this.myprocess.SetStandardOutput(true);
            this.myprocess.SetStandardOutputEncoding(Encoding.GetEncoding(866));
            this.myprocess.Start();

            string? output = myprocess.ResultProcess();
            string? us;
            try
            {
                string[] mass1 = output.Split('R').ToArray();
                string text = mass1[1];
                us = text.Split(new[] { '\\' }, StringSplitOptions.RemoveEmptyEntries)[1];
                this.myprocess.WaitForExit();
                this.myprocess.Close();

                return us;
            }
            catch
            {
                us = null;
                Cursor.Current = Cursors.Default;
                return us;
            }

        }

        public void OpenDiskC(string cn)
        {
            this.myprocess.SetAguments("explorer.exe", @$"\\{cn}\\c$");
            this.myprocess.Start();
            this.myprocess.Close();
        }

        public void ShareFolders(string cn)
        {
            this.myprocess.SetAguments("explorer.exe", @$"\\{cn}\\");
            this.myprocess.Start();
            this.myprocess.Close();
        }

        public void ShutDown(string cn, string key)
        {
            this.myprocess.SetStyle(true, ProcessWindowStyle.Hidden, true);
            this.myprocess.SetAguments(@"C:\Windows\System32\cmd.exe", @$"/k shutdown /m \\{cn}{key}");
            this.myprocess.Start();
            this.myprocess.Close();
        }

        public string Ping(string cn)
        {
            Cursor.Current = Cursors.WaitCursor;
            int timeout = 100;
            int maxTTL = 4;
            int bufferSize = 4;

            byte[] buffer = new byte[bufferSize];
            new Random().NextBytes(buffer);
            var scanInfo = new ScanInfo();
            using (var pinger = new Ping())
            {
                try
                {
                    for (int ttl = 1; ttl <= maxTTL; ttl++)
                    {

                        PingOptions options = new(ttl, true);
                        PingReply reply = pinger.Send(cn, timeout, buffer, options);
                        if (reply.Status == IPStatus.Success || reply.Status == IPStatus.TtlExpired)
                        {
                            scanInfo.IP = reply.Address.ToString();
                        }
                        if (reply.Status != IPStatus.TtlExpired && reply.Status != IPStatus.TimedOut)
                        {
                            scanInfo.IP = reply.Address.ToString();
                        }
                        else
                        {
                            scanInfo.IP = null;
                        }
                    }
                    return scanInfo.IP;
                }

                catch
                {
                    scanInfo.IP = null;
                    return scanInfo.IP;
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }

            }

        }

        public void Printers(string cn, RichTextBox rich)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                ManagementScope scope = new(@"\\" + cn + @"\root\cimv2");
                scope.Connect();
                rich.Text += "Принтеры " + cn + ":" + Environment.NewLine;
                if (scope.IsConnected)
                {
                    ManagementObjectSearcher searcher = new(@"\\" + cn + @"\root\cimv2", "SELECT * From Win32_Printer");
                    foreach (ManagementObject obj in searcher.Get().Cast<ManagementObject>())
                    {
                        rich.Text += obj["Name"].ToString() + Environment.NewLine;
                    }
                }
                else
                {
                    rich.Text += "Нет данных" + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Cursor.Current = Cursors.Default;
        }

        public void LocalAdmin(string cn, RichTextBox rich)
        {
            using (DirectoryEntry machine = new("WinNT://" + cn))
            {
                try
                {
                    using (DirectoryEntry group = machine.Children.Find("Администраторы", "Group"))
                    {
                        object? members = group.Invoke("Members", null);
                        rich.Text += $"Локальные администраторы {cn} " + Environment.NewLine;
                        foreach (object member in (IEnumerable)members)
                        {
                            string acc = new DirectoryEntry(member).Name;
                            var res = new string[2];
                            res[0] = cn;
                            res[1] = acc;
                            rich.Text += res[1] + Environment.NewLine;
                        }
                    }
                }
                catch
                {
                    using (DirectoryEntry group = machine.Children.Find("Administrators", "Group"))
                    {
                        object? members = group.Invoke("Members", null);
                        rich.Text += $"Локальные администраторы {cn} " + Environment.NewLine;
                        foreach (object member in (IEnumerable)members)
                        {
                            string acc = new DirectoryEntry(member).Name;
                            var res = new string[2];
                            res[0] = cn;
                            res[1] = acc;
                            rich.Text += res[1] + Environment.NewLine;
                        }
                    }
                }
            }
        }

        public void Send_msg(string address, string text)
        {
            string filepath = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\System32\";
            this.myprocess.SetAguments(filepath + @"\msg.exe", $"* /Server:{address} {text}");
            this.myprocess.SetStyle(true, ProcessWindowStyle.Hidden, true);
            this.myprocess.Start();
            this.myprocess.WaitForExit();
            this.myprocess.Close();
        }
    }
}
