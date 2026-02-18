using Accessibility;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
        int noGameIndex;
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
        int[] keyLocations =
        {
            500, 98, 484, 444, 285, 302, 73, 488, 462, 148,
            270, 211, 219, 471, 497, 254, 417, 341, 264, 269,
            277, 197, 350, 304, 315, 318, 331, 332, 347, 413,
            405, 356, 489, 397, 175, 431, 493, 583, 510, 475,
            476, 361, 495, 606, 537, 608, 505
        };
        List<int> keyLocVisited = new List<int> { };
        int[] rhizomeLocs = { 56, 98, 204, 268, 350, 476 };
        int currentRhizomeLoc = 0;
        string transitionsDefault;

        public void prepareData()
        {
            lines = File.ReadAllLines(@"data/notes_eng.txt");
            for (int i = 0; i < lines.Length; i++)
            {
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
                noGameIndex = random.Next(0, thereIsNoGame.Length);
                CurrentLocationTextLabel.Text = "Current location number:";
                if (LevelId != id + 1)
                {
                    LevelId = id + 1;
                    idlabel.Text = LevelId.ToString();
                    if (journeyHistory.Text == "")
                    {
                        journeyHistory.Text = "Journey history:\n" + LevelId.ToString();
                    }
                    else
                    {
                        journeyHistory.Text += " -> " + LevelId.ToString();
                    }
                    int transitionsCount = lines[id].Split("\n").Length;
                    transitionsList.Text = "Possible transitions: " + transitionsCount.ToString() + "\n" + lines[id];
                    transitionsDefault = transitionsList.Text;
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
                        canExitLabel.Text = "YES";
                    }
                    else
                    {
                        canExitLabel.Text = "NO";
                    }
                    foreach (int keyLoc in keyLocations)
                    {
                        if (keyLoc == LevelId)
                        {
                            keyLocVisited.Add(LevelId);
                            keyLocVisited.Sort();
                            var result = keyLocVisited
                                .GroupBy(x => x)
                                .OrderBy(g => g.Key)
                                .Select(g => g.Count() > 1 ? $"{g.Key}(x{g.Count()})" : $"{g.Key}");
                            keyLocationsList.Text = string.Join(", ", result);
                        }
                    }
                    int rhizomeIndex = Array.IndexOf(rhizomeLocs, LevelId);
                    if (rhizomeIndex != -1)
                    {
                        currentRhizomeLoc = LevelId;
                        if (currentRhizomeLoc == 56) rhizome_56.ForeColor = Color.Green; else rhizome_56.ForeColor = Color.Red;
                        if (currentRhizomeLoc == 98) rhizome_98.ForeColor = Color.Green; else rhizome_98.ForeColor = Color.Red;
                        if (currentRhizomeLoc == 204) rhizome_204.ForeColor = Color.Green; else rhizome_204.ForeColor = Color.Red;
                        if (currentRhizomeLoc == 268) rhizome_268.ForeColor = Color.Green; else rhizome_268.ForeColor = Color.Red;
                        if (currentRhizomeLoc == 350) rhizome_350.ForeColor = Color.Green; else rhizome_350.ForeColor = Color.Red;
                        if (currentRhizomeLoc == 476) rhizome_476.ForeColor = Color.Green; else rhizome_476.ForeColor = Color.Red;
                    }
                }
                if (ShowFutureCheckBox.Checked)
                {
                    //изменение типа отображени€
                    transitionsList.Text = "a";
                }
                if (!ShowFutureCheckBox.Checked)
                {
                    transitionsList.Text = transitionsDefault;
                }
            }
            catch (Exception ex)
            {
                if (ex is System.InvalidOperationException || ex is System.IndexOutOfRangeException)
                {
                    //CurrentLocationTextLabel.Text = "э игру вруби";
                    CurrentLocationTextLabel.Text = thereIsNoGame[noGameIndex];
                    idlabel.Text = "";
                    canExitLabel.Text = "???";
                    transitionsList.Text = "";
                    journeyHistory.Text = "";
                    keyLocationsList.Text = "";
                    LevelId = 999;
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
            noGameIndex = random.Next(0, thereIsNoGame.Length);
            CurrentLocationTextLabel.Text = thereIsNoGame[noGameIndex];
            prepareData();
        }
    }
}
