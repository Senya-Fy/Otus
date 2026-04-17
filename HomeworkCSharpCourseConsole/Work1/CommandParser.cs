namespace HomeworkCSharpCourseConsole.Work1.Models;

public static class CommandParser
{
    private const byte Space = (byte)' ';
    
    public static CommandResult Parse(ReadOnlySpan<byte> input)
    {
        input = TrimStart(input);
        if (input.IsEmpty) return default;
        
        int space1 = input.IndexOf(Space);
        if (space1 == -1) return default;
        
        var command = input.Slice(0, space1);
        var remaining = TrimStart(input.Slice(space1 + 1));
        
        if (remaining.IsEmpty) return default;
        
        int space2 = remaining.IndexOf(Space);
        if (space2 == -1)
        {
            return new CommandResult
            {
                Command = command, Key = remaining, Value = ReadOnlySpan<byte>.Empty
            };
        }

        var key = remaining.Slice(0, space2);
        var value = TrimStart(remaining.Slice(space2 + 1));

        return new CommandResult { Command = command, Key = key, Value = value };
    }

    private static ReadOnlySpan<byte> TrimStart(ReadOnlySpan<byte> input)
    {
        int i = 0;
        while (i < input.Length && input[i] == Space) i++;
        return input.Slice(i);
    }
}