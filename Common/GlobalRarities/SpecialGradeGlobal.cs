using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;

public class SpecialGradeTooltipGlobal : GlobalItem
{
    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        if (item.rare != ModContent.RarityType<SpecialGradeRarity>())
            return;

        for (int i = 0; i < tooltips.Count; i++)
        {
            if (tooltips[i].Name == "ItemName" && tooltips[i].Mod == "Terraria")
            {
                Color lightRed = new Color(0, 0, 0);
                Color darkRed  = new Color(255, 255, 255);

                float time = (float)Main.GlobalTimeWrappedHourly * 2f;

                // Oscilação suave (simula movimento horizontal)
                float t = (MathF.Sin(time) + 1f) * 0.2f;

                tooltips[i].OverrideColor = Color.Lerp(lightRed, darkRed, t);
                break;
            }
        }
    }
}