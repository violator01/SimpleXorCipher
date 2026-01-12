using System;
using System.IO;
using System.Windows.Forms;

using SimpleXorCipher.Forms;

namespace SimpleXorCipher
{
    static class Program
    {
        private static StringKeyForm _skf;
        private static IntKeyForm _ikf;

        [STAThread]
        static void Main()
        {
            Console.Title = Common.AppName;
            Console.ForegroundColor = ConsoleColor.Blue;

            DPIHelper.EnablePerMonitorAwareV2DPI();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _skf = new StringKeyForm();
            _ikf = new IntKeyForm();

            while (true)
            {
                Process();
                GC.Collect();
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("[1]: Again | [2]: Exit");

                while (true)
                {
                    var cki = Console.ReadKey(true);
                    if(cki.Key == ConsoleKey.D1) break;
                    else if(cki.Key == ConsoleKey.D2) return;
                }
                Console.Clear();
            }
        }

        static void Process()
        {
            try
            {
                Console.WriteLine($"--- {Common.AppName} V{Common.AppShortVersion} ---");
                Console.WriteLine();
                Console.Write("Select input file: ");
                using (var ofd = new OpenFileDialog())
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        using (Stream inS = ofd.OpenFile())
                        {
                            Console.WriteLine(ofd.FileName);
                            Console.Write("Select save path: ");
                            using (var sfd = new SaveFileDialog
                            {
                                Filter = $"DAT file|*.dat|BIN file|*.bin|Text file|*.txt|Original extension|*{Path.GetExtension(ofd.FileName)}|All files|*.*",
                                FileName = Path.GetFileName(ofd.FileName) + "_Encrypted",
                            })
                            {
                                if (sfd.ShowDialog() == DialogResult.OK)
                                {
                                    using (Stream outS = sfd.OpenFile())
                                    {
                                        Console.WriteLine(sfd.FileName);
                                        Console.WriteLine();
                                        Console.WriteLine("Select key type:");
                                        Console.Write("[1]: String | [2]: Integer | [3]: Cancel");

                                        while(true)
                                        {
                                            var cki = Console.ReadKey(true);
                                            if(cki.Key == ConsoleKey.D1)
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine();
                                                Console.Write("Enter string key: ");

                                                if (_skf.ShowDialog() == DialogResult.OK)
                                                {
                                                    string key = _skf.keyTextBox.Text;
                                                    Console.WriteLine();
                                                    Console.WriteLine();
                                                    Console.Write("Encrypt...");
                                                    XorCipher.Encrypt(inS, outS, key);
                                                }
                                                else
                                                {
                                                    outS.Close();
                                                    File.Delete(sfd.FileName);
                                                    Console.WriteLine();
                                                    Console.WriteLine("Operation cancelled!");
                                                    return;
                                                }
                                                break;
                                            }
                                            else if(cki.Key == ConsoleKey.D2)
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine();
                                                Console.Write("Enter integer key: ");

                                                if (_ikf.ShowDialog() == DialogResult.OK)
                                                {
                                                    long key = (long)_ikf.keyNumeric.Value;
                                                    Console.WriteLine();
                                                    Console.WriteLine();
                                                    Console.Write("Encrypt...");
                                                    XorCipher.Encrypt(inS, outS, key);
                                                }
                                                else
                                                {
                                                    outS.Close();
                                                    File.Delete(sfd.FileName);
                                                    Console.WriteLine();
                                                    Console.Write("Operation cancelled!");
                                                    return;
                                                }
                                                break;
                                            }
                                            else if(cki.Key == ConsoleKey.D3)
                                            {
                                                outS.Close();
                                                File.Delete(sfd.FileName);
                                                Console.WriteLine();
                                                Console.Write("Operation cancelled!");
                                                return;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.Write("Operation cancelled!");
                                    return;
                                }
                            }
                        }
                        Console.WriteLine();
                        Console.Write("Successfully encrypted!");
                        MessageBox.Show($"Success!", Common.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.Write("Operation cancelled!");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.Write($"An error occurred: {e.ToString()}");
            }
        }
    }
}
