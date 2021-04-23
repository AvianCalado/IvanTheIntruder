using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{

    float CurrentTime = 0;
    float StartingTime = 30;

    [SerializeField] Text countdownText;
    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = StartingTime;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime -= 1 * Time.deltaTime;
        countdownText.text = CurrentTime.ToString("0");

        if (CurrentTime <= 0)
        {
            SceneManager.LoadScene("EscapeLevel");
        }
    }
}
