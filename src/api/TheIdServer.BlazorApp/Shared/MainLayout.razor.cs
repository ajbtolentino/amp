using System.Runtime.InteropServices;

namespace TheIdServer.BlazorApp.Shared
{
    public partial class MainLayout
    {
        static bool IsClientSide => RuntimeInformation.IsOSPlatform(OSPlatform.Create("BROWSER"));
    }
}
