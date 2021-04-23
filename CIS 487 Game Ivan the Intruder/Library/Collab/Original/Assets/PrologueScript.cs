using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrologueScript : MonoBehaviour
{
    public Transform storyText;
    public Transform bankText;
    public Transform controlsText;
    public Transform policeText;
    public Transform CrowbarText;
    public Transform moneyText;
    public Transform sodaText;
    public SpriteRenderer spriterendsoda;
    public SpriteRenderer spriterendmoney;
    public SpriteRenderer spriterendCrowbar;
    public SpriteRenderer spriterendpolice;
    bool firstClick = false;
    bool secondClick = false;
    // Start is called before the first frame update
    void Start()
    {
        controlsText.gameObject.SetActive(false);
        spriterendCrowbar = gameObject.GetComponent<SpriteRenderer>();
        spriterendsoda = gameObject.GetComponent<SpriteRenderer>();
        spriterendpolice = gameObject.GetComponent<SpriteRenderer>();
        spriterendmoney = gameObject.GetComponent<SpriteRenderer>();

        CrowbarText.gameObject.SetActive(false);
        policeText.gameObject.SetActive(false);
        sodaText.gameObject.SetActive(false);
        moneyText.gameObject.SetActive(false);
        spriterendCrowbar.enabled = false;
        spriterendsoda.enabled = false;
        spriterendpolice.enabled = false;
        spriterendmoney.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) {
            if (!firstClick && !secondClick)
            {
                firstClick = true;
                storyText.gameObject.SetActive(false);
                bankText.gameObject.SetActive(false);
                controlsText.gameObject.SetActive(true);
            }
            else if(!secondClick)
            {
                secondClick = true;
                controlsText.gameObject.SetActive(false);

                spriterendCrowbar.enabled = true;
                spriterendsoda.enabled = true;
                spriterendpolice.enabled = true;
                spriterendmoney.enabled = true;
                CrowbarText.gameObject.SetActive(true);
                policeText.gameObject.SetActive(true);
                sodaText.gameObject.SetActive(true);
                moneyText.gameObject.SetActive(true);
            }
            else if (firstClick && secondClick)
            {
                SceneManager.LoadScene("Level1");
            }
        }
    }
}
