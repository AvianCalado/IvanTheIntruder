using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Purpose : Handles Collisions for all Powerups and destroys the object.
public class PowerUp : MonoBehaviour
{
    protected SpriteRenderer spriteRenderer;
    public bool powerSpriteAlive;
    protected PlayerBrain playerScript;

    public static AudioClip soda_power_Sound;
    public static AudioClip crowbar_sound;
    protected  AudioSource audioSrc;


    public enum PowerUpState
    {
        InAttractMode,
        IsCollected,
        IsExpiring,
    }

    PowerUpState powerUpState;

    // Awake() will run even when script isn't active
    //Used instead of Start()
    // Initializes variables
    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        soda_power_Sound = Resources.Load<AudioClip>("Soda");
        crowbar_sound = Resources.Load<AudioClip>("Crowbar");
        audioSrc = GetComponent<AudioSource>();
    }

    protected virtual void Start()
    {
        powerUpState = PowerUpState.InAttractMode;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PowerUpCollected(other.gameObject);

        }
    }

    protected virtual void PowerUpCollected(GameObject playerCollectingPowerUp)
    {

        // We only care if we've not been collected before
        if (powerUpState == PowerUpState.IsCollected || powerUpState == PowerUpState.IsExpiring)
        {
            return;
        }
        powerUpState = PowerUpState.IsCollected;

        // We must have been collected by a player, store handle to player for later use      
        playerScript = playerCollectingPowerUp.GetComponent<PlayerBrain>();

        // Payload      
        PowerUpPayload();


        // Now the power up visuals can go away
        spriteRenderer.enabled = false;
        powerSpriteAlive = false;
    }

    // Use this function for derived classes 
    protected virtual void PowerUpPayload()
    {
        Debug.Log("Power Up collected, issuing payload for: " + gameObject.name);
    }


    protected virtual void PowerUpHasExpired()
    {
        if (powerUpState == PowerUpState.IsExpiring)
        {
            return;
        }
        powerUpState = PowerUpState.IsExpiring;


        Debug.Log("Power Up has expired, removing after a delay for: " + gameObject.name);
        StartCoroutine("DestroySelfAfterDelay");
    }

    //coroutine that will destroy game object in 5.1 seconds to allow for child functions to process
    //PUinUse is to help display powerup in UI
    protected virtual IEnumerator DestroySelfAfterDelay()
    {
        yield return new WaitForSeconds(5.1f);
        playerScript.PUinUse = -1; 
        Destroy(gameObject);
    }

}
