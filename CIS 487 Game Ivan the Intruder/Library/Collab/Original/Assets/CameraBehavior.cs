using UnityEngine;
using System.Collections;
public class CameraBehavior : MonoBehaviour
{
    public Transform target;
    public Transform rightCameraLimit;
    public Transform leftCameraLimit;

    void Start()
    {
        //Starting position
        transform.position = new Vector3(leftCameraLimit.transform.position.x + 1.5f, -2.2f, -10);

    }
    void Update()
    {
        //if the camera hasn't reached map boundary yet
        if (transform.position.x < rightCameraLimit.transform.position.x && target.position.x > leftCameraLimit.transform.position.x)
        {
            if (target)
            {
                transform.position = new Vector3(target.position.x + 1.5f,-2.2f, -10);
            }
        }
    }
}