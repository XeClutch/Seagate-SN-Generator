using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XeClutch;

namespace Seagate_SN_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("Drives");
            SeagateDrive[] drives = new SeagateDrive[files.Length];
            for (int i = 0; i < files.Length; i++)
            {
                string[] lines = File.ReadAllLines(files[i]);
                SeagateDrive.DriveType type;
                if (lines[4].Contains("HDD")) type = SeagateDrive.DriveType.HDD;
                else if (lines[4].Contains("SSD")) type = SeagateDrive.DriveType.SSD;
                else type = SeagateDrive.DriveType.SSHD;
                drives[i] = new SeagateDrive(lines[0].Replace("Algorithm: ", ""), (lines[1] == "Interface: SATA" ? SeagateDrive.DriveInterface.SATA : SeagateDrive.DriveInterface.IDE), lines[2].Replace("Name: ", "") + " " + files[i].Replace("Drives\\", "").Replace(".txt", ""), lines[3].Replace("Size: ", ""), type);
            }

            ConsoleUtils.Title = "Seagate SN Generator";
            ConsoleUtils.PrintText("Seagate SN Generator 1.1\n", true);
            ConsoleUtils.PrintText("Please choose a product:", true);
            for (int i = 0; i < drives.Length; i++)
                ConsoleUtils.PrintText(string.Format("  [{0}] {1} ({2}, {3}, {4})", (i + 1), drives[i].Name, Enum.GetName(typeof(SeagateDrive.DriveInterface), drives[i].Interface), Enum.GetName(typeof(SeagateDrive.DriveType), drives[i].Type), drives[i].Size), true);
            int drive = ConsoleUtils.ReadInt() - 1;

            ConsoleUtils.Beep();
            ConsoleUtils.Clear();
            ConsoleUtils.PrintText(string.Format("Selected: {0} ({1}, {2}, {3})\n", drives[drive].Name, Enum.GetName(typeof(SeagateDrive.DriveInterface), drives[drive].Interface), Enum.GetName(typeof(SeagateDrive.DriveType), drives[drive].Type), drives[drive].Size), true);
            int count = int.Parse(ConsoleUtils.PrintQuestion("How many serial numbers would you like to generate (max = 20)? "));
            if (count > 20) count = 20;
            else if (count < 1) count = 1;

            ConsoleUtils.Beep();
            ConsoleUtils.Print("", true);
            for (int i = 0; i < count; i++)
                ConsoleUtils.PrintText(string.Format("[{0}] {1}", (i + 1), drives[drive].GenerateSN()), true);

            ConsoleUtils.Wait();
        }
    }
}