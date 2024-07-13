using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace NMFME
{

    static class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;
        public static string ExecPath = "";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Program.ExecPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

            if (args.Length == 0)
                Application.Run(new Form1());
            else
            {
                try
                {
                    AttachConsole(ATTACH_PARENT_PROCESS);

                    if (args.Length == 1)
                    {
                        PrintUsage();
                        return 0;
                    }


                    Form1 f = new Form1();
                    f.LoadFile(args[0]);

                    string Extension = "";
                    
                    switch (args[1].ToUpper())
                    {
                        case "BRSTM": f.OutType = VGAudio.Containers.NintendoWare.NwTarget.Revolution; Extension = "brstm";  break;
                        case "BCSTM": f.OutType = VGAudio.Containers.NintendoWare.NwTarget.Ctr; Extension = "bcstm"; break;
                        case "BFSTM": f.OutType = VGAudio.Containers.NintendoWare.NwTarget.Cafe; Extension = "bfstm"; break;
                        case "BWAV": f.OutType = "BWAV"; Extension = "bwav"; break;
                        case "WAV": f.OutType = "WAV"; Extension = "wav"; break;
                        default:
                            {
                                PrintUsage();
                                return 0;
                            }
                    }

                    int LoopSt = f.Audio.AudioFormat.LoopStart;
                    int LoopEn = f.Audio.AudioFormat.LoopEnd;
                    bool Loop = f.Audio.AudioFormat.Looping;
                    float Volume = 1.0f;


                    if (args.Length >= 3)
                        Volume = (float)Convert.ToDecimal(args[2]);

                    if (args.Length >= 4)
                        LoopSt = Convert.ToInt32(args[3]);

                    if (args.Length >= 5)
                    {
                        LoopEn = Convert.ToInt32(args[4]);
                        Loop = true;
                    }

                    Console.WriteLine("");
                    Console.WriteLine($"Convert {args[0]} to {args[0].Replace(".wav", "")}_out." + Extension);

                    if (Loop && LoopEn != 0 && LoopSt > LoopEn)
                    {
                        Console.WriteLine("Loop start cannot be smaller than the loop end");
                        return -1;
                    }

                    f.Convert(Volume, LoopSt, LoopEn, Loop, $"{args[0].Replace(".wav", "")}_out." + Extension);
                    Console.WriteLine("Done!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return 0;
        }

        public static void PrintUsage()
        {
            Console.WriteLine("");
            Console.WriteLine("Nintendo Multi-Format Music Encoder v. 2.0.4 by Skawo");
            Console.WriteLine("Usage: NMFME.exe infile outfile_type(BRSTM|BCSTM|BFSTM|BWAV) volume_change loopStart loopEnd");
        }
    }
}
