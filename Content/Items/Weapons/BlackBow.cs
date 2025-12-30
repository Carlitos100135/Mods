using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Jujutsu100135.Content.Projectiles;

namespace Jujutsu100135.Content.Items.Weapons
{
    public class BlackBow : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 25;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 24;
            Item.height = 48;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 2f;
            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item5;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 8f;
            Item.useAmmo = AmmoID.Arrow;
        }

        public override bool AltFunctionUse(Player player) => true;

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.channel = true;
                Item.noUseGraphic = true;
                Item.shoot = ModContent.ProjectileType<BlackBowHeldProjectile>();
                Item.shootSpeed = 0f;
            }
            else
            {
                Item.channel = false;
                Item.noUseGraphic = false;
                Item.shoot = ProjectileID.WoodenArrowFriendly;
                Item.shootSpeed = 8f;
            }

            return base.CanUseItem(player);
        }

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                Projectile.NewProjectile(
                    source,
                    player.Center,
                    Vector2.Zero,
                    ModContent.ProjectileType<BlackBowHeldProjectile>(),
                    damage,
                    knockback,
                    player.whoAmI
                );
                return false;
            }

            return true;
        }
    }
}