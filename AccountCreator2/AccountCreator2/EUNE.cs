using System;
using System.Windows; // WPF
using System.Drawing;
using System.Runtime.InteropServices;

using WindowsInput;
using WindowsInput.Native;
using System.IO;
using System.Linq;


namespace AccountCreator
{

     public class EUNEAccountCreatorLogic : IServer
    {
        public string Serwer => "EUNE";

        private const UInt32 MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const UInt32 MOUSEEVENTF_LEFTUP = 0x0004;
        private const UInt32 Rkey = 0x52;

        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, uint dwExtraInf);
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int x, int y);


        private void Click()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
        private void DoubleClickAtPosition(int posX, int posY)
        {
            SetCursorPos(posX, posY);

            Click();
            System.Threading.Thread.Sleep(250);
            Click();
        }
        private void Action(int delay, int posX, int posY)
        {
            System.Threading.Thread.Sleep(delay);
            SetCursorPos(posX, posY);
            Click();
        }
        public void Account_creator(string serwer, string email, string username, string password)
        {
            InputSimulator s = new InputSimulator();
            if (serwer == "EUNE")
            {
                //run, click, open chrome, lol site
                s.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LWIN, VirtualKeyCode.VK_R);
                System.Threading.Thread.Sleep(2000);
                s.Keyboard.KeyPress(VirtualKeyCode.DELETE);
                Action(0, 105, 936);
                System.Threading.Thread.Sleep(500);
                s.Keyboard.TextEntry(@"chrome signup.eune.leagueoflegends.com/pl/signup/index");
                s.Keyboard.KeyPress(VirtualKeyCode.RETURN);
                System.Threading.Thread.Sleep(2000);
                s.Keyboard.KeyPress(VirtualKeyCode.F11);
                DoubleClickAtPosition(1325, 189);

                //email                  
                Action(2000, 741, 642);
                s.Keyboard.TextEntry(email);

                //start                   
                Action(1000, 957, 750);

                //day
                Action(1000, 823, 505);

                //choose day
                Action(1000, 823, 775);

                //month
                Action(1000, 956, 510);

                //choose month
                Action(1000, 956, 650);

                //year
                Action(1000, 1070, 507);

                //choose year
                System.Threading.Thread.Sleep(1000);
                SetCursorPos(1070, 810);
                System.Threading.Thread.Sleep(500);
                s.Keyboard.KeyPress(VirtualKeyCode.DOWN);
                System.Threading.Thread.Sleep(500);
                s.Keyboard.KeyPress(VirtualKeyCode.DOWN);
                System.Threading.Thread.Sleep(500);
                s.Keyboard.KeyPress(VirtualKeyCode.RETURN);
                //next
                Action(1000, 933, 662);

                //username
                Action(1000, 933, 405);
                System.Threading.Thread.Sleep(200);
                s.Keyboard.TextEntry(username);

                //password
                Action(700, 933, 500);
                s.Keyboard.TextEntry(password);
                Action(1000, 933, 600);
                s.Keyboard.TextEntry(password);

                //i agree
                Action(1000, 700, 660);

                //next
                Action(200, 960, 780);
                s.Keyboard.KeyPress(VirtualKeyCode.F11);


            }
        }
    }
}




























