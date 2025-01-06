using System;
using System.Linq;
using System.Reflection;
using Terraria.ModLoader;

namespace CalamityModExoMechTheme.Core.CrossMod
{
    public class CalamityCompatibility : ModSystem
    {
        /// <summary>
        /// Evil mod
        /// </summary>
        public static Mod CalamityMod { get; set; }

        public static bool BossRushActive
        {
            get
            {
                // Don't do anything if clam is not loaded
                if (CalamityMod is null)
                    return false;

                // Obtain type
                Type calamityEventsType = CalamityMod.Code.GetType("CalamityMod.Events.BossRushEvent");
                if (calamityEventsType is not null)
                {
                    // Obtain field and set it here
                    FieldInfo bossRushActiveField = calamityEventsType.GetField("BossRushActive", BindingFlags.Public | BindingFlags.Static);
                    if (bossRushActiveField is not null)
                    {
                        return (bool)bossRushActiveField.GetValue(null);
                    }
                }

                return false;
            }
        }

        public override void Load()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod clam);
            CalamityMod = clam;
        }

        public override void Unload()
        {
            CalamityMod = null;
        }
    }
}
