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
        }

        Console.WriteLine("Start connecting...");
        var kabusapi = new KabusapiClient(pw);

        var symbol = new SymbolInfo("6758", ExchangeCode.TokyoStockExchange);

        await kabusapi.PutUnregisterAllAsync();
        await kabusapi.PutRegisterAsync(symbol);
        var orderbook = await kabusapi.GetBoardAsync(symbol.Symbol, ExchangeCode.TokyoStockExchange);

        Console.CursorVisible = false;
        Console.Clear();

        kabusapi.OnBoardReceived += OnBoardReceived;

        Console.ReadLine();
    }

    private static void OnBoardReceived(object? sender, DataReceivedEventArgs<GetBoardResponse> e)
    {
        var orderbook = e.Data;
        lock (_ConsoleLock)
        {
            Console.SetCursorPosition(0, 0);

            Console.WriteLine(orderbook.BidTime);
            foreach (var l in orderbook.Asks)
            {
                Console.WriteLine("ASK {0:10d} => {1:10d}", l.Price, l.Quantity);
            }
            foreach (var l in orderbook.Bids)
            {
                Console.WriteLine("BID {0:10d} => {1:10d}", l.Price, l.Quantity);
            }
            Console.WriteLine(orderbook.AskTime);
        }
    }
}
