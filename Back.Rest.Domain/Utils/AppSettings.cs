
using ItemsoftMX.Base.Domain.Utils;

namespace Back.Rest.Domain.Utils
{
    public class AppSettings : BaseAppSettings
    {
        public string Version { get; set; } = string.Empty;
        public string ApiName { get; set; } = string.Empty;
    }
}
