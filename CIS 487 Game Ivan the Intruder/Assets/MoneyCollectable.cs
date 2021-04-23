using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCollectable : MonoBehaviour
{
    public static AudioClip money_sound;
    private AudioSource audiosrc;
    private SpriteRenderer spriterenderer;

    private void Awake()
    {
        money_sound = Resources.Load<AudioClip>("Money");
        audiosrc = GetComponent<AudioSource>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }
    // plays a sound and use the score script to update the HUD
    // destroy object after 0.2 seconds
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            audiosrc.volume = 0.05f;
            audiosrc.PlayOneShot(money_sound);
            ScoreScript.Score = ScoreScript.Score + ScoreScript.number;
            spriterenderer.enabled = false;
            Destroy(gameObject,.2f);
        }
    }
}
