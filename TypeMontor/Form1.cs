using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TypeMontor
{
    public partial class TypeMontor : Form
    {
        private int keystrokeCount = 0; // Keystroke counter
        private int backspaceCount = 0; // Backspace counter
        private int deleteCount = 0; // Delete counter
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer(); // Timer to update the WPM and accuracy
        private DateTime startTime; // Start time 
        private DateTime last_rec_keystr; // Last recorded keystroke time
        private bool isTyping = false; // Typing state
        private double wpm = 0;
        private double lastwpm = 0;
        private double avgWpm = 0;
        private Color softRed = Color.FromArgb(234, 108, 117);
        private Color softYellow = Color.FromArgb(224, 185, 67);
        private Color softGreen = Color.FromArgb(68, 137, 73);

        // Store WPM readings with timestamps
        private List<(DateTime Timestamp, double Wpm)> wpmReadings = new List<(DateTime, double)>();
        // Store backspace/Deletes with timestamps
        private List<(DateTime Timestamp, double removals)> removals = new List<(DateTime, double)>();

        // Global keyboard hook
        private static IntPtr hookId = IntPtr.Zero;
        private static LowLevelKeyboardProc proc = HookCallback;

        public TypeMontor()
        {
            InitializeComponent();
            // Set the start position of the form manually
            this.StartPosition = FormStartPosition.Manual;
            // Get the working area of the screen
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            // Set the position in the bottom right corner
            this.Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);
            // Ensure the application always stays on top of other applications
            this.TopMost = true;
            // Hide the form from the taskbar
            this.ShowInTaskbar = false;

            // Initialize the timer
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 3000; // 3 seconds -> change this if you want to update the WPM and accuracy more frequently
            timer.Tick += Timer_Tick;
            timer.Start();

            startTime = DateTime.Now;

            // Set the initial rounded corners
            SetRoundedCorners();

            // Set the global keyboard hook
            hookId = SetHook(proc);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Calculate the time elapsed
            TimeSpan timeElapsed = DateTime.Now - startTime;



            // Calculate the words per minute
            wpm = Math.Round(keystrokeCount / 5.0 / (timeElapsed.TotalSeconds / 60), 1);

            if (isTyping)
            {
                lastwpm = wpm;

                // Add the WPM reading with the current timestamp
                wpmReadings.Add((DateTime.Now, wpm));
                // Remove readings older than 5 minutes
                wpmReadings = wpmReadings.Where(reading => reading.Timestamp >= DateTime.Now.AddMinutes(-5)).ToList();

                // Keep only the last 20 readings
                if (wpmReadings.Count > 20)
                {
                    wpmReadings.RemoveAt(0);
                }

                // Calculate the average WPM over the last 20 readings
                avgWpm = Math.Round(wpmReadings.Average(reading => reading.Wpm), 1);

                isTyping = false;

            }

            // Calculate the accuracy
            double accuracy = Math.Round(((keystrokeCount - (double)removals.Count) / keystrokeCount) * 100, 1);

            // Update the labels
            label6.Text = $"{lastwpm:0.00}";
            label7.Text = $"{avgWpm}";

            //ifs in de update loop, Gerard, Lennart en Hieke schamen zich voor mij. 
            if (accuracy < 50)
            {
                label8.ForeColor = softRed;
            }
            if (accuracy >= 50 && accuracy < 85)
            {
                label8.ForeColor = softYellow;
            }
            else if (accuracy > 85)
            {
                label8.ForeColor = softGreen;
            }

            label8.Text = $"{accuracy:0.00}%";
        }

        private void SetRoundedCorners()
        {
            // Create a rounded corner
            GraphicsPath path = new GraphicsPath();
            int radius = 20; // Radius for the rounded corners
            path.AddArc(0, 0, radius, radius, 180, 90); // Top-left corner
            path.AddLine(radius, 0, this.Width, 0); // Top edge
            path.AddLine(this.Width, 0, this.Width, this.Height); // Right edge
            path.AddLine(this.Width, this.Height, 0, this.Height); // Bottom edge
            path.AddLine(0, this.Height, 0, radius); // Left edge
            path.CloseAllFigures();

            // Set the form's region to the rounded rectangle path
            this.Region = new Region(path);
        }


        //die hook dingentjes hier zijn allemaal enge hocus pocus. ngl 
        // Global keyboard hook setup
        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (var curProcess = System.Diagnostics.Process.GetCurrentProcess())
            using (var curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                Keys key = (Keys)vkCode; // Convert the virtual key code to a Keys enumeration zodat ik het wel snap lol
                // Increment the keystroke counter
                TypeMontor instance = Application.OpenForms.OfType<TypeMontor>().FirstOrDefault();
                if (instance != null)
                {
                    if (key == Keys.Back || key == Keys.Delete)
                    {
                        instance.backspaceCount++;
                        // Add the WPM reading with the current timestamp
                        instance.removals.Add((DateTime.Now, 1));
                        // Remove readings older than 5 minutes
                        instance.removals = instance.removals.Where(reading => reading.Timestamp >= DateTime.Now.AddMinutes(-5)).ToList();
                    }

                    instance.keystrokeCount++;
                    // Update the last recorded keystroke time
                    instance.last_rec_keystr = DateTime.Now;
                    // Update the keystroke counter label
                    instance.label5.Text = $"{instance.keystrokeCount}";

                    // Set the active typing flag to true
                    instance.isTyping = true;
                }
            }
            return CallNextHookEx(hookId, nCode, wParam, lParam);
        }

        // P/Invoke declarations
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            UnhookWindowsHookEx(hookId);
            base.OnFormClosing(e);
        }
    }
}
