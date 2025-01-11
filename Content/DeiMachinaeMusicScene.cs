using CalamityModExoMechTheme.Core;
using CalamityModExoMechTheme.Core.CrossMod;
using Terraria;
using Terraria.ModLoader;
using static CalamityModExoMechTheme.Core.CrossMod.CalamityCompatibility;

namespace CalamityModExoMechTheme.Content
{
    public class DeiMachinaeMusicScene : ModSceneEffect
    {
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/DeiMachinae");
        public override SceneEffectPriority Priority => (SceneEffectPriority)13;
        public override float GetWeight(Player player) => 0.500f;
        public override bool IsSceneEffectActive(Player player)
        {
            if (CalamityMod is null)
                return false;

            // Check if any of the Exos is nearby
            bool isAnyBossNearby = IsNpcNearby(ThanatosHeadType, player, 8500f) || IsNpcNearby(ThanatosBody1Type, player, 8500f) || IsNpcNearby(ThanatosBody2Type, player, 8500f) ||
                       IsNpcNearby(ThanatosTailType, player, 8500f) || IsNpcNearby(AresBodyType, player, 8500f) || IsNpcNearby(ApolloType, player, 8500f) || IsNpcNearby(ArtemisType, player, 8500f);

            return !BossRushActive && !InfernumCompatibility.SecondThemeShouldPlay && isAnyBossNearby || EternityAndWoTMCompatibility.IsDraedonCutsceneActive() && ExoConfig.Instance.UseAltExoTheme;
        }

        /// <summary>
        /// Determines if an NPC of a given type is near the player within a specified range.
        /// </summary>
        /// <param name="npcType">The type ID of the NPC to check.</param>
        /// <param name="player">The player to measure distance from.</param>
        /// <param name="range">The maximum range within which the NPC is considered "nearby".</param>
        /// <returns>True if the NPC is within the specified range; otherwise, false.</returns>
        private static bool IsNpcNearby(int npcType, Player player, float range)
        {
            if (npcType <= 0)
                return false;
            int npcIndex = NPC.FindFirstNPC(npcType);
            if (npcIndex != -1)
            {
                NPC npc = Main.npc[npcIndex];
                return npc.active && npc.Distance(player.Center) <= range;
            }
            return false;
        }
    }
}
