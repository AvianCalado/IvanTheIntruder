using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUP : MonoBehaviour
{
    public string powerUpName;
    public string powerUpExplanation;
    public string powerUpQuote;
    [Tooltip("Tick true for power ups that are instant use, eg a health addition that has no delay before expiring")]
    public bool expiresImmediately;
    public GameObject specialEffect;
    public AudioClip soundEffect;     //Possible audio when collecting

    protected SpriteRenderer spriteRenderer;

    protected enum PowerUpState
    {
        InAttractMode,
        IsCollected,
        IsExpiring
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        powerUpState = PowerUpState.InAttractMode;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        PowerUpCollected(other.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
