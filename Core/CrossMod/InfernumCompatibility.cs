using Terraria.ModLoader;

namespace CalamityModExoMechTheme.Core.CrossMod
{
    public class InfernumCompatibility : ModSystem
    {
        /// <summary>
        /// Reference for Infernum.
        /// </summary>
        internal static Mod InfernumMode { get; set; }

        /// <summary>
        /// Reference for InfernumMusic.
        /// </summary>
        internal static Mod InfernumMusic { get; set; }

        /// <summary>
        /// Compatibility with infernum music.
        /// </summary>
        public static bool SecondThemeShouldPlay
        {
            get
            {
                if (InfernumMode is not null && InfernumMusic is not null)
                {
                    if (!ExoConfig.Instance.UseZenithFabrications)
                        return false;

                    var property = InfernumMode.Code.GetType("InfernumMode.Content.BehaviorOverrides.BossAIs.Draedon.ExoMechManagement").GetProperty("SecondThemeShouldPlay");
                    if (property is not null)
                        return (bool)property.GetValue(null);
                    else
                        return false;
                }
                return false;

            }
        }

        public override void Load()
        {
            ModLoader.TryGetMod("InfernumMode", out Mod funyMod);
            InfernumMode = funyMod;

            ModLoader.TryGetMod("InfernumModeMusic", out Mod funyModOst);
            InfernumMusic = funyModOst;
        }

        public override void Unload()
        {
            InfernumMode = null;
            InfernumMusic = null;
        }
    }
}
