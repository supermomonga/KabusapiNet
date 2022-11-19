namespace KabusapiNet.Models;
public class DataReceivedEventArgs<T> : EventArgs
{
    public T Data { get; init; }

    public DataReceivedEventArgs(T data)
        => Data = data;
}
