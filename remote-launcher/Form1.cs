using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace remote_launcher
{
    public partial class Launcher : Form
    {
        private void act(string address)
        {
            int listenPort = 29090;
            bool done = false;
            try
            {
                IPHostEntry ihe = Dns.GetHostEntry(address);
                UdpClient listener = new UdpClient(listenPort);
                IPEndPoint groupEP = new IPEndPoint(ihe.AddressList[0], listenPort);
                while (!done)
                {
                    byte[] receive_byte_array = listener.Receive(ref groupEP);
                    string raw = Encoding.UTF8.GetString(receive_byte_array, 0, receive_byte_array.Length);
                    string[] pair = raw.Split(new string[] { ":::!:::" }, StringSplitOptions.None);

                    if (pair[1] == "kill") done = true;


                    var processed = pair.Select(x => x.Replace("/home/sayon", "z:")).ToArray();

                    try
                    {
                        var proc1 = new ProcessStartInfo();

                        proc1.UseShellExecute = true;

                        proc1.WorkingDirectory = processed[0];
                        proc1.FileName = @"explorer.exe";
                        //proc1.Verb = "runas";
                        proc1.Arguments = processed[1];
                        proc1.WindowStyle = ProcessWindowStyle.Hidden;
                        notify(processed[1], "Launching...");
                        Process.Start(proc1);

                    }
                    catch
                    {
                        error("Failed to run");
                    }

                }
            }
            catch (Exception exception)
            {
                error(exception.Message);
            }
        }

        public Launcher()
        {
            InitializeComponent();
        }

        private void button_listen_Click(object sender, EventArgs e)
        {
            act(input_ip.Text); 
            WindowState = FormWindowState.Minimized;
            Hide();
        }
        private void notify(string msg, string header = "")
        {
            var item = new NotifyIcon();
            item.Visible = true;
            item.Icon = System.Drawing.SystemIcons.Information;
            item.ShowBalloonTip(100, header, msg, ToolTipIcon.Info);
        }
        private void error(string msg, string header = "Error")
        {
            var item = new NotifyIcon();
            item.Visible = true;
            item.Icon = System.Drawing.SystemIcons.Error;
            item.ShowBalloonTip(3000, header, msg, ToolTipIcon.Error);
        }

        private void input_ip_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { act(input_ip.Text); WindowState = FormWindowState.Minimized; Hide(); }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var Params = base.CreateParams;
                Params.ExStyle |= 0x80;
                return Params;
            }
        }

    }
}
