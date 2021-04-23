using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    //[SerializeField]
    public Sprite [] PlayerppUP;
    private Image powerupHolder;
    private PowerUp powerupScript;
    private PlayerBrain playerscript;


    // Start is called before the first frame update


    void Start()
    {
        playerscript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBrain>();
        powerupScript = GameObject.FindGameObjectWithTag("PowerUp").GetComponent<PowerUp>();
        powerupHolder = GameObject.Find("PowerUpHolder").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(powerupScript.powerSpriteAlive == false)
        {
            if(playerscript.PUinUse == -1)
            {
                powerupHolder.enabled = false;
            }
            else 
            {
                powerupHolder.sprite = PlayerppUP[playerscript.PUinUse];
                powerupHolder.enabled = true;
            }

        }

      

    }
}
