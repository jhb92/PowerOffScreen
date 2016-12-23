using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerOffScreen
{
    class Form1:Form
    {
        //关屏
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        //禁止鼠标键盘动作
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool BlockInput([In, MarshalAs(UnmanagedType.Bool)] bool fBlockIt);
        //锁屏
        [DllImport("user32.dll")]
        public static extern bool LockWorkStation();
        public Form1(bool aLock)
        {
            if (aLock)
            {
                //锁屏+关屏
                LockWorkStation();
                SendMessage(this.Handle, (uint)0x0112, (IntPtr)0xF170, (IntPtr)2);
            }
            else
            {
                //禁止鼠标键盘动作+关屏
                BlockInput(true);
                System.Threading.Thread.Sleep(10);
                SendMessage(this.Handle, (uint)0x0112, (IntPtr)0xF170, (IntPtr)2);
                BlockInput(false);
            }
            this.Close();
            //Application.Exit();
            Environment.Exit(0);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.ResumeLayout(false);

        }
    }
}
