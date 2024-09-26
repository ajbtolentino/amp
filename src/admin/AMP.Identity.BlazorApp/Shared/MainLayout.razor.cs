using System.Runtime.InteropServices;

namespace AMP.Identity.BlazorApp.Shared
{
    public partial class MainLayout
    {
        static bool IsClientSide => RuntimeInformation.IsOSPlatform(OSPlatform.Create("BROWSER"));
    }
}
