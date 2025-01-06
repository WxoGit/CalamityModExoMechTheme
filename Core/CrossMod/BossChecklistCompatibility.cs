using CalamityModExoMechTheme.Content.Items;
using System;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace CalamityModExoMechTheme.Core.CrossMod
{
    public class BossChecklistCompatibility : ModSystem
    {
        /// <summary>
        /// Reference to BossChecklist mod.
        /// </summary>
        internal static Mod BossChecklist { get; set; }

        public override void Load()
        {
            ModLoader.TryGetMod("BossChecklist", out Mod boscheklis);
                BossChecklist = boscheklis;
        }

        public override void Unload()
        {
            BossChecklist = null;
        }

        public override void PostSetupContent()
        {
            DoBossChecklistIntegration();
        }

        private void DoBossChecklistIntegration()
        {
            // No Calamity no bosses
            if (CalamityCompatibility.CalamityMod is null)
                return;

            // Return if BossChecklist is not enabled
            if (BossChecklist is null)
                return;

            // Do not in old version
            if (BossChecklist.Version < new Version(1, 3, 1))
                return;

            BossChecklist.Call(new object[]
            {
                "AddToBossCollection",
                "CalamityMod Exo Mechs",
                new List<int>
                {
                    ModContent.ItemType<DeiMachinaeMB>()
                }
            });
        }
    }
}
