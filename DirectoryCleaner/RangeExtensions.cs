namespace DirectoryCleaner;

public static class RangeExtensions
{
    public static bool Contains(this Range range, int value)
    {
        int start = Math.Min(range.Start.Value, range.End.Value);
        int end = Math.Max(range.Start.Value, range.End.Value);
        return start <= value && value <= end;
    }

    public static string ToNormalizedString(this Range range)
    {
        int start = Math.Min(range.Start.Value, range.End.Value);
        int end = Math.Max(range.Start.Value, range.End.Value);

        return start == end
            ? start.ToString()
            : $"{start}-{end}";
    }
}