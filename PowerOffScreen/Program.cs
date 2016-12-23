using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerOffScreen
{
    class Program
    {      
        static void Main(string[] args)
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault( false );
            if (args != null && args.Length != 0)
            {
                //锁屏+关屏
                Application.Run(new Form1(false));
            }
            else
            {
                //禁止鼠标键盘动作+关屏
                Application.Run(new Form1(true));                
            }
        }
    }
}
