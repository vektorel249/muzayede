using System.Reflection;

namespace Vektorel.Muzayede.Modules.Users;

public class UserModuleAssemblyMarker
{
    public static Assembly GetAssembly()
    {
        // Assembly.GetExecutingAssembly(); => çalışan uygulama
        return typeof(UserModuleAssemblyMarker).Assembly;
    }
}
