using System.Text;
using NUnit.Framework;
using HomeworkCSharpCourseConsole.Work1.Models;

namespace HomeworkTest;

public class Tests
{
    [Test]
    [Description("Проверяет стандартный сценарий")]
    public void TestParseSetCommand()
    {
        var input = Encoding.UTF8.GetBytes("SET user_123 Ivan_Ivanov");
        var result = CommandParser.Parse(input);
        
        Assert.That(Encoding.UTF8.GetString(result.Command), Is.EqualTo("SET"));
        Assert.That(Encoding.UTF8.GetString(result.Key), Is.EqualTo("user_123"));
        Assert.That(Encoding.UTF8.GetString(result.Value), Is.EqualTo("Ivan_Ivanov"));
    }
    
    [Test]
    [Description("Проверяет, что если третьего слова нет, парсер корректно заполняет поля, оставляя Value пустым")]
    public void TestParseGetCommandEmptyValue()
    {
        var input = Encoding.UTF8.GetBytes("GET user_123");
        var result = CommandParser.Parse(input);
        
        Assert.That(Encoding.UTF8.GetString(result.Command), Is.EqualTo("GET"));
        Assert.That(Encoding.UTF8.GetString(result.Key), Is.EqualTo("user_123"));
        Assert.That(result.Value.IsEmpty, Is.True); 
    }
    
    [Test]
    [Description("Тест на некорректную команду")]
    public void TestParseSetCommandEmptyResult()
    {
        var input = Encoding.UTF8.GetBytes("SET   ");
        var result = CommandParser.Parse(input);
        
        Assert.That(result.IsEmpty, Is.True); 
    }
    
    [Test]
    [Description("Тест на лишние пробелы")]
    public void TestParseSetCommandExtraSpaces()
    {
        var input = Encoding.UTF8.GetBytes("     SET     user_123     Ivan_Ivanov");
        var result = CommandParser.Parse(input);
        
        Assert.That(Encoding.UTF8.GetString(result.Command), Is.EqualTo("SET"));
        Assert.That(Encoding.UTF8.GetString(result.Key), Is.EqualTo("user_123"));
        Assert.That(Encoding.UTF8.GetString(result.Value), Is.EqualTo("Ivan_Ivanov"));
    }
}