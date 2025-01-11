using System;
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

        #region Mechs types
        public static int ThanatosHeadType { get; private set; }
        public static int ThanatosBody1Type { get; private set; }
        public static int ThanatosBody2Type { get; private set; }
        public static int ThanatosTailType { get; private set; }
        public static int AresBodyType { get; private set; }
        public static int ApolloType { get; private set; }
        public static int ArtemisType { get; private set; }

        public static readonly int[] ExoMechNpcTypes =
        [
            ThanatosHeadType,
            ThanatosBody1Type,
            ThanatosBody2Type,
            ThanatosTailType,
            AresBodyType,
            ApolloType,
            ArtemisType
        ];

        #endregion

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
            if (ModLoader.TryGetMod("CalamityMod", out Mod clam))
            {
                CalamityMod = clam;

                if (CalamityMod.TryFind("ThanatosHead", out ModNPC thanatosHead)) ThanatosHeadType = thanatosHead.Type;
                if (CalamityMod.TryFind("ThanatosBody1", out ModNPC thanatosBody1)) ThanatosBody1Type = thanatosBody1.Type;
                if (CalamityMod.TryFind("ThanatosBody2", out ModNPC thanatosBody2)) ThanatosBody2Type = thanatosBody2.Type;
                if (CalamityMod.TryFind("ThanatosTail", out ModNPC thanatosTail)) ThanatosTailType = thanatosTail.Type;
                if (CalamityMod.TryFind("AresBody", out ModNPC aresBody)) AresBodyType = aresBody.Type;
                if (CalamityMod.TryFind("Apollo", out ModNPC apollo)) ApolloType = apollo.Type;
                if (CalamityMod.TryFind("Artemis", out ModNPC artemis)) ArtemisType = artemis.Type;
            }
        }

        public override void Unload()
        {
            CalamityMod = null;
        }
    }
}
