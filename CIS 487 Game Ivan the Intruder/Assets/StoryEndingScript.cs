using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryEndingScript : MonoBehaviour
{
    public Transform storyText;
    public Transform theEndText;
    public Transform moneyText;
    bool firstClick = false;
    private TextMeshProUGUI finalScore;
    // Start is called before the first frame update
    void Start()
    {
        theEndText.gameObject.SetActive(false);
        finalScore = GetComponent<TextMeshProUGUI>();
        finalScore.text = "$" + string.Format("{0:#,##0}", ScoreScript.Score);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (!firstClick)
            {
                firstClick = true;
                storyText.gameObject.SetActive(false);
                moneyText.gameObject.SetActive(false);
                theEndText.gameObject.SetActive(true);
            }
            else if (firstClick)
            {
                SceneManager.LoadScene("Main Menu");
            }
        }
    }
}
