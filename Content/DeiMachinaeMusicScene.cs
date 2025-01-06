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

            bool isThanatosHeadNearby = NPC.AnyNPCs(CalamityMod.Find<ModNPC>("ThanatosHead").Type) && Main.npc[NPC.FindFirstNPC(CalamityMod.Find<ModNPC>("ThanatosHead").Type)].Distance(player.Center) <= 8500f;
            bool isThanatosBody1Nearby = NPC.AnyNPCs(CalamityMod.Find<ModNPC>("ThanatosBody1").Type) && Main.npc[NPC.FindFirstNPC(CalamityMod.Find<ModNPC>("ThanatosBody1").Type)].Distance(player.Center) <= 8500f;
            bool isThanatosBody2Nearby = NPC.AnyNPCs(CalamityMod.Find<ModNPC>("ThanatosBody2").Type) && Main.npc[NPC.FindFirstNPC(CalamityMod.Find<ModNPC>("ThanatosBody2").Type)].Distance(player.Center) <= 8500f;
            bool isThanatosTailNearby = NPC.AnyNPCs(CalamityMod.Find<ModNPC>("ThanatosTail").Type) && Main.npc[NPC.FindFirstNPC(CalamityMod.Find<ModNPC>("ThanatosTail").Type)].Distance(player.Center) <= 8500f;
            bool isAresBodyNearby = NPC.AnyNPCs(CalamityMod.Find<ModNPC>("AresBody").Type) && Main.npc[NPC.FindFirstNPC(CalamityMod.Find<ModNPC>("AresBody").Type)].Distance(player.Center) <= 8500f;
            bool isApolloNearby = NPC.AnyNPCs(CalamityMod.Find<ModNPC>("Apollo").Type) && Main.npc[NPC.FindFirstNPC(CalamityMod.Find<ModNPC>("Apollo").Type)].Distance(player.Center) <= 8500f;
            bool isArtemisNearby = NPC.AnyNPCs(CalamityMod.Find<ModNPC>("Artemis").Type) && Main.npc[NPC.FindFirstNPC(CalamityMod.Find<ModNPC>("Artemis").Type)].Distance(player.Center) <= 8500f;

            return !BossRushActive && !InfernumCompatibility.SecondThemeShouldPlay && (isThanatosHeadNearby || isThanatosBody1Nearby || isThanatosBody2Nearby || isThanatosTailNearby || isAresBodyNearby || isApolloNearby || isArtemisNearby) && ExoConfig.Instance.UseAltExoTheme;
        }
    }
}
