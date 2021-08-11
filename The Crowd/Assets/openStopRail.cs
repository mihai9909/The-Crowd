using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openStopRail : MonoBehaviour
{
    public GameObject Stop1,Stop2;

    bool rotated;
    public float speed=2f;

    private void FixedUpdate()
    {
        if (rotated)
        {
            Stop1.transform.Rotate(new Vector3(0f, -speed*Time.deltaTime, 0f));
            Stop2.transform.Rotate(new Vector3(0f, speed*Time.deltaTime, 0f));
            if (Stop2.transform.eulerAngles.y > 270)
                rotated = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (!rotated)
            {
                rotated = true;
            }
        }
    }
}
