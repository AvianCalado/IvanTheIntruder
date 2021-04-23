using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public static int Score = 0;
    public static int number;
    private TextMeshProUGUI score_txt;
    
    // Start is called before the first frame update
    void Start()
    {
        //initialize randomizer from 100 to 5000 range
        number = Random.Range(100,5001);
        score_txt = GetComponent<TextMeshProUGUI>();
    }

    //update the text field
    private void Update()
    {
        score_txt.text = "Cash: $" + CommaScore();   
    }

    //Function used to format cash with commas
    public string CommaScore()
    {
        return string.Format("{0:#,##0}", Score);
    }
}
