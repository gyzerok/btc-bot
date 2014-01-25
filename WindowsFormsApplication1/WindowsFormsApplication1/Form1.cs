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
            System.IO.StreamReader UsedAdr = new System.IO.StreamReader("D:\\used_adr.txt");
            System.IO.StreamReader OldJson = new System.IO.StreamReader("D:\\fbBot\\server\\credentials.old");
            System.IO.StreamWriter NewJson = new System.IO.StreamWriter("D:\\fbBot\\server\\credentials.json");
            String[] UsedArr=new String[76];
            String line;
            Boolean f;
            for (int i = 0; i < 76;i++ )
            {
                UsedArr[i] = UsedAdr.ReadLine();
            }
            for(int i =0;i<169;i++)
            {
                line = OldJson.ReadLine();
                f=false;
                foreach(String s in UsedArr)
                {
                    if(s==line)
                    {
                        break;
                        f=true;
                    }
                }
                if(!f)
                {
                    NewJson.WriteLine("\"" + line + "\",");
                }
            }
            NewJson.Close();
            OldJson.Close();
            UsedAdr.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
			int start=7, stop=101;
            System.IO.StreamReader UAfile = new System.IO.StreamReader("D:\\useragents.txt");
            System.IO.StreamReader Pfile = new System.IO.StreamReader("D:\\proxylist.txt");
            System.IO.StreamWriter ListFile = new System.IO.StreamWriter("list_geneated.txt");
            String ua, proxy;
            int i = 0;
            for(i=start;i<=stop;i++)
            {
                if(i==80)
                {
                    i = i;
                }
                ua=UAfile.ReadLine().Trim();
				
                proxy=Pfile.ReadLine().Trim();
                while(proxy.Substring(0,3).Equals("195"))
                    proxy = Pfile.ReadLine().Trim();
                
                ListFile.WriteLine(i.ToString() + "|" + ua + "|" + proxy + "|" + DateTime.Now.ToString());
            }
            UAfile.Close();
            ListFile.Close();
            Pfile.Close();

            MessageBox.Show(i.ToString());
        }
        private void bwWorkLoop_DoWork(object sender, DoWorkEventArgs e)
        {
            var rnd = new Random();
            System.Diagnostics.Process[] plist;
            int RunningCount;
            //int maxcount = Convert.ToInt32(tbMaxCount.Text); //На деле будет на 1 процесс меньше, т.к. у хрома после закрытия всегда висит минимум 1 процесс
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
                        
                        System.Threading.Thread.Sleep(10000);
                        
                    }
                }
                
                System.Threading.Thread.Sleep(10000);
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
