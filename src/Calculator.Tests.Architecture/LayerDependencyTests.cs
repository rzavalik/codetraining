namespace Calculator.Tests.Architecture;

using System;
using System.Linq;
using System.Reflection;
using NetArchTest.Rules;
using Shouldly;
using Xunit;

public class LayerDependencyTests
{
    [Theory]
    [InlineData("Calculator.Application")]
    [InlineData("Calculator.Domain")]
    [InlineData("Calculator.Infrastructure")]
    [InlineData("Calculator.API")]
    [InlineData("Calculator.UI")]
    public void Assemblies_Should_Not_Reference_Test_Assemblies(string assemblyName)
    {
        Assembly.Load(assemblyName);

        var assembly = AppDomain.CurrentDomain
            .GetAssemblies()
            .FirstOrDefault(a => a.GetName().Name == assemblyName);

        assembly.ShouldNotBeNull($"Assembly {assemblyName} should be loaded for test.");

        var result = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny("*.Tests.*")
            .GetResult();

        result.IsSuccessful.ShouldBeTrue($"{assemblyName} should not depend on any test project.");
    }

    [Fact]
    public void UI_Should_Only_Depend_On_API()
    {
        var assembly = Assembly.Load("Calculator.UI");

        var result = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(
                "Calculator.Application",
                "Calculator.Domain",
                "Calculator.Infrastructure"
            )
            .GetResult();

        result.IsSuccessful.ShouldBeTrue("UI should only talk to API via HTTP.");
    }

    [Fact]
    public void API_Should_Depend_On_Application_And_Domain_Only()
    {
        var assembly = Assembly.Load("Calculator.API");

        var result = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(
                "Calculator.Infrastructure",
                "Calculator.UI"
            )
            .GetResult();

        result.IsSuccessful.ShouldBeTrue("API should not depend on Infrastructure or UI.");
    }

    [Fact]
    public void Application_Should_Depend_On_Domain_Only()
    {
        var assembly = Assembly.Load("Calculator.Application");

        var result = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(
                "Calculator.API",
                "Calculator.Infrastructure",
                "Calculator.UI"
            )
            .GetResult();

        result.IsSuccessful.ShouldBeTrue("Application should only depend on Domain.");
    }

    [Fact]
    public void Domain_Should_Be_Independent()
    {
        var assembly = Assembly.Load("Calculator.Domain");

        var result = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(
                "Calculator.API",
                "Calculator.Application",
                "Calculator.Infrastructure",
                "Calculator.UI"
            )
            .GetResult();

        result.IsSuccessful.ShouldBeTrue("Domain should be independent of all other layers.");
    }

    [Fact]
    public void Infrastructure_Should_Not_Depend_On_API_Or_UI()
    {
        var assembly = Assembly.Load("Calculator.Infrastructure");

        var result = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(
                "Calculator.API",
                "Calculator.UI"
            )
            .GetResult();

        result.IsSuccessful.ShouldBeTrue("Infrastructure should not depend on UI or API.");
    }
}
