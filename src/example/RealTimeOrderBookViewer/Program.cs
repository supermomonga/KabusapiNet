using KabusapiNet;
using KabusapiNet.Models;

namespace RealTimeOrderBookViewer;

internal class Program
{
    private static readonly object _ConsoleLock = new object();

    static async Task Main(string[] args)
    {
        var pw = string.Empty;
        while (string.IsNullOrEmpty(pw))
        {
            Console.WriteLine("Please enter API password:");
            Console.Write(" =>");
            pw = Console.ReadLine()?.Trim() ?? string.Empty;
#if DEBUG
            if (string.IsNullOrEmpty(pw))
            {
                pw = "password";
            }
#endif
        }

        Console.WriteLine("Start connecting...");
        var kabusapi = new KabusapiClient(pw);
        await kabusapi.RefreshTokenIfNeededAsync();

        if (!kabusapi.IsAuthenticated)
        {
            Console.WriteLine("Authentication failed.");
            Console.ReadLine();
            Environment.Exit(1);
        }
        var symbol = new SymbolInfo("6758", ExchangeCode.TokyoStockExchange);

        await kabusapi.PutUnregisterAllAsync();
        await kabusapi.PutRegisterAsync(symbol);
        var orderbook = await kabusapi.GetBoardAsync(symbol.Symbol, ExchangeCode.TokyoStockExchange);

        Console.CursorVisible = false;
        Console.Clear();

        kabusapi.OnBoardReceived += OnBoardReceived;
        await kabusapi.SubscribeAsync();

        while (true)
        {
            await Task.Delay(100);
        }
    }

    private static void OnBoardReceived(object? sender, DataReceivedEventArgs<GetBoardResponse> e)
    {
        var orderbook = e.Data;
        var spread = orderbook.BidPrice - orderbook.AskPrice;
        var now = DateTime.Now;
        var latency = now - orderbook.UpdatedAt;
        lock (_ConsoleLock)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Received: {now:yyyy-MM-dd HH:mm:ss.fff}");
            Console.WriteLine($"Latency : {latency}");

            Console.WriteLine("------------------------------");
            Console.WriteLine("{0:yyyy-MM-dd HH:mm:ss.fff}", orderbook.BidTime);
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var l in orderbook.Asks.Reverse())
            {
                Console.WriteLine("Ask    {0, 10} => {1, 10}", l.Price, l.Quantity);
            }

            Console.ResetColor();
            Console.WriteLine("Spread {0, 10}", spread);

            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var l in orderbook.Bids)
            {
                Console.WriteLine("Bid    {0, 10} => {1, 10}", l.Price, l.Quantity);
            }

            Console.ResetColor();
            Console.WriteLine("{0:yyyy-MM-dd HH:mm:ss.fff}", orderbook.AskTime);
            Console.WriteLine("------------------------------");
        }
    }
}
