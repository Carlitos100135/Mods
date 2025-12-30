using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ID;

namespace Jujutsu100135.Content.Projectiles
{
    public class BlackBowHeldProjectile : ModProjectile
    {
        public override string Texture => "Jujutsu100135/Content/Items/Weapons/BlackBow";

        private int chargeTime = 0;
        private int chargeLevel = 1; // 1, 2 ou 3

        private static Asset<Texture2D> stage1Texture;
        private static Asset<Texture2D> stage2Texture;
        private static Asset<Texture2D> stage3Texture;

        public override void Load()
        {
            stage1Texture = ModContent.Request<Texture2D>("Jujutsu100135/Content/Items/Weapons/BlackBow");
            stage2Texture = ModContent.Request<Texture2D>("Jujutsu100135/Content/Items/Weapons/BlackBow");
            stage3Texture = ModContent.Request<Texture2D>("Jujutsu100135/Content/Items/Weapons/BlackBow");
        }

        public override void SetDefaults()
        {
            Projectile.width = 28;
            Projectile.height = 48;
            Projectile.friendly = false;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 2; 
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            Projectile.Center = player.MountedCenter;
            Vector2 direction = Main.MouseWorld - Projectile.Center;
            Projectile.rotation = direction.ToRotation();

            if (player.channel)
            {
                chargeTime++;
                if (chargeTime < 30) chargeLevel = 1;
                else if (chargeTime < 60) chargeLevel = 2;
                else chargeLevel = 3;

                Projectile.timeLeft = 2;
                player.itemAnimation = 2;
                player.itemTime = 2;
            }
            else
            {
                FireArrows(player);
                Projectile.Kill();
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            SpriteBatch spriteBatch = Main.spriteBatch;
            Texture2D texture = stage1Texture.Value;

            if (chargeLevel == 2) texture = stage2Texture.Value;
            else if (chargeLevel == 3) texture = stage3Texture.Value;

            Vector2 drawOrigin = new Vector2(texture.Width / 2, texture.Height / 2);

            spriteBatch.Draw(
                texture,
                Projectile.Center - Main.screenPosition,
                null,
                Color.White,
                Projectile.rotation,
                drawOrigin,
                1f,
                SpriteEffects.None,
                0f
            );

            return false;
        }

        private void FireArrows(Player player)
        {
            int arrowsToShoot = chargeLevel;
            float damageMultiplier = 1f;

            if (chargeLevel == 2) damageMultiplier = 1.2f;
            else if (chargeLevel == 3) damageMultiplier = 1.5f;

            for (int i = 0; i < arrowsToShoot; i++)
            {
                int projType;
                float speed;
                int damage;
                float knockBack;
                int usedAmmo;

                bool hasAmmo = player.PickAmmo(player.HeldItem, out projType, out speed, out damage, out knockBack, out usedAmmo, false);

                if (!hasAmmo)
                {
                    projType = ProjectileID.WoodenArrowFriendly;
                    damage = (int)(player.HeldItem.damage * damageMultiplier);
                    knockBack = player.HeldItem.knockBack;
                }
                else
                {
                    damage = (int)(damage * damageMultiplier);
                }

                // Dispersão
                float spread = 5f;
                Vector2 velocity = Vector2.Normalize(Main.MouseWorld - player.Center) * speed;
                float offset = (i - (arrowsToShoot - 1) / 2f) * spread;
                velocity = velocity.RotatedBy(MathHelper.ToRadians(offset));

                Projectile.NewProjectile(
                    Projectile.GetSource_FromThis(),
                    player.Center,
                    velocity,
                    projType,
                    damage,
                    knockBack,
                    player.whoAmI
                );

                if (hasAmmo)
                    player.ConsumeItem(usedAmmo);
            }
        }
    }
}