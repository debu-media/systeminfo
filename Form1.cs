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
using System.Timers;

namespace WindowsFormsApp1
{

    
    public partial class head : Form
    {
        public head()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
        }
        public void dajadresip(object sender, EventArgs e)

        { adresip();
        }
         public void dajmacadres(object sender, EventArgs e)

        {
            macadres();
        }

        private void macadres()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {

                if (nic.OperationalStatus == OperationalStatus.Up && (!nic.Description.Contains("Virtual") && !nic.Description.Contains("Pseudo") && !nic.Description.Contains("Bluetooth") && !nic.Description.Contains("Device") && !nic.Description.Contains("Urządzenie") && !nic.Description.Contains("DW5811e")))
                {
                    if (nic.GetPhysicalAddress().ToString() != "")
                    {
                        string mac = Convert.ToString(nic.GetPhysicalAddress());
                        string splitmac = mac;
                        int insertCount = 0;
                        for (int i = 2; i < mac.Length; i = i + 2)
                        {
                            splitmac = splitmac.Insert(i + insertCount++, ":");
                        }
                        label10.Text = splitmac;

                    }
                }
            }
        }

        public void adresip() { 
            label4.Text = System.Net.Sockets.AddressFamily.InterNetwork.ToString();
            foreach (IPAddress currentIPAddress in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                Byte[] tablica = currentIPAddress.GetAddressBytes();
                if (tablica[0] == 192 && tablica[1] == 168) // Wyciągnij adres tylko z tej puli. 
                {
                    if (currentIPAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    { label4.Text = currentIPAddress.ToString(); }
    }
                else {
                    continue;
                
            }
 }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            adresip();
            macadres();
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Interval = 120000; // odświeżanie co 2 min
            t.Tick += new EventHandler(dajadresip);
            t.Start();
            System.Windows.Forms.Timer m = new System.Windows.Forms.Timer();
            m.Interval = 120000; // odświeżanie co 2 min
            m.Tick += new EventHandler(dajmacadres);
            m.Start();
            TransparencyKey = Color.Gray; // Wszytko co szare jest transparentne  
            Rectangle res = Screen.PrimaryScreen.Bounds;
            this.Location = new Point(res.Width-Size.Width,50);
            label2.Text = System.Environment.MachineName;
            label6.Text = Environment.UserDomainName + "\\" + Environment.UserName;
            label8.Text = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName", "").ToString();
            if  (label8.Text== "Windows 10 Enterprise") { label8.Text = "Windows 10 Pro"; }
            if (label8.Text == "Windows 10 Pro")
            {
                label8.Text =  label8.Text + " wersja: " + Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ReleaseId", "").ToString();
            }
            
               
         
          
            

        }

       

        private void label2_MouseHover(object sender, EventArgs e)
        {
             // Zamiana koloru napisów po najechaniu na czarne 
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label7.ForeColor = Color.Black;
            label8.ForeColor = Color.Black;
            label9.ForeColor = Color.Black;
            label10.ForeColor = Color.Black;
        }
        private void label4_MouseHover(object sender, EventArgs e)
        {
            // Zamiana koloru napisów po najechaniu na czerwone 
            label1.ForeColor = Color.Red;
            label2.ForeColor = Color.Red;
            label3.ForeColor = Color.Red;
            label4.ForeColor = Color.Red;
            label5.ForeColor = Color.Red;
            label6.ForeColor = Color.Red;
            label7.ForeColor = Color.Red;
            label8.ForeColor = Color.Red;
            label9.ForeColor = Color.Red;
            label10.ForeColor = Color.Red;
        }
    }




    }

