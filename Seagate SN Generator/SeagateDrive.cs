using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XeClutch
{
    public class SeagateDrive
    {
        public enum DriveInterface
        {
            IDE,
            SATA,
        }
        public enum DriveType
        {
            HDD,
            SSD,
            SSHD,
        }

        private string m_algorithm;
        public string Algorithm
        {
            get
            {
                return m_algorithm;
            }
            set
            {
                m_algorithm = value;
            }
        }
        private DriveInterface m_interface;
        public DriveInterface Interface
        {
            get
            {
                return m_interface;
            }
            set
            {
                m_interface = value;
            }
        }
        private string m_name;
        public string Name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
            }
        }
        private string m_size;
        public string Size
        {
            get
            {
                return m_size;
            }
            set
            {
                m_size = value;
            }
        }
        private DriveType m_type;
        public DriveType Type
        {
            get
            {
                return m_type;
            }
            set
            {
                m_type = value;
            }
        }

        /// <summary>
        /// Creates and initializes a new instance of the Drive class.
        /// </summary>
        /// <param name="drivealgorithm">The algorithm we can use to generate the serial number.</param>
        /// <param name="driveinterface">The drive interface.</param>
        /// <param name="drivename">The name of the drive.</param>
        /// <param name="drivesize">The size of the drive.</param>
        /// <param name="drivetype">The type of drive.</param>
        public SeagateDrive(string drivealgorithm, DriveInterface driveinterface, string drivename, string drivesize, DriveType drivetype)
        {
            m_algorithm = drivealgorithm;
            m_interface = driveinterface;
            m_name = drivename;
            m_size = drivesize;
            m_type = drivetype;
        }

        /// <summary>
        /// Generate a serial number using the algorithm provided on initialization.
        /// </summary>
        public string GenerateSN()
        {
            string sn = "";
            char[] algchars = m_algorithm.ToCharArray();
            int algprogress = 0;
            while (algprogress != algchars.Length)
            {
                if (algchars[algprogress] == '{')
                {
                    algprogress++;
                    if (algchars[algprogress] == 'A')
                    {
                        bool rand = GeneralUtils.GenerateRandomInt(algprogress + sn.Length, 0, 50001) > 25000;
                        algprogress += 4;
                        if (rand)
                            sn += GeneralUtils.GenerateRandomString(algprogress + sn.Length, int.Parse(algchars[algprogress].ToString()));
                        else
                            for (int i = 0; i < int.Parse(algchars[algprogress].ToString()); i++)
                                sn += GeneralUtils.GenerateRandomInt(algprogress + sn.Length + i, 0, 9);

                    }
                    else if (algchars[algprogress] == 'C')
                    {
                        algprogress += 4;
                        sn += GeneralUtils.GenerateRandomString(algprogress + sn.Length, int.Parse(algchars[algprogress].ToString()));
                    }
                    else if (algchars[algprogress] == 'N')
                    {
                        algprogress += 4;
                        for (int i = 0; i < int.Parse(algchars[algprogress].ToString()); i++)
                            sn += GeneralUtils.GenerateRandomInt(algprogress + sn.Length + i, 0, 9);
                    }
                    else if (algchars[algprogress] == '#')
                    {
                        algprogress++;
                        int num1 = int.Parse(algchars[algprogress].ToString());
                        algprogress += 2;
                        int num2 = int.Parse(algchars[algprogress].ToString());
                        sn += GeneralUtils.GenerateRandomInt(algprogress + sn.Length * (num1 + num2), num1, num2);
                    }
                    algprogress += 2;
                }
                else
                {
                    sn += algchars[algprogress];
                    algprogress++;
                }
            }
            Thread.Sleep(10);
            return sn.Replace("}", "").ToUpper();
        }
    }
}