using Terraria.Localization;
using Terraria.ModLoader;

namespace CalamityModExoMechTheme.Core.CrossMod
{
    public class MusicDisplayCompatibility : ModSystem
    {
        /// <summary>
        /// Reference to Music Display
        /// </summary>
        internal static Mod MusicDisplay { get; set; }

        public override void Load()
        {
            ModLoader.TryGetMod("MusicDisplay", out Mod mD);
            MusicDisplay = mD;
        }

        public override void Unload()
        {
            MusicDisplay = null;
        }

        public override void PostAddRecipes()
        {
            if (MusicDisplay is null)
                return;

            LocalizedText modName = Language.GetText("Mods.CalamityModExoMechTheme.MusicDisplay.ModName");

            void AddMusic(string path, string name)
            {
                LocalizedText author = Language.GetText("Mods.CalamityModExoMechTheme.MusicDisplay." + name + ".Author");
                LocalizedText displayName = Language.GetText("Mods.CalamityModExoMechTheme.MusicDisplay." + name + ".DisplayName");
                MusicDisplay.Call("AddMusic", (short)MusicLoader.GetMusicSlot(Mod, path), displayName, author, modName);
            }

            AddMusic("Assets/Music/DeiMachinae", "DeiMachinae");
        }
    }
}
