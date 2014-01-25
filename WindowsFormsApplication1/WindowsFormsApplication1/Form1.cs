using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace fbLauncher
{
    public partial class Form1 : Form
    {
        System.Collections.Generic.List<BotInstance> list;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Process.GetProcessesByName("GoogleChromePortable").Length.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.StreamReader UAfile = new System.IO.StreamReader("D:\\useragents.txt");
            System.IO.StreamReader Pfile = new System.IO.StreamReader("D:\\proxylist.txt");
            System.IO.StreamWriter list = new System.IO.StreamWriter("list_geneated.txt");
            String ua, proxy;
            for(int i=7;i<=250;i++)
            {
                if(i==217)
                {
                    i = i;
                }
                ua=UAfile.ReadLine().Trim();
                proxy=Pfile.ReadLine().Trim();
                list.WriteLine(i.ToString() + "|" + ua + "|" + proxy + "|" + DateTime.Now.ToString());
            }
            MessageBox.Show("!");
        }
        private void bwWorkLoop_DoWork(object sender, DoWorkEventArgs e)
        {
            var rnd = new Random();
            System.Diagnostics.Process[] plist;
            int RunningCount;
            int maxcount = Convert.ToInt32(tbMaxCount.Text); //На деле будет на 1 процесс меньше, т.к. у хрома после закрытия всегда висит минимум 1 процесс
            lbStartedSummary.Invoke(new MethodInvoker(() => lbStartedSummary.Text = "0"));
            lbRunningCount.Invoke(new MethodInvoker(() => lbRunningCount.Text = "0"));
            lbKills.Invoke(new MethodInvoker(() => lbKills.Text = "0"));
            
            while (cbDoWork.Checked)
            {
                //убивание процессов по таймауту
                /*plist=Process.GetProcessesByName("GoogleChromePortable.exe");
                foreach(Process p in plist)
                {
                    if (DateTime.Now - p.StartTime > new TimeSpan(0, 10, 0))
                    {
                        p.Kill();
                        lbKills.Invoke(new MethodInvoker(() => lbKills.Text = (Convert.ToInt32(lbKills.Text) + 1).ToString()));
                    }
                }
                //RunningCount = plist.Length;
                lbRunningCount.Invoke(new MethodInvoker(() => lbRunningCount.Text = plist.Length.ToString()));*/

                //Запуск окон
                foreach (BotInstance b in list)
                {
                    //plist = Process.GetProcessesByName("GoogleChromePortable");
                    if (b.NextClick <= DateTime.Now)// && plist.Length < maxcount)
                    {
                        b.Run();
                        b.NextClick = DateTime.Now + new TimeSpan(1, 5, 0);

                        //RunningCount++;
                        //lbRunningCount.Invoke(new MethodInvoker(() => lbRunningCount.Text = plist.Length.ToString()));
                        lbStartedSummary.Invoke(new MethodInvoker(() => lbStartedSummary.Text = (Convert.ToInt32(lbStartedSummary.Text) + 1).ToString()));
                        
                        System.Threading.Thread.Sleep(20000);
                        
                    }
                }
                
                System.Threading.Thread.Sleep(20000);
            }
        }

        private void cbDoWork_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDoWork.Checked && !bwWorkLoop.IsBusy)
                bwWorkLoop.RunWorkerAsync();
            else
            {
                cbDoWork.Checked = false;
            }
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("list.txt"))
            {
                foreach (BotInstance el in list)
                {
                    file.WriteLine(el.ToString());
                }
                file.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            list = new List<BotInstance>();
            using (System.IO.StreamReader file = new System.IO.StreamReader("list.txt"))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    if (line.Length > 5)
                    {
                        list.Add(new BotInstance(line));
                    }
                }
                file.Close();
            }
            bwKoriaviyKostil.RunWorkerAsync();
        }

        private void bwKoriaviyKostil_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                dataGridView.Invoke(new MethodInvoker(() => dataGridView.DataSource = list));
                System.Threading.Thread.Sleep(10000);
            }

        }
    }
}
