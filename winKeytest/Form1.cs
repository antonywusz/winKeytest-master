using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using WindowsInput;

namespace winKeytest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        [DllImport("user32.dll", EntryPoint = "keybd_event")]

        public static extern void keybd_event(

            byte bVk,    //虚拟键值

            byte bScan,// 一般为0

            int dwFlags,  //这里是整数类型  0 为按下，2为释放

            int dwExtraInfo  //这里是整数类型 一般情况下设成为 0

        );

        private void button1_Click(object sender, EventArgs e)
        {
            keybd_event((byte)Keys.LWin, 0, 0, 0);
            Thread.Sleep(10);
            keybd_event((byte)Keys.LWin, 0, 2, 0);   //释放LWIN
            Thread.Sleep(50);
            InputSimulator input = new InputSimulator();
            this.Focus();
            //SendKeys.SendWait("CAMERA");

            //Thread.Sleep(1000);            
            //input.Keyboard.TextEntry("CAMERA");
            input.Keyboard.TextEntry("camera");

            Thread.Sleep(100);
            keybd_event((byte)Keys.Enter, 0, 0, 0);
            Thread.Sleep(200);
            keybd_event((byte)Keys.Enter, 0, 2, 0);   //释放LWIN
        }
    }
}
