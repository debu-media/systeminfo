using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class head : Form
    {
        public head()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TransparencyKey = Color.Fuchsia;
            Rectangle res = Screen.PrimaryScreen.Bounds;
            this.Location = new Point(res.Width-Size.Width,50);
            label2.Text = System.Environment.MachineName;
            label4.Text = System.Net.Sockets.AddressFamily.InterNetwork.ToString();
            foreach (IPAddress currentIPAddress in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (currentIPAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                { label4.Text = currentIPAddress.ToString(); }
            }

            label6.Text = Environment.UserDomainName + "\\" + Environment.UserName;
            label8.Text = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName", "").ToString();
            if (label8.Text == "Windows 10 Pro") {label8.Text =  label8.Text + Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "RelaseId", "").ToString(); }
            
            string mac = "";
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {

                if (nic.OperationalStatus == OperationalStatus.Up && (!nic.Description.Contains("Virtual") && !nic.Description.Contains("Pseudo") && !nic.Description.Contains("Bluetooth") && !nic.Description.Contains("Device") && !nic.Description.Contains("Urządzenie")))
                {
                    if (nic.GetPhysicalAddress().ToString() != "")
                    {
                        label10.Text = nic.GetPhysicalAddress().ToString();
                    }
                }
            }
            

        }

       
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
