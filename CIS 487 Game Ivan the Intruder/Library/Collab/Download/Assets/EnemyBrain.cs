using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBrain : MonoBehaviour{
    private GameObject player;
    public bool isFlipped;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player"); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //precompute raysettings
        Vector2 start = transform.position;
        Vector2 direction;
        if (isFlipped)
        {
             direction = transform.TransformDirection(Vector2.left);
        }
        else
        {
             direction = transform.TransformDirection(Vector2.right);
        }
        direction.Normalize();

        RaycastHit2D[] hits = Physics2D.RaycastAll(start, direction, distance);
        bool playerFound = false;

        for (int it = 0; it < hits.Length; it++)
        {
            Debug.DrawLine(transform.position, hits[it].point);
            if (hits[it].collider != null && hits[it].collider.tag == "Player")
            {
                playerFound = true;
            }
        }

        if (playerFound)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}