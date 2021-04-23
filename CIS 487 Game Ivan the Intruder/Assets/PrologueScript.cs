using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrologueScript : MonoBehaviour
{
    public Transform storyText;
    public Transform bankText;
    public Transform controlsText;
    public Transform pressAnyKey;
    bool firstClick = false;
    // Start is called before the first frame update
    void Start()
    {
        controlsText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) {
            if (!firstClick)
            {
                firstClick = true;
                storyText.gameObject.SetActive(false);
                bankText.gameObject.SetActive(false);
                controlsText.gameObject.SetActive(true);
                pressAnyKey.gameObject.SetActive(false);

            }
            else if (firstClick)
            {
                SceneManager.LoadScene("Tutorial");
            }
        }
    }
}
