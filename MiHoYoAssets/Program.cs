namespace MiHoYoAssets
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            if (args.Length == 0)
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new MiHoYoForm());
            }
            else
            {
                CreateConsole();
                var parser = new Parser(config =>
                {
                    config.AutoHelp = true;
                    config.AutoVersion = true;
                    config.HelpWriter = Console.Out;
                });
                parser.ParseArguments<Options>(args)
                .WithParsed(o =>
                {
                    try
                    {
                        var format = FormatManager.GetFormat(o.Format);
                        format.Process(o.Input, o.Output, o.IsEncrypt);
                    }
                    catch (NotImplementedException)
                    {
                        Console.WriteLine("This feature is not supported yet !!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                    }
                })
                .WithNotParsed(o =>
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                });
            }
        }

        public static void CreateConsole()
        {
            AllocConsole();
            SetConsoleTitle(Application.ProductName);
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetConsoleTitle(string lpConsoleTitle);
    }

    public class Options
    {
        [Option('f', "format", Required = true, HelpText = "Format to process.")]
        public string Format { get; set; }

        [Option('e', "encrypt", HelpText = "Enbale encryption (default is decryption).")]
        public bool IsEncrypt { get; set; }

        [Value(0, MetaName = "input_path", Required = true, HelpText = "Input to process.")]
        public string Input { get; set; }

        [Value(1, MetaName = "output_path", Required = true, HelpText = "Output Directory.")]
        public string Output { get; set; }
    }
}