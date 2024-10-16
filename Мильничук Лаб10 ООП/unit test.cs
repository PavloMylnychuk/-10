using System;
using System.Collections.Generic;
using Xunit;

public class ListyIteratorTests
{
    [Fact]
    public void TestMoveAndHasNext()
    {
        var iterator = new ListyIterator<int>(1, 2, 3);
        Assert.True(iterator.Move());
        Assert.True(iterator.HasNext());
        Assert.True(iterator.Move());
        Assert.True(iterator.HasNext());
        Assert.True(iterator.Move());
        Assert.False(iterator.HasNext());
    }

    [Fact]
    public void TestPrint()
    {
        var iterator = new ListyIterator<string>("Hello", "World");
        iterator.Move(); // Move to "Hello"
        var output = new StringWriter();
        Console.SetOut(output);
        iterator.Print();
        Assert.Equal("Hello\n", output.ToString());
    }

    [Fact]
    public void TestPrintEmpty()
    {
        var iterator = new ListyIterator<string>();
        Assert.Throws<InvalidOperationException>(() => iterator.Print());
    }
}
