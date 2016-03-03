
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace remote_launcher
{
    static class Program
    {
        private static void act(string address)
        {
            int listenPort = 29090;
            bool done = false;
            try
            {
                IPHostEntry ihe = Dns.Resolve(address);
                UdpClient listener = new UdpClient(listenPort);
                IPEndPoint groupEP = new IPEndPoint(ihe.AddressList[0], listenPort);
                while (!done)
                {
                    byte[] receive_byte_array = listener.Receive(ref groupEP);
                    string raw = Encoding.UTF8.GetString(receive_byte_array, 0, receive_byte_array.Length);
                    string[] pair = raw.Split(new string[] { ":::!:::" }, StringSplitOptions.None);

                    if (pair[1] == "kill") done = true;


                    var processed = pair.Select(x => x.Replace("/home/sayon", "z:").Replace('/', '\\')).ToArray();

                    try
                    {
                        var proc1 = new ProcessStartInfo();

                        proc1.UseShellExecute = false;
                        proc1.CreateNoWindow = false; 
                        proc1.FileName = "explorer.exe";
                        proc1.Verb = "runas";
                        proc1.WorkingDirectory = processed[0];
                        proc1.Arguments = processed[1];
                        proc1.WindowStyle = ProcessWindowStyle.Maximized;
                        ////notify( proc1.Arguments,  "Launching...");
                        var pc = Process.Start(proc1); 

                    }
                    catch (Exception ex)
                    {
                        error("Failed to run: " + ex.Message);
                    }

                }
            }
            catch (Exception exception)
            {
                error(exception.Message);
            }
        }

        private static void notify(string msg, string header = "")
        {
            var item = new NotifyIcon();
            item.Visible = true;
            item.Icon = System.Drawing.SystemIcons.Information;
            item.ShowBalloonTip(100, header, msg, ToolTipIcon.Info);
        }
        private static void error(string msg, string header = "Error")
        {
            var item = new NotifyIcon();
            item.Visible = true;
            item.Icon = System.Drawing.SystemIcons.Error;
            item.ShowBalloonTip(3000, header, msg, ToolTipIcon.Error);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            var args = Environment.GetCommandLineArgs();
            if (args.Length != 2)
            {
                notify("Defaulting to \"deb\"");
                act("deb");
            }
            else act(args[1]);
        }
    }
}
