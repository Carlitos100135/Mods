using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Jujutsu100135.Content.Items.Weapons
{
    public class IronCleaver : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 18;
            Item.DamageType = DamageClass.Melee;

            Item.width = 40;
            Item.height = 40;

            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.knockBack = 5f;
            Item.value = Item.buyPrice(silver: 75);
            Item.rare = ItemRarityID.Green;

            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }
    }
}