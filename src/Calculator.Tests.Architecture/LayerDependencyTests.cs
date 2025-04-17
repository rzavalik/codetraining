namespace Calculator.Tests.Architecture;

using System.Reflection;
using NetArchTest.Rules;
using Shouldly;

public class LayerDependencyTests
{
    [Theory]
    [InlineData("Calculator.Application")]
    [InlineData("Calculator.Domain")]
    [InlineData("Calculator.Infrastructure")]
    [InlineData("Calculator.API")]
    [InlineData("Calculator.UI")]
    public void Assembly_Should_Not_Have_Dependency_On_Test_Assemblies(string assemblyName)
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
}
