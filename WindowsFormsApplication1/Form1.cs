using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 设置某一位的值
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index">要设置的位， 值从低到高为 1-8</param>
        /// <param name="flag">要设置的值 true / false</param>
        /// <returns></returns>
        private byte set_bit(byte data, int index, bool flag)
        {
            if (index > 8 || index < 1)
                throw new ArgumentOutOfRangeException();
            int v = index < 2 ? index : (2 << (index - 2));
            return flag ? (byte)(data | v) : (byte)(data & ~v);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] byteaddr = new byte[30];
            byte[] bytevalue = new byte[30];
            byte tmp_addr = 0x00;


            for (int i = 1; i <= 196; i++)
            {
                int tmp_i;
                int tmp = i / 28;
                if (i % 28 == 0)
                    tmp = tmp - 1;

                if (tmp != 0)
                {
                    tmp_i = i - tmp * 28;

                }
                else
                {

                    tmp_i = i;
                }
                if (tmp_i <= 8)
                {
                    switch (tmp)
                    {
                        case 0:
                            tmp_addr = 0x00;
                            break;
                        case 1:
                            tmp_addr = 0x04;
                            break;
                        case 2:
                            tmp_addr = 0x08;
                            break;
                        case 3:
                            tmp_addr = 0x0c;
                            break;
                        case 4:
                            tmp_addr = 0x10;
                            break;
                        case 5:
                            tmp_addr = 0x14;
                            break;
                        case 6:
                            tmp_addr = 0x18;
                            break;

                    }
                    byteaddr[tmp * 4 + 0] = tmp_addr;

                    if (((CheckBox)this.Controls.Find("checkBox" + i, true)[0]).Checked)
                    {

                        byte bit = 0;
                        if (tmp_i > 4)
                        {
                            bit = (byte)(tmp_i - 4);

                        }
                        else
                        {
                            bit = (byte)(tmp_i + 4);
                        }

                        bytevalue[tmp * 4 + 0] = set_bit(bytevalue[tmp * 4 + 0], bit, true);
                        //     Console.WriteLine("第" + tmp + "行" + " ADDR : " + byteaddr[tmp * 4 + 0].ToString("x2") + " VALUE: " + bytevalue[tmp * 4 + 0].ToString("x2"));
                    }
                }
                else if (tmp_i <= 16)
                {
                    switch (tmp)
                    {
                        case 0:
                            tmp_addr = 0x20;
                            break;
                        case 1:
                            tmp_addr = 0x24;
                            break;
                        case 2:
                            tmp_addr = 0x28;
                            break;
                        case 3:
                            tmp_addr = 0x2c;
                            break;
                        case 4:
                            tmp_addr = 0x30;
                            break;
                        case 5:
                            tmp_addr = 0x34;
                            break;
                        case 6:
                            tmp_addr = 0x38;
                            break;

                    }
                    byteaddr[tmp * 4 + 1] = tmp_addr;
                    if (((CheckBox)this.Controls.Find("checkBox" + i, true)[0]).Checked)
                    {

                        byte bit = 0;
                        tmp_i = tmp_i - 8;
                        if (tmp_i > 4)
                        {
                            bit = (byte)(tmp_i - 4);

                        }
                        else
                        {
                            bit = (byte)(tmp_i + 4);
                        }
                        bytevalue[tmp * 4 + 1] = set_bit(bytevalue[tmp * 4 + 1], bit, true);
                        //    Console.WriteLine("第" + tmp + "行" + " ADDR : " + byteaddr[tmp * 4 + 1].ToString("x2") + " VALUE: " + bytevalue[tmp * 4 + 1].ToString("x2"));

                    }

                }
                else if (tmp_i <= 24)
                {
                    switch (tmp)
                    {
                        case 0:
                            tmp_addr = 0x02;
                            break;
                        case 1:
                            tmp_addr = 0x06;
                            break;
                        case 2:
                            tmp_addr = 0x0a;
                            break;
                        case 3:
                            tmp_addr = 0x0e;
                            break;
                        case 4:
                            tmp_addr = 0x12;
                            break;
                        case 5:
                            tmp_addr = 0x16;
                            break;
                        case 6:
                            tmp_addr = 0x1a;
                            break;

                    }
                    byteaddr[tmp * 4 + 2] = tmp_addr;
                    if (((CheckBox)this.Controls.Find("checkBox" + i, true)[0]).Checked)
                    {
                        byte bit = 0;
                        tmp_i = tmp_i - 16;
                        if (tmp_i > 4)
                        {
                            bit = (byte)(tmp_i - 4);

                        }
                        else
                        {
                            bit = (byte)(tmp_i + 4);
                        }
                        bytevalue[tmp * 4 + 2] = set_bit(bytevalue[tmp * 4 + 2], bit, true);
                        //    Console.WriteLine("第" + tmp + "行" + " ADDR : " + byteaddr[tmp * 4 + 1].ToString("x2") + " VALUE: " + bytevalue[tmp * 4 + 1].ToString("x2"));

                        //Console.WriteLine("checkBox" + i);
                    }
                }
                else if (tmp_i <= 32)
                {
                    switch (tmp)
                    {
                        case 0:
                            tmp_addr = 0x22;
                            break;
                        case 1:
                            tmp_addr = 0x26;
                            break;
                        case 2:
                            tmp_addr = 0x2a;
                            break;
                        case 3:
                            tmp_addr = 0x2e;
                            break;
                        case 4:
                            tmp_addr = 0x32;
                            break;
                        case 5:
                            tmp_addr = 0x36;
                            break;
                        case 6:
                            tmp_addr = 0x3a;
                            break;

                    }
                    byteaddr[tmp * 4 + 3] = tmp_addr;
                    if (((CheckBox)this.Controls.Find("checkBox" + i, true)[0]).Checked)
                    {
                        byte bit = 0;
                        tmp_i = tmp_i - 24;
                        if (tmp_i > 4)
                        {
                            bit = (byte)(tmp_i - 4);

                        }
                        else
                        {
                            bit = (byte)(tmp_i + 4);
                        }
                        bytevalue[tmp * 4 + 3] = set_bit(bytevalue[tmp * 4 + 3], bit, true);
                        //  Console.WriteLine("第" + tmp + "行" + " ADDR : " + byteaddr[tmp * 4 + 3].ToString("x2") + " VALUE: " + bytevalue[tmp * 4 + 3].ToString("x2"));

                        // Console.WriteLine("checkBox" + i);
                    }


                }
            }
            //print
            string addrhexString = "ADDR : ";
            string valuehexString = "VALUE : ";
            for (int i = 0; i < byteaddr.Length; i++)
            {
                if (bytevalue[i] != 0)
                {
                    Console.WriteLine("ADDR:" + byteaddr[i].ToString("x2"));
                    Console.WriteLine("VALUE:" + bytevalue[i].ToString("x2"));
                    addrhexString += byteaddr[i].ToString("X2") + " ";
                    valuehexString += bytevalue[i].ToString("x2") + " ";

                }
            }
            addrhexString += "\n";
            valuehexString += "\n";
            File.WriteAllText(@"d:\ledtest.txt", addrhexString);
            File.AppendAllText(@"d:\ledtest.txt", valuehexString);

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox30_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox64_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox102_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox116_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox146_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox181_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] byteaddr = new byte[30];
            byte[] bytevalue = new byte[30];
            byte tmp_addr = 0x00;
            int i = 0;

            for (i = 1; i <= 196; i++)
            {
                int tmp_i;
                int tmp = i / 28;
                if (i % 28 == 0)
                    tmp = tmp - 1;

                if (tmp != 0)
                {
                    tmp_i = i - tmp * 28;
                }
                else
                {

                    tmp_i = i;

                }
                if (tmp_i <= 8)
                {
                    switch (tmp)
                    {
                        case 0:
                            tmp_addr = 0x00;
                            break;
                        case 1:
                            tmp_addr = 0x04;
                            break;
                        case 2:
                            tmp_addr = 0x08;
                            break;
                        case 3:
                            tmp_addr = 0x0c;
                            break;
                        case 4:
                            tmp_addr = 0x10;
                            break;
                        case 5:
                            tmp_addr = 0x14;
                            break;
                        case 6:
                            tmp_addr = 0x18;
                            break;

                    }
                    byteaddr[tmp * 4 + 0] = tmp_addr;

                    if (((CheckBox)this.Controls.Find("checkBox" + i, true)[0]).Checked)
                    {

                        byte bit = 0;
                        if (tmp_i > 4)
                        {
                            bit = (byte)(tmp_i - 4);

                        }
                        else
                        {
                            bit = (byte)(tmp_i + 4);
                        }

                        bytevalue[tmp * 4 + 0] = set_bit(bytevalue[tmp * 4 + 0], bit, true);
                        //     Console.WriteLine("第" + tmp + "行" + " ADDR : " + byteaddr[tmp * 4 + 0].ToString("x2") + " VALUE: " + bytevalue[tmp * 4 + 0].ToString("x2"));
                    }
                }
                else if (tmp_i <= 16)
                {
                    switch (tmp)
                    {
                        case 0:
                            tmp_addr = 0x20;
                            break;
                        case 1:
                            tmp_addr = 0x24;
                            break;
                        case 2:
                            tmp_addr = 0x28;
                            break;
                        case 3:
                            tmp_addr = 0x2c;
                            break;
                        case 4:
                            tmp_addr = 0x30;
                            break;
                        case 5:
                            tmp_addr = 0x34;
                            break;
                        case 6:
                            tmp_addr = 0x38;
                            break;

                    }
                    byteaddr[tmp * 4 + 1] = tmp_addr;
                    if (((CheckBox)this.Controls.Find("checkBox" + i, true)[0]).Checked)
                    {

                        byte bit = 0;
                        tmp_i = tmp_i - 8;
                        if (tmp_i > 4)
                        {
                            bit = (byte)(tmp_i - 4);

                        }
                        else
                        {
                            bit = (byte)(tmp_i + 4);
                        }
                        bytevalue[tmp * 4 + 1] = set_bit(bytevalue[tmp * 4 + 1], bit, true);
                        //    Console.WriteLine("第" + tmp + "行" + " ADDR : " + byteaddr[tmp * 4 + 1].ToString("x2") + " VALUE: " + bytevalue[tmp * 4 + 1].ToString("x2"));

                    }

                }
                else if (tmp_i <= 24)
                {
                    switch (tmp)
                    {
                        case 0:
                            tmp_addr = 0x02;
                            break;
                        case 1:
                            tmp_addr = 0x06;
                            break;
                        case 2:
                            tmp_addr = 0x0a;
                            break;
                        case 3:
                            tmp_addr = 0x0e;
                            break;
                        case 4:
                            tmp_addr = 0x12;
                            break;
                        case 5:
                            tmp_addr = 0x16;
                            break;
                        case 6:
                            tmp_addr = 0x1a;
                            break;

                    }
                    byteaddr[tmp * 4 + 2] = tmp_addr;
                    if (((CheckBox)this.Controls.Find("checkBox" + i, true)[0]).Checked)
                    {
                        byte bit = 0;
                        tmp_i = tmp_i - 16;
                        if (tmp_i > 4)
                        {
                            bit = (byte)(tmp_i - 4);

                        }
                        else
                        {
                            bit = (byte)(tmp_i + 4);
                        }
                        bytevalue[tmp * 4 + 2] = set_bit(bytevalue[tmp * 4 + 2], bit, true);
                        //    Console.WriteLine("第" + tmp + "行" + " ADDR : " + byteaddr[tmp * 4 + 1].ToString("x2") + " VALUE: " + bytevalue[tmp * 4 + 1].ToString("x2"));

                        //Console.WriteLine("checkBox" + i);
                    }
                }
                else if (tmp_i <= 32)
                {
                    switch (tmp)
                    {
                        case 0:
                            tmp_addr = 0x22;
                            break;
                        case 1:
                            tmp_addr = 0x26;
                            break;
                        case 2:
                            tmp_addr = 0x2a;
                            break;
                        case 3:
                            tmp_addr = 0x2e;
                            break;
                        case 4:
                            tmp_addr = 0x32;
                            break;
                        case 5:
                            tmp_addr = 0x36;
                            break;
                        case 6:
                            tmp_addr = 0x3a;
                            break;

                    }
                    byteaddr[tmp * 4 + 3] = tmp_addr;
                    if (((CheckBox)this.Controls.Find("checkBox" + i, true)[0]).Checked)
                    {
                        byte bit = 0;
                        tmp_i = tmp_i - 24;
                        if (tmp_i > 4)
                        {
                            bit = (byte)(tmp_i - 4);

                        }
                        else
                        {
                            bit = (byte)(tmp_i + 4);
                        }
                        bytevalue[tmp * 4 + 3] = set_bit(bytevalue[tmp * 4 + 3], bit, true);
                        //  Console.WriteLine("第" + tmp + "行" + " ADDR : " + byteaddr[tmp * 4 + 3].ToString("x2") + " VALUE: " + bytevalue[tmp * 4 + 3].ToString("x2"));

                        // Console.WriteLine("checkBox" + i);
                    }


                }
            }



            string cmdline;

            for (i = 0; i < byteaddr.Length; i++)
            {
                if (bytevalue[i] != 0)
                {
                    // Console.WriteLine("ADDR:" + byteaddr[i].ToString("x2"));
                    // Console.WriteLine("VALUE:" + bytevalue[i].ToString("x2"));
                    // cmdline = "adb shell echo  " + byteaddr[i] + " " + bytevalue[i] + " > /sys/class/i2c-adapter/i2c-2/2-0072/register";
                    cmdline = "adb shell \"echo  " + "0x" + byteaddr[i].ToString("x2") + " " + "0x" + bytevalue[i].ToString("x2") + " > /sys/class/i2c-adapter/i2c-2/2-0072/register\" ";
                    // mp.StandardInput.WriteLine(cmdline);
                    System.Diagnostics.Process p = new System.Diagnostics.Process();
                    p.StartInfo.FileName = "cmd.exe";
                    p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
                    p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
                    p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
                    p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
                    p.StartInfo.CreateNoWindow = true;//不显示程序窗口
                    p.Start();//启动程序
                    p.StandardInput.WriteLine(cmdline+"&exit");
                    p.Close();
                    //Thread.Sleep(200);
                    Console.WriteLine(cmdline);

                }
            }
       

        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process mp = new System.Diagnostics.Process();
            mp.StartInfo.FileName = "cmd.exe";
            mp.StartInfo.RedirectStandardInput = true;
            mp.StartInfo.RedirectStandardOutput = true;
            mp.StartInfo.RedirectStandardError = true;
            mp.StartInfo.UseShellExecute = false;
            mp.StartInfo.CreateNoWindow = true;
            mp.Start();
            mp.StandardInput.WriteLine("adb shell \" echo 3 > /sys/class/i2c-adapter/i2c-2/2-0072/led_blink\" ");
            for (int i = 1; i <= 196; i++)
            {
                if (((CheckBox)this.Controls.Find("checkBox" + i, true)[0]).Checked)
                {
                    ((CheckBox)this.Controls.Find("checkBox" + i, true)[0]).Checked = false;
                }

            }

            mp.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.machine-kernel.cn/");
        }

        private void checkBox104_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void checkBox196_MouseMove(object sender, MouseEventArgs e)
        {
           
        }
    }
}
