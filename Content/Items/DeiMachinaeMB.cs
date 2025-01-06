using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using CalamityModExoMechTheme.Content.Tiles;

namespace CalamityModExoMechTheme.Content.Items
{
    public class DeiMachinaeMB : ModItem
    {
        public override void SetStaticDefaults()
        {
            if (!Main.dedServ)
            {
                Item.ResearchUnlockCount = 1;
                ItemID.Sets.CanGetPrefixes[Type] = false; // music boxes can't get prefixes in vanilla
                ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.MusicBox; // recorded music boxes transform into the basic form in shimmer
                MusicLoader.AddMusicBox(Mod, MusicLoader.GetMusicSlot(Mod, "Assets/Music/DeiMachinae"), ModContent.ItemType<DeiMachinaeMB>(), ModContent.TileType<DeiMachinaeMBTile>());
            }
        }
        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<DeiMachinaeMBTile>();
            Item.width = 30;
            Item.height = 20;
            Item.rare = ItemRarityID.LightRed;
            Item.value = 100000;
            Item.accessory = true;
        }
    }
}
