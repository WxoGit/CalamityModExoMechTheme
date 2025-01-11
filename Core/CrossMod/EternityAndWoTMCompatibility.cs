using System;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace CalamityModExoMechTheme.Core.CrossMod
{
    // This is made to play the music during the cool intro of this rework
    public class EternityAndWoTMCompatibility : ModSystem
    {
        private static Mod WoTM { get; set; }
        private static Mod FargoSouls { get; set; }

        public override void Load()
        {
            ModLoader.TryGetMod("WoTM", out Mod mechsMod);
            WoTM = mechsMod;

            // Sooo idk in what version of FargowiltasCrossmod will have the exos, so
            // as a fix the mod won't load fargo souls if draedon rework does not exist.
            ModLoader.TryGetMod("FargowiltasCrossmod", out Mod fargoCross);
            if (fargoCross is null)
                return;

            // Get DraedonEternity type
            Type draedonEternityType = fargoCross.Code.GetType("FargowiltasCrossmod.Content.Calamity.Bosses.ExoMechs.Draedon.DraedonEternity");
            if (draedonEternityType is null)
                return;

            ModLoader.TryGetMod("FargowiltasSouls", out Mod fargo);
            FargoSouls = fargo;
        }

        /// <summary>
        /// Checks if the Draedon plane cutscene is currently active.
        /// The cutscene is active when the Draedon has a specific AI state (https://github.com/LucilleKarma/WrathOfTheMachines/blob/main/Content/NPCs/ExoMechs/Draedon/DraedonEternity.cs#L69 == https://github.com/LucilleKarma/WrathOfTheMachines/blob/main/Content/NPCs/ExoMechs/Draedon/DraedonEternity.cs#L30).
        /// </summary>
        /// <returns>True if the Draedon plane cutscene is active; otherwise, false.</returns>
        public static bool IsDraedonCutsceneActive()
        {
            // Early exit if both FargoSouls and WoTM are null
            if (FargoSouls is null && WoTM is null)
                return false;

            // Check Eternity mode if FargoSouls is not null
            bool isEternityMode = FargoSouls is not null && Convert.ToBoolean(FargoSouls.Call("EternityMode"));

            // If either WoTM is loaded or Eternity mode is active
            if (isEternityMode || WoTM is not null)
            {
                // Look for Draedon NPC
                if (CalamityCompatibility.CalamityMod.TryFind("Draedon", out ModNPC draedon))
                {
                    // Return true if Draedon is active and in the correct AI state
                    return Main.npc.Any(npc => npc.active && npc.type == draedon.Type && npc.ai[0] == 2);
                }
            }

            return false;
        }

        public override void Unload()
        {
            WoTM = null;
            FargoSouls = null;
        }
    }
}
