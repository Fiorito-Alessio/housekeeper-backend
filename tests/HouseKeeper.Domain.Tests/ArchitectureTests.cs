using System.Reflection;

namespace HouseKeeper.Domain.Tests;

public class ArchitectureTests
{
    [Fact]
    public void DomainDoesNotDependOnOtherHouseKeeperProjects()
    {
        var domain = Assembly.Load("HouseKeeper.Domain");

        var houseKeeperReferences = domain
            .GetReferencedAssemblies()
            .Where(reference => reference.Name?.StartsWith("HouseKeeper.", StringComparison.Ordinal) == true);

        Assert.Empty(houseKeeperReferences);
    }
}
