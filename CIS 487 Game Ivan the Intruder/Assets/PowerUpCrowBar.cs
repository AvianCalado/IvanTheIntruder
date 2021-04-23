using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCrowBar : PowerUp
{

    protected override void PowerUpPayload()
    {
        base.audioSrc.PlayOneShot(crowbar_sound);
        base.PowerUpHasExpired();
        base.playerScript.PUinUse = 0;
    }
}
