using System.Diagnostics;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

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

        //!œ–Œ¬≈–»“‹,  ¿  –¿¡Œ“¿ﬁ“ –≈∆»Ã€ Œ“Œ¡–¿∆≈Õ»ﬂ — √¿À ¿Ã»
        //!+œ–» ¬€’Œƒ≈ » œŒ¬“Œ–ÕŒÃ «¿œ”— ≈ »√–€
        //!»ÕŒ√ƒ¿ ◊»«√¿…ƒ≈–  –¿ÿ»“—ﬂ œ–» ƒ≈¡¿√≈ (Õ≈ Õ¿’Œƒ»“ »√–” ¬Œ ¬–≈Ãﬂ «¿œ”— ¿)
        Random random = new Random();
        int noGameIndex;
        int LevelId = 999;
        string[] lines;
        string[] exits;
        string[] names;
        string[] timecodes;
        string[] thereIsNoGame = {
            "GAME CLOSED CODE RED CODE RED",
            "THERE IS NO GAME!!!",
            "No game = no info",
            "Launch the game plz",
            "i see nothing y'know, launch the game",
            //"Hey, you. You're finally awake",
            //"cheese is eaten, but i need more",
            "WHERE'S THE GAME WHERE IS IT AAAAAAAAAAAAAAHHHHH",
            "cheese closed im blind yknow",
            "im very hungry where my chmeese"
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
        string transitionsFromFuture;
        string transitionsWithNames;
        string transitionsFromFutureWithNames = "FUTURE IS SO BRIGHT";
        string journeyHistoryDefault;
        string journeyHistoryWithNames;

        public void prepareData()
        {
            lines = File.ReadAllLines(@"data/notes_eng.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                string splittedLine = lines[i].Split(". ")[1];
                lines[i] = "ï " + splittedLine.Replace("; ", "\nï ");
            }
            exits = File.ReadAllText(@"data/can_exit.txt").Split(" ");
            names = File.ReadAllLines(@"data/levelnames_edited.txt");
            timecodes = File.ReadAllLines(@"data/yt_timecodes.txt");
        }

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(80, 60);
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
                        journeyHistoryDefault = "Journey history:\n" + LevelId.ToString();
                        journeyHistoryWithNames = "Journey history:\n" + names[LevelId-1];
                    }
                    else
                    {
                        journeyHistoryDefault += " -> " + LevelId.ToString();
                        journeyHistoryWithNames += "\n" + names[LevelId - 1];
                    }
                    journeyHistory.Text = journeyHistoryDefault;
                    int transitionsCount = lines[id].Split("\n").Length;
                    transitionsDefault = "Possible transitions: " + transitionsCount.ToString() + "\n" + lines[id];
                    transitionsFromFuture = LevelId.ToString() + ". " + transitionsDefault;
                    transitionsWithNames = "Possible transitions: " + transitionsCount.ToString() + "\n";
                    transitionsFromFutureWithNames = LevelId.ToString() + ". " + transitionsWithNames;
                    foreach (string ttt in lines[id].Split("\n"))
                    {
                        string tttt;
                        if (ttt.Contains("->")) {
                            tttt = ttt.Split("->")[0] + "-> " + names[Convert.ToInt32(ttt.Split("->")[1].Trim())-1];
                        }
                        else
                        {
                            tttt = "ï " + names[Convert.ToInt32(ttt.Split(" ")[1])-1];
                        }
                        transitionsFromFutureWithNames += tttt + "\n";
                    }
                    foreach (string tLine in lines[id].Split("\n"))
                    {
                        string trimmed;
                        string before;
                        bool allowToUseNumber = true;
                        if (tLine.Contains("->"))
                        {
                            trimmed = tLine.Split("->")[1].Trim();
                            before = tLine.Split("->")[0] + "-> ";
                        }
                        else
                        {
                            trimmed = tLine[2..].Trim();
                            before = "ï ";
                        }
                        foreach (string name in names)
                        {
                            string num = name.Split('.')[0];
                            if (num == trimmed)
                            {
                                allowToUseNumber = true;
                                break;
                            } 
                        }
                        if (allowToUseNumber)
                        {
                            int nextLevel = Convert.ToInt32(trimmed);
                            transitionsWithNames += before + names[nextLevel-1] + "\n";
                            transitionsFromFuture += "\n\n" + nextLevel.ToString() + ". Possible transitions: ";
                            transitionsFromFuture += lines[nextLevel - 1].Split("\n").Length.ToString() + "\n" + lines[nextLevel - 1];
                            transitionsFromFutureWithNames += "\n" + names[nextLevel - 1] + ". Possible transitions: ";
                            string[] fnLines = lines[nextLevel - 1].Split("\n");
                            transitionsFromFutureWithNames += fnLines.Length.ToString() + "\n";
                            foreach (string t in fnLines)
                            {
                                string firsthalf;
                                string secondhalf;
                                if (t.Contains("->"))
                                {
                                    string[] fnSplit = t.Split("->");
                                    firsthalf = fnSplit[0] + "-> ";
                                    secondhalf = names[Convert.ToInt32(fnSplit[1].Trim())-1];
                                }
                                else
                                {
                                    firsthalf = "ï ";
                                    secondhalf = names[Convert.ToInt32(t.Split(" ")[1].Trim())-1];
                                }
                                transitionsFromFutureWithNames += firsthalf + secondhalf + "\n";
                            }
                        }
                    }
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
                if (LocationNamesCheckbox.Checked)
                {
                    if (journeyHistoryWithNames != journeyHistory.Text)
                        journeyHistory.Text = journeyHistoryWithNames;
                    if (ShowFutureCheckBox.Checked)
                    {
                        if (transitionsFromFutureWithNames != transitionsList.Text)
                            transitionsList.Text = transitionsFromFutureWithNames;
                    }
                    else
                    {
                        if (transitionsWithNames != transitionsList.Text)
                            transitionsList.Text = transitionsWithNames;
                    }
                }
                else
                {
                    if (journeyHistoryDefault != journeyHistory.Text)
                        journeyHistory.Text = journeyHistoryDefault;
                    if (ShowFutureCheckBox.Checked)
                    {
                        if (transitionsFromFuture != transitionsList.Text)
                            transitionsList.Text = transitionsFromFuture;
                    }
                    else
                    {
                        if (transitionsDefault != transitionsList.Text)
                            transitionsList.Text = transitionsDefault;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is System.InvalidOperationException || ex is System.IndexOutOfRangeException)
                {
                    //CurrentLocationTextLabel.Text = "˝ Ë„Û ‚Û·Ë";
                    CurrentLocationTextLabel.Text = thereIsNoGame[noGameIndex];
                    idlabel.Text = "";
                    canExitLabel.Text = "???";
                    transitionsList.Text = "";
                    journeyHistory.Text = "";
                    keyLocationsList.Text = "";
                    LevelId = 999;
                    rhizome_56.ForeColor = Color.Red;
                    rhizome_98.ForeColor = Color.Red;
                    rhizome_204.ForeColor = Color.Red;
                    rhizome_268.ForeColor = Color.Red;
                    rhizome_350.ForeColor = Color.Red;
                    rhizome_476.ForeColor = Color.Red;
                    transitionsDefault = "";
                    transitionsFromFuture = "";
                    journeyHistoryDefault = "";
                    journeyHistoryWithNames = "";
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
