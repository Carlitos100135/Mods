using Terraria;
using Terraria.ModLoader;

public class BlackBowPlayer : ModPlayer
{
    public bool wasChanneling;
    public bool usingAltFire;

    public override void ResetEffects()
    {
        usingAltFire = false;
    }

    public override void PostUpdate()
    {
        wasChanneling = Player.channel;
    }
}
