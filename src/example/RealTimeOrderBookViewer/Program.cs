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

        var sym = string.Empty;
        while (string.IsNullOrEmpty(sym))
        {
            Console.WriteLine("Please enter symbol code:");
            Console.Write(" =>");
            sym = Console.ReadLine()?.Trim() ?? string.Empty;
#if DEBUG
            if (string.IsNullOrEmpty(sym))
            {
                // SONY
                sym = "6758";
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
        Console.WriteLine("Successfully authenticated.");

        var symbol = new SymbolInfo(sym, ExchangeCode.TokyoStockExchange);

        Console.WriteLine("Unregister all symbols.");
        await kabusapi.PutUnregisterAllAsync();

        Console.WriteLine($"Register `{symbol.Symbol}`.");
        await kabusapi.PutRegisterAsync(symbol);

        InitializeConsole();

        // REST
        var orderbook = await kabusapi.GetBoardAsync(symbol.Symbol, ExchangeCode.TokyoStockExchange);
        if (orderbook is not null)
        {
            RedrawOrderBook(orderbook);
        }

        // WebSocket
        kabusapi.OnBoardReceived += OnBoardReceived;
        await kabusapi.SubscribeAsync();

        while (true)
        {
            // TODO: handle SIGTERM
            await Task.Delay(10);
        }
    }

    private static void OnBoardReceived(object? sender, DataReceivedEventArgs<GetBoardResponse> e)
    {
        var orderbook = e.Data;
        if (orderbook is not null)
        {
            RedrawOrderBook(orderbook);
        }
    }

    private static void RedrawOrderBook(GetBoardResponse orderbook)
    {
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

    private static void InitializeConsole()
    {
        Console.CursorVisible = false;
        Console.Clear();
    }
}
