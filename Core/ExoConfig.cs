using System.ComponentModel;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace CalamityModExoMechTheme.Core
{
    [BackgroundColor(49, 32, 36, 216)]
    public class ExoConfig : ModConfig
    {
        public static ExoConfig Instance => ModContent.GetInstance<ExoConfig>();

        public override ConfigScope Mode => ConfigScope.ClientSide;

        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(true)]
        public bool UseAltExoTheme { get; set; }

        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]
        public bool UseZenithFabrications { get; set; }
    }
}
