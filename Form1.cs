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
                Byte[] tablica = currentIPAddress.GetAddressBytes();
                if (tablica[0] == 192 && tablica[1] == 168)
                {
                    if (currentIPAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    { label4.Text = currentIPAddress.ToString(); }
                }
                else {
                    continue;
                }
            }

            label6.Text = Environment.UserDomainName + "\\" + Environment.UserName;
            label8.Text = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName", "").ToString();
            if (label8.Text == "Windows 10 Pro")
            {
                label8.Text =  label8.Text + " wersja: " + Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ReleaseId", "").ToString();
            }
            
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {

                if (nic.OperationalStatus == OperationalStatus.Up && (!nic.Description.Contains("Virtual") && !nic.Description.Contains("Pseudo") && !nic.Description.Contains("Bluetooth") && !nic.Description.Contains("Device") && !nic.Description.Contains("Urządzenie") &&  !nic.Description.Contains("DW5811e")))
                {
                    if (nic.GetPhysicalAddress().ToString() != "")
                    {
                       string mac = Convert.ToString(nic.GetPhysicalAddress());
                        string splitmac = mac;
                        int insertCount = 0;
                        for (int i = 2; i < mac.Length; i=i+2)
                        {
                            splitmac = splitmac.Insert(i + insertCount++, ":");
                        }
                        label10.Text = splitmac;
                       
                    }
                }
            }
            

        }

       
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
