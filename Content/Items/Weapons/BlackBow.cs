using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Jujutsu100135.Content.Items.Weapons
{
    public class BlackBow : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 36;
            Item.damage = 12;
            Item.DamageType = DamageClass.Ranged;
            Item.knockBack = 2f;
            Item.crit = 4;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item5; // Som padrão de arco
            Item.autoReuse = true;
            Item.shoot = ProjectileID.WoodenArrowFriendly; // Flecha padrão
            Item.shootSpeed = 7f;
            Item.useAmmo = AmmoID.Arrow;
            Item.value = Item.buyPrice(silver: 50);
            Item.rare = ItemRarityID.White;
            Item.noMelee = true; // Evita dano corpo a corpo com o arco
        }

        public override Vector2? HoldoutOffset()
        {
            // Ajusta levemente a posição do arco na mão do jogador
            return new Vector2(-2f, 0f);
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            // Exemplo simples: sempre consome munição
            return true;
        }
    }
}