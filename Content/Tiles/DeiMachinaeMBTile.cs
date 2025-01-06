using CalamityModExoMechTheme.Content.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CalamityModExoMechTheme.Content.Tiles
{
    public class DeiMachinaeMBTile : ModTile
    {
        // Defaults to a MusicBox
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileObsidianKill[Type] = true;
            Main.tileLighted[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.newTile.StyleLineSkip = 2;
            TileObjectData.addTile(Type);

            TileID.Sets.DisableSmartCursor[Type] = true;
            LocalizedText MusicBoxDM = CreateMapEntryName();
            AddMapEntry(new Color(191, 142, 111), MusicBoxDM);
        }

        /*public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 48, ModContent.ItemType<DeiMachinaeMB>());
        }*/

        public override void MouseOver(int i, int j)
        {
            Player localPlayer = Main.LocalPlayer;
            localPlayer.noThrow = 2;
            localPlayer.cursorItemIconEnabled = true;
            localPlayer.cursorItemIconID = ModContent.ItemType<DeiMachinaeMB>();
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            if (!Main.gamePaused && Main.instance.IsActive && (!Lighting.UpdateEveryFrame || Main.rand.NextBool(4)) && Main.tile[i, j].TileFrameX == 36 && Main.tile[i, j].TileFrameY % 36 == 0 && Main.timeForVisualEffects % 7 == 0 && Main.rand.Next(3) == 0)
            {
                int note = Main.rand.Next(570, 573);
                Vector2 position = new Vector2(i * 16 + 8, j * 16 - 8);
                Vector2 velocity = new Vector2(Main.WindForVisuals * 2f, -0.5f);
                velocity.X *= 1f + Main.rand.Next(-50, 51) * 0.01f;
                velocity.Y *= 1f + Main.rand.Next(-50, 51) * 0.01f;
                if (note == 572)
                {
                    position.X -= 8f;
                }
                if (note == 571)
                {
                    position.X -= 4f;
                }
                int goreIndex = Gore.NewGore(new EntitySource_TileUpdate(i, j, null), position, velocity, note, 0.8f);
                Main.gore[goreIndex].timeLeft = 120;
            }
        }
    }
}