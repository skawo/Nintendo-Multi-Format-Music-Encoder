using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMFME
{
    class OpenRevolution
    {
        public static string Exepath = Path.Combine(Program.ExecPath, "openrevo.exe");

        static bool SetCompatMode(string exeFilePath)
        {
            try
            {
                var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers", true);
                if (key == null)
                    throw new InvalidOperationException(@"Cannot open registry key HKCU\SOFTWARE\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers.");
                using (key)
                    key.SetValue(exeFilePath, "~ WIN7RTM");

                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool BWAV2WAV(string InPath, string OutFile, out bool Loop, out int LoopSt, out int LoopEn)
        {
            Loop = false;
            LoopSt = 0;
            LoopEn = 0;

            try
            {
                if (!SetCompatMode(Exepath))
                    return false;

                ProcessStartInfo info = new ProcessStartInfo(Exepath);
                info.Arguments = $" \"{InPath}\" -o \"{OutFile}\"";
                info.UseShellExecute = false;
                info.CreateNoWindow = true;
                info.RedirectStandardOutput = true;
                info.WindowStyle = ProcessWindowStyle.Hidden;

                Process p = new Process();
                p.EnableRaisingEvents = true;
                p.StartInfo = info;
                p.Start();

                p.WaitForExit();
                string Out = p.StandardOutput.ReadToEnd();

                string[] Outl = Out.Split(Environment.NewLine.ToCharArray());

                foreach (string s in Outl)
                {
                    if (s.StartsWith("Loop:"))
                        Loop = Convert.ToBoolean(Convert.ToInt32(s.Split(':')[1].Trim()));

                    if (s.StartsWith("Loop start:"))
                        LoopSt = Convert.ToInt32(s.Split(':')[1].Trim());

                    if (s.StartsWith("Final block samples:"))
                        LoopEn = Convert.ToInt32(s.Split(':')[1].Trim());
                }

                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool WAV2BWAV(string InPath, string OutFile, bool Loop, int LoopSt, int LoopEn)
        {
            try
            {
                if (!SetCompatMode(Exepath))
                    return false;

                ProcessStartInfo info = new ProcessStartInfo(Exepath);
                info.Arguments = $" \"{InPath}\" -o \"{OutFile}\" -l {(Loop ? LoopSt : -1)} --extend {LoopEn}";
                info.UseShellExecute = true;
                info.CreateNoWindow = false;
                info.WindowStyle = ProcessWindowStyle.Hidden;

                Process p = new Process();
                p.EnableRaisingEvents = true;
                p.StartInfo = info;
                p.Start();

                p.WaitForExit();

                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
        }


    }
}
