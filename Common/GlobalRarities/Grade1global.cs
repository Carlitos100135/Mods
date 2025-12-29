using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;

public class Grade1TooltipGlobal : GlobalItem
{
    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        if (item.rare != ModContent.RarityType<SpecialGradeRarity>())
            return;

        for (int i = 0; i < tooltips.Count; i++)
        {
            if (tooltips[i].Name == "ItemName" && tooltips[i].Mod == "Terraria")
            {
                Color lightBlue = new Color(0,224,220);
                Color mediumBlue  = new Color(81,198,245);

                float time = (float)Main.GlobalTimeWrappedHourly * 2f;

                // Oscilação suave (simula movimento horizontal)
                float t = (MathF.Sin(time) + 1f) * 0.2f;

                tooltips[i].OverrideColor = Color.Lerp(lightBlue, mediumBlue, t);
                break;
            }
        }
    }
}
