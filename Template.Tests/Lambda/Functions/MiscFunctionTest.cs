namespace Template.Lambda.Functions;

using Xunit;

public sealed class MiscFunctionTest
{
    [Fact]
    public void TestTime()
    {
        var functions = new MiscFunction();

        var response = functions.Time();

        Assert.True(response.DateTime <= DateTime.Now);
    }
}
