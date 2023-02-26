using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Management;

namespace laba_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Drives();
            timer1.Interval = 30000;
            timer1.Enabled = true;
        }
        private void Drives()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            DriveInfo[] driveInfos = DriveInfo.GetDrives();
            foreach(DriveInfo driveInfo in driveInfos)
            {
                listBox2.Items.Add("Название диска: "+driveInfo.Name);
                listBox2.Items.Add("Свободное место: "+driveInfo.TotalFreeSpace/1024/1024/1024+" Гб");
            }
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();

            foreach (ManagementObject result in results)
            {
                listBox1.Items.Add($"  Общая видимая оперативная память: {Convert.ToDouble(result["TotalVisibleMemorySize"]) / (1024 * 1024):f2} Гб");
                listBox1.Items.Add($"  Свободная физическая оперативная память: {Convert.ToDouble(result["FreePhysicalMemory"]) / (1024 * 1024):f2} Гб");
                listBox1.Items.Add($"  Общая виртуальная оперативная память: {Convert.ToDouble(result["TotalVirtualMemorySize"]) / (1024 * 1024):f2} Гб");
                listBox1.Items.Add($"  Свободная виртуальная оперативная память:  {Convert.ToDouble(result["FreeVirtualMemory"]) / (1024 * 1024):f2} Гб");
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Drives();

        }
    }
}
    

