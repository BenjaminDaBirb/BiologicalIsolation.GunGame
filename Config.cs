using System.ComponentModel;
using Exiled.API.Features;
using Exiled.API.Interfaces;

namespace GunGame
{
    public class Config : IConfig
    {
        [Description("Indicates whether the plugin is enabled or not")]
        public bool IsEnabled { get; set; }
    }
}
