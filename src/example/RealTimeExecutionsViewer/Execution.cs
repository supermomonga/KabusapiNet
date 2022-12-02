namespace RealTimeExecutionsViewer;

internal class Execution
{
    public double Price { get; init; }

    public double Quantity { get; init; }

    public Direction Direction { get; init; }

    public DateTimeOffset ExecutedAt { get; init; }
}
