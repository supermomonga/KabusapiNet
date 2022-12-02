using KabusapiNet;
using KabusapiNet.Models;

namespace RealTimeExecutionsViewer;

internal class Program
{
    private static readonly object _ConsoleLock = new object();
    private static readonly object _ExecutionsLock = new object();

    private GetBoardResponse? LastOrderBook { get; set; }

    private List<Execution> Executions { get; } = new List<Execution>(40);

    static async Task Main(string[] args)
        => await new Program().RunAsync(args);

    public async Task RunAsync(string[] args)
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
        sym = "6920";
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

        // WebSocket
        kabusapi.OnBoardReceived += OnBoardReceived;
        await kabusapi.SubscribeAsync();

        while (true)
        {
            // TODO: handle SIGTERM
            await Task.Delay(100);
        }
    }
    private void OnBoardReceived(object? sender, DataReceivedEventArgs<GetBoardResponse> e)
    {
        var orderbook = e.Data;
        if (orderbook is not null)
        {
            if (LastOrderBook is not null)
            {
                var execution = GetExecution(LastOrderBook, orderbook);
                if (execution is not null)
                {
                    lock (_ExecutionsLock)
                    {
                        if (Executions.Count() == Executions.Capacity)
                        {
                            Executions.RemoveAt(Executions.Capacity - 1);
                        }
                        Executions.Insert(0, execution);
                        DrawExecutions(Executions);
                    }
                }
            }
            LastOrderBook = orderbook;
        }
    }

    private Execution? GetExecution(GetBoardResponse ob1, GetBoardResponse ob2)
    {
        var volume = ob2.TradingVolume - ob1.TradingVolume;
        if (volume == 0)
        {
            return null;
        }

        var price = ob2.CurrentPrice;

        var direction = ob2.CurrentPriceChangeStatus switch
        {
            CurrentPriceChangeStatus.Unchanged => Direction.Stay,
            CurrentPriceChangeStatus.Up => Direction.Up,
            CurrentPriceChangeStatus.Down => Direction.Down,
            _ => Direction.Unk,
        };

        return new Execution()
        {
            Price = price,
            Quantity = volume,
            Direction = direction,
            ExecutedAt = ob2.TradingVolumeTime
        };
    }

    private void DrawExecutions(IReadOnlyCollection<Execution> executions)
    {
        lock (_ConsoleLock)
        {
            Console.SetCursorPosition(0, 3);
            foreach (var e in executions)
            {
                Console.Write($"| {e.ExecutedAt:HH:mm:ss} | ");
                Console.ForegroundColor = e.Direction switch
                {
                    Direction.Stay => Console.ForegroundColor,
                    Direction.Up => ConsoleColor.Red,
                    Direction.Down => ConsoleColor.Blue,
                    _ => ConsoleColor.Yellow,
                };
                Console.Write($"{e.Price,10}");
                Console.ResetColor();
                Console.WriteLine($" | {e.Quantity,5} |");
            }
        }
    }

    private static void InitializeConsole()
    {
        Console.CursorVisible = false;
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("|     Time |      Price |  Size |");
        Console.WriteLine("---------------------------------");
    }
}
