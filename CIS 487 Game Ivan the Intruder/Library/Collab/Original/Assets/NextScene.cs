using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private string newLevel = "Needs Level";

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene(newLevel);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
