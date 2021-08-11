using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSaw : MonoBehaviour
{
    public float speed;

    private void FixedUpdate()
    {
        transform.position += new Vector3(Time.deltaTime * speed,0f,0f);
        if (transform.position.x > 8.75f || transform.position.x < -8.75f)
            speed = -speed;
    }

}
