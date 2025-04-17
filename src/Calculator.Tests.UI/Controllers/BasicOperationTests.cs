namespace Calculator.Tests.UI.Controllers;

using Microsoft.AspNetCore.Mvc;
using Shouldly;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Ignore("Ignore this test for now")]
    [TestCase(1, 2)]
    [TestCase(-10, 20)]
    public void Add(int a, int b)
    {
        var sut = MakeSut();

        var result = sut.Add(a, b);

        result.ShouldBeOfType<JsonResult>();

        var data = result as Dictionary<string, int>;
        data.ShouldNotBeNull()
            .ShouldContainKey("result");
        data.ShouldContainKeyAndValue("result", a + b);
    }

    private Calculator.UI.Controllers.BasicOperationController MakeSut()
    {
        return new Calculator.UI.Controllers.BasicOperationController();
    }
}
