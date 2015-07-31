using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XeClutch;

namespace Seagate_SN_Generator
{
    class Program
    {
        static SeagateDrive ST1000NM0033 = new SeagateDrive("Z1W{#0-2}{ARND4}", SeagateDrive.DriveInterface.SATA, "Constellation ES.3 Internal Drive 9ZM173-003", "1TB", SeagateDrive.DriveType.HDD);
        static SeagateDrive ST2000NM0033 = new SeagateDrive("Z1X{#0-2}{ARND4}", SeagateDrive.DriveInterface.SATA, "Constellation ES.3 Internal Drive 9ZM175-003", "2TB", SeagateDrive.DriveType.HDD);
        static SeagateDrive ST3000NM0033 = new SeagateDrive("Z1Y{#0-2}{ARND4}", SeagateDrive.DriveInterface.SATA, "Constellation ES.3 Internal Drive 9ZM178-003", "3TB", SeagateDrive.DriveType.HDD);
        static SeagateDrive ST4000NM0033 = new SeagateDrive("Z1Z{#0-2}{ARND4}", SeagateDrive.DriveInterface.SATA, "Constellation ES.3 Internal Drive 9ZM170-003", "4TB", SeagateDrive.DriveType.HDD);
        static SeagateDrive ST4000DX001 = new SeagateDrive("Z301{#3-5}{NRND1}{CRND2}", SeagateDrive.DriveInterface.SATA, "Hybrid Internal Drive 1CE168-300", "4TB", SeagateDrive.DriveType.SSHD);
        static SeagateDrive[] drives = { ST1000NM0033, ST2000NM0033, ST3000NM0033, ST4000NM0033, ST4000DX001 };

        static void Main(string[] args)
        {
            ConsoleUtils.Title = "Seagate SN Generator";
            ConsoleUtils.PrintText("Seagate SN Generator 0.1\n", true);
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