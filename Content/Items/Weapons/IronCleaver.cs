using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Jujutsu100135.Content.Items.Weapons
{
    public class IronCleaver : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 15;                                   //dano
            Item.DamageType = DamageClass.Melee;                //classe do dano
            Item.width = 40;                                    //largura da hitbox 
            Item.height = 40;                                   //altura da hitbox
            Item.useTime = 20;                                  //coldown entre uso
            Item.useAnimation = 20;                             //tempo da animação
            Item.useStyle = ItemUseStyleID.Swing;               //jeito q o item é usado, balançar, perfurar, etc
            Item.knockBack = 5f;                                //knokback do item
            Item.value = Item.buyPrice(silver: 75);             //preço padrão de compra do item    
            Item.rare = ItemRarityID.White;                     //cor da raridade do item
            Item.UseSound = SoundID.Item1;                      //som q o item vai usar       
            Item.autoReuse = true;                              //se o item funciona em loop segurando botão
            Item.scale = 1.2f;                                  //escala do png do item no jogo
        }
    }
}