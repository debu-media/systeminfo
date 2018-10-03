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
        {
            adresip();
        }
        public void dajuptime(object sender, EventArgs e)
        {
            UpTime();
        }
        public void dajmacadres(object sender, EventArgs e)

        {
            macadres();
        }

        private void macadres()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {

                if (nic.OperationalStatus == OperationalStatus.Up && (!nic.Description.Contains("Virtual") && !nic.Description.Contains("Pseudo") && !nic.Description.Contains("Bluetooth") && !nic.Description.Contains("Device") && !nic.Description.Contains("Urządzenie") && !nic.Description.Contains("DW5811e"))) // Nie chcemy MACÓW z Virtualnych kart,kart bluetooth etc.
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
        public void UpTime()
        {
  
                System.Diagnostics.PerformanceCounter upTime = new System.Diagnostics.PerformanceCounter("System", "System Up Time");
                upTime.NextValue();
                TimeSpan ts = TimeSpan.FromSeconds(upTime.NextValue());
                label12.Text = ts.Days +" d. " + ts.Hours + " g. " + ts.Minutes + " m. ".ToString(); ;
            
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
            UpTime();
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Interval = 120000; // odświeżanie co 2 min
            t.Tick += new EventHandler(dajadresip);
            t.Start();
            System.Windows.Forms.Timer m = new System.Windows.Forms.Timer();
            m.Interval = 120000; // odświeżanie co 2 min 
            m.Tick += new EventHandler(dajmacadres);
            m.Start();
            System.Windows.Forms.Timer u = new System.Windows.Forms.Timer();
            u.Interval = 60000; // odświeżanie co 1 min 
            u.Tick += new EventHandler(dajuptime);
            u.Start();
            TransparencyKey = Color.Gray; // Wszytko co szare jest transparentne  
            Rectangle res = Screen.PrimaryScreen.Bounds;
            this.Location = new Point(res.Width-Size.Width,50);
            label2.Text = System.Environment.MachineName; //Nazwa Komputera
            label6.Text = Environment.UserDomainName + "\\" + Environment.UserName; // Domenowa nazwa użytkownika 
            label8.Text = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName", "").ToString(); // Wersja systemu 
            if  (label8.Text== "Windows 10 Enterprise")
                { label8.Text = "Windows 10 Pro"; } // Naprawa błędu z wersją Enterprise (złe wersjonowanie po aktualziacji 1803 
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
            label11.ForeColor = Color.Black;
            label12.ForeColor = Color.Black;
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
            label11.ForeColor = Color.Red;
            label12.ForeColor = Color.Red;
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            // Zamiana koloru napisów po najechaniu na białe 
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label5.ForeColor = Color.White;
            label6.ForeColor = Color.White;
            label7.ForeColor = Color.White;
            label8.ForeColor = Color.White;
            label9.ForeColor = Color.White;
            label10.ForeColor = Color.White;
            label11.ForeColor = Color.White;
            label12.ForeColor = Color.White;
        }
    }

    }

