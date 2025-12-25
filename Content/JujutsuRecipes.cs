using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Jujutsu100135
{
    public class JujutsuRecipes : ModSystem
    {
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ModContent.ItemType<Content.Items.Weapons.IronCleaver>(), 1) ;

            recipe.AddIngredient(ItemID.IronBar, 10);
            recipe.AddIngredient(ItemID.Wood, 5);

            recipe.AddTile(TileID.Anvils);

            recipe.Register();
        }
    }
}