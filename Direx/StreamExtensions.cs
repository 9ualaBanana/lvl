namespace Direx;

public static class StreamExtensions
{
    const int _DefaultBufferSize = 81920;

    public static void CopyAtMost(
        this Stream source,
        Stream destination,
        int maximumBytes) => source.CopyAtMost(destination, maximumBytes, _DefaultBufferSize);

    public static void CopyAtMost(
        this Stream source,
        Stream destination,
        int maximumBytes,
        int bufferSize)
    {
        var buffer = new byte[bufferSize];
        int copied = 0;
        int read, toCopy;
        while (copied < maximumBytes)
        {
            if ((read = source.Read(buffer.AsSpan())) != 0)
            {
                toCopy = Math.Min(read, maximumBytes - copied);
                destination.Write(buffer.AsSpan(0, toCopy));
                copied += toCopy;
            }
            else break;
        }
    }

    public static async ValueTask CopyAtMostAsync(
        this Stream source,
        Stream destination,
        int maximumBytes,
        CancellationToken cancellationToken = default) =>
            await source.CopyAtMostAsync(destination, maximumBytes, _DefaultBufferSize, cancellationToken);

    public static async ValueTask CopyAtMostAsync(
        this Stream source,
        Stream destination,
        int maximumBytes,
        int bufferSize,
        CancellationToken cancellationToken = default)
    {
        var buffer = new byte[bufferSize];
        int copied = 0;
        int read, toCopy;
        while (copied < maximumBytes)
        {
            if ((read = await source.ReadAsync(buffer.AsMemory(), cancellationToken)) != 0)
            {
                toCopy = Math.Min(read, maximumBytes - copied);
                await destination.WriteAsync(buffer.AsMemory(0, toCopy), cancellationToken);
                copied += toCopy;
            }
            else break;
        }
    }
}
