namespace HomeworkCSharpCourseConsole.Work1.Models;

public ref struct CommandResult
{
    public ReadOnlySpan<byte> Command;
    public ReadOnlySpan<byte> Key;
    public ReadOnlySpan<byte> Value;
    
    public bool IsEmpty => Command.IsEmpty && Key.IsEmpty && Value.IsEmpty;
}