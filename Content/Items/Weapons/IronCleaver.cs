using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Jujutsu100135.Content.Items.Weapons
{
    public class IronCleaver : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 15;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 5f;
            Item.value = Item.buyPrice(silver: 75);
            Item.rare = ModContent.RarityType<SpecialGradeRarity>();
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.scale = 1.2f;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Descrição de destaque (abaixo do nome)
            tooltips.Insert(1, new TooltipLine(Mod, "Flavor", "Special Grade"));
            float pulse = (float)(Math.Sin(Main.GlobalTimeWrappedHourly * 4f) * 0.5f + 0.5f);
            Color darkRed = new Color(120, 0, 0);
            Color brightRed = new Color(255, 50, 50);

            Color pulseColor = Color.Lerp(darkRed, brightRed, pulse);

            foreach (var line in tooltips)
            {
                if (line.Mod == Mod.Name && line.Name == "Flavor")
                {
                    line.OverrideColor = pulseColor;
                }
            }
        }
    }
}