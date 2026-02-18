using Accessibility;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace CheeseGuider
{
    public partial class Form1 : Form
    {
        IntPtr moduleBase;

        [DllImport("Kernel32.dll")]
        static extern bool ReadProcessMemory(
           IntPtr hProcess,
           IntPtr lpBaseAddress,
           [Out] byte[] lpBuffer,
           int nSize,
           IntPtr lpNumberOfBytesRead
           );

        public static Process proc;
        public Process GetProcess(string procname)
        {
            proc = Process.GetProcessesByName(procname)[0];
            return proc;
        }
        public IntPtr GetModuleBase(string modulename)
        {
            if (modulename.Contains(".exe"))
                return proc.MainModule.BaseAddress;

            foreach (ProcessModule module in proc.Modules)
            {
                if (module.ModuleName == modulename)
                    return module.BaseAddress;
            }
            return IntPtr.Zero;
        }

        public IntPtr ReadPointer(IntPtr addy)
        {
            byte[] buffer = new byte[4];
            ReadProcessMemory(proc.Handle, addy, buffer, buffer.Length, IntPtr.Zero);
            return new IntPtr(BitConverter.ToInt32(buffer, 0));
        }

        public IntPtr ReadPointer(IntPtr addy, int offset)
        {
            byte[] buffer = new byte[4];
            ReadProcessMemory(proc.Handle, IntPtr.Add(addy, offset), buffer, buffer.Length, IntPtr.Zero);

            return new IntPtr(BitConverter.ToInt32(buffer, 0));
        }

        public static byte[] ReadBytes(IntPtr addy, int bytes)
        {
            byte[] buffer = new byte[bytes];
            ReadProcessMemory(proc.Handle, addy, buffer, buffer.Length, IntPtr.Zero);
            return buffer;
        }
        public int ReadInt(IntPtr address)
        {
            return BitConverter.ToInt32(ReadBytes(address, 4));
        }


        Random random = new Random();
        int LevelId = 999;
        string[] lines;
        string[] exits;
        string[] thereIsNoGame = {
            "GAME CLOSED CODE RED CODE RED",
            "THERE IS NO GAME!!!",
            "No game - no info",
            "Launch the game plz",
            "i see nothing y'know, launch the game",
            "Hey, you. You're finally awake",
            "cheese is eaten, but i need more",
            "WHERE'S THE GAME WHERE'S THE GAME AAAAAAAAAAAAAAHHHHH"
        };

        public void prepareData()
        {
            lines = File.ReadAllLines(@"data/notes_eng.txt");
            for (int i=0; i<lines.Length; i++) {
                string splittedLine = lines[i].Split(". ")[1];
                lines[i] = "Х " + splittedLine.Replace("; ", "\nХ ");
            }
            exits = File.ReadAllText(@"data/can_exit.txt").Split(" ");
        }

        public Form1()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(IdRefresh);
            timer.Interval = 19;
            timer.Start();
        }

        System.Windows.Forms.Timer timer = new();
        public void IdRefresh(object sender, EventArgs e)
        {
            try
            {
                GetProcess("stdrt");
                moduleBase = GetModuleBase(".exe");
                var ptr = ReadPointer(moduleBase, 0x535AC) + 0x1EC;
                int id = ReadInt(ptr);
                bool canExit = false;
                CurrentLocationTextLabel.Text = "Current location number:";
                if (LevelId != id + 1)
                {
                    LevelId = id + 1;
                    if (journeyHistory.Text == "")
                    {
                        journeyHistory.Text = "Journey history:\n" + Convert.ToString(LevelId);
                    }
                    else
                    {
                        journeyHistory.Text += " -> " + Convert.ToString(LevelId);
                    }
                    int transitionsCount = lines[id].Split("\n").Length;
                    transitionsList.Text = "Possible transitions: " + Convert.ToString(transitionsCount) + "\n" + lines[id];
                    foreach (string exit in exits)
                    {
                        int exitInt = Convert.ToInt32(exit) - 1;
                        if (id == exitInt)
                        {
                            canExit = true;
                            break;
                        }
                    }
                    if (canExit)
                    {
                        canExitLabel.Text = "Yes";
                    }
                    else
                    {
                        canExitLabel.Text = "No";
                    }
                }
                
                idlabel.Text = LevelId.ToString();
            }
            catch (Exception ex)
            {
                if (ex is System.InvalidOperationException || ex is System.IndexOutOfRangeException)
                {
                    int noGameIndex = random.Next(0, thereIsNoGame.Length);
                    CurrentLocationTextLabel.Text = "э игру вруби";
                    idlabel.Text = "";
                    canExitLabel.Text = "???";
                    transitionsList.Text = "";
                    journeyHistory.Text = "";
                }  
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int efuktChance = random.Next(0, 1000);
            if (efuktChance == 666)
            {
                this.Text = "efukt explorer";
            }
            prepareData();
        }
    }
}
