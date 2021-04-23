using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSoda : PowerUp
{
    private float originalSpeed;
    private float originalJump;
    private float runIncrease = 5f;
    private float JumpIncrease = 1.5f;

    protected override void PowerUpPayload()
    {
        //plays sound effect
        base.audioSrc.PlayOneShot(soda_power_Sound);
        //Collect the base movemente speed of player
        originalSpeed = base.playerScript.movementSpeed;
        originalJump = base.playerScript.jumpForce;
        //Increase jump and movement speed
        base.playerScript.movementSpeed += runIncrease;
        base.playerScript.jumpForce += JumpIncrease;

        base.playerScript.PUinUse = 1;

        base.PowerUpHasExpired();

        //Calls Ienumerator function
        StartCoroutine("WaitTime");
        
    }

    // Syncs up to when powerup is destroyed and returns player speed back to original
    protected IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(5f);

        //Return back original speed
        base.playerScript.movementSpeed = originalSpeed;
        base.playerScript.jumpForce = originalJump;
        base.playerScript.PUinUse = -1;
    }


}
