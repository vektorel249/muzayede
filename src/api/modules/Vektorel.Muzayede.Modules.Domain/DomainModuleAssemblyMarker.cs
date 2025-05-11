using System.Reflection;

namespace Vektorel.Muzayede.Modules.Domain;

public class DomainModuleAssemblyMarker
{
    public static Assembly GetAssembly()
    {
        return typeof(DomainModuleAssemblyMarker).Assembly;
    }
}
