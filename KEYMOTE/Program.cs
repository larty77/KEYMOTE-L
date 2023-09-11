using Newtonsoft.Json;
using System.Net;
using System.Runtime.InteropServices;

public class AppConfig
{
    public int Port { get; set; }

    public bool ShowConsole { get; set; }
}


internal class Program
{
    [DllImport("kernel32.dll")]
    static extern IntPtr GetConsoleWindow();

    [DllImport("user32.dll")]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    static void Main(string[] args)
    {
        AppConfig config = new AppConfig();
        config.Port = 0;
        config.ShowConsole = true;

        try
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string configPath = Path.Combine(baseDirectory, "config.json");
            string configJson = File.ReadAllText(configPath);

            config = JsonConvert.DeserializeObject<AppConfig>(configJson)!;
        }
        catch
        {
            config.Port = 0;
            config.ShowConsole = true;
        }

        ShowWindow(GetConsoleWindow(), config.ShowConsole ? 1 : 0);

        ICENet.Core.Helpers.Logger.AddInfoListener((m) => WriteLine(m, ConsoleColor.White));
        ICENet.Core.Helpers.Logger.AddErrorListener((m) => WriteLine(m, ConsoleColor.Red));

        new Network(config.Port);

        new KeyActionHandler();



        WriteLine($"\n======================", ConsoleColor.White);
        foreach (var address in Dns.GetHostAddresses(Dns.GetHostName()).Where(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork))
        {
            WriteLine($"{address}:{Network.Instance.Port}", ConsoleColor.Yellow);
        }
        WriteLine($"======================\n", ConsoleColor.White);        
        
        Write($"Everything is great. The server is fully ready to accept connections. On the mobile device you need to enter one of the sockets found (they are highlighted in ", ConsoleColor.White);
        Write($"yellow".ToUpper(), ConsoleColor.Yellow);
        Write($")\n", ConsoleColor.White);

        WriteLine("", ConsoleColor.White);

        Console.ReadLine();
    }

    private static void Write(string text, ConsoleColor color)
    {
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ForegroundColor = originalColor;
    }

    private static void WriteLine(string text, ConsoleColor color)
    {
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ForegroundColor = originalColor;
    }
}
