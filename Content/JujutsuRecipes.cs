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

            recipe = Recipe.Create(ModContent.ItemType<Content.Items.Weapons.BlackBow>(),1);
            recipe.AddIngredient(ItemID.Shadewood, 15);
            recipe.AddIngredient(ItemID.Silk, 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

            recipe = Recipe.Create(ModContent.ItemType<Content.Items.Weapons.BlackBow>(),1);
            recipe.AddIngredient(ItemID.Ebonwood, 15);
            recipe.AddIngredient(ItemID.Silk, 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

            //daq pra baixo são coisas para facilitar crafting de itens
            recipe = Recipe.Create(ModContent.ItemType<Content.Items.Weapons.IronCleaver>(), 1) ;
            recipe.AddIngredient(ItemID.Wood, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

            recipe = Recipe.Create(ModContent.ItemType<Content.Items.Weapons.BlackBow>(),1);
            recipe.AddIngredient(ItemID.Wood, 15);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

        }
    }
}