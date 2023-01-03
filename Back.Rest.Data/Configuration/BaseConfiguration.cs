
namespace Back.Rest.Data.Configuration
{
    /// <summary>
    /// Basic configuration
    /// </summary>
    public class BasicConfiguration
    {
        public DateTime DefaultDate { get; set; } = System.DateTime.UtcNow;
        public int DefaultUserId { get; set; } = 1;
        public bool DefaultStatus { get; set; } = true;
    }
}
