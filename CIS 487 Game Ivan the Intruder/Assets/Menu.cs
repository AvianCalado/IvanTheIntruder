using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadScene("Story Prologue");
    }
   public void LoadMain()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
