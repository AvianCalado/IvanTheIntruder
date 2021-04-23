using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
    bool firstClick = true;
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if(firstClick)
            SceneManager.LoadScene("Level1");
        }
    }
}
