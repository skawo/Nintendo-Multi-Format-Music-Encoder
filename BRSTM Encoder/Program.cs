using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BRSTM_Encoder
{

    static class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length == 0)
                Application.Run(new Form1());
            else
            {
                try
                {
                    AttachConsole(ATTACH_PARENT_PROCESS);
                    Form1 f = new Form1();
                    f.LoadFile(args[0]);

                    int LoopSt = 0;
                    int LoopEn = 0;
                    bool Loop = false;


                    if (args.Length >= 2)
                        LoopSt = Convert.ToInt32(args[1]);

                    if (args.Length >= 3)
                    {
                        LoopEn = Convert.ToInt32(args[2]);
                        Loop = true;
                    }

                    Console.WriteLine("");
                    Console.WriteLine($"Convert {args[0]} to {args[0].Replace(".wav", "")}_out.brstm");

                    if (Loop && LoopEn != 0 && LoopSt > LoopEn)
                    {
                        Console.WriteLine("Loop start cannot be smaller than the loop end");
                        return -1;
                    }

                    f.Convert(LoopSt, LoopEn, Loop, $"{args[0].Replace(".wav", "")}_out.brstm");
                    Console.WriteLine("Done!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return 0;
        }
    }
}
